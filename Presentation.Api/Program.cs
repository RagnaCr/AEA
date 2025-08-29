using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using SimpleMediator;
using Infrastructure.Integrations.Services;
using Infrastructure.Integrations.BackgroundJobs;
using Microsoft.AspNetCore.DataProtection;
using Core.Application.Common.Interfaces.Exchanges;
using Infrastructure.Integrations.Exchanges;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddHttpClient();

// --- ��������� ���� Infrastructure.Persistence ---
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        // ������� EF, ��� ������ ��������
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

// ������������ ���������� ������ ����������. ������ �����, ��� �������� IApplicationDbContext, ������� ������������������ ApplicationDbContext.
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

// �������� ��� ���������� !!!!! ������������
builder.Services.AddSingleton<IMarketDataService, StubMarketDataService>();

// ������� ������ ��� ��������� ������ ���� � 2 ���� ����
builder.Services.AddHostedService<PortfolioSnapshotJob>();

// --- ��������� ���� Core.Application ---
// ������������ ���� MediatR, ����� �� ����� ��� ���� ������� � �����������
builder.Services.AddMediatR(typeof(IApplicationDbContext).Assembly);

// ������������ ������� ��� ����� ���_����-������������
builder.Services.AddScoped<IExchangeApiClientFactory, ExchangeApiClientFactory>();
// �����
builder.Services.AddScoped<IExchangeApiClient, BybitApiClient>();
builder.Services.AddScoped<IExchangeApiClient, QuestradeApiClient>();
// ������� ������ ��� �������������
builder.Services.AddHostedService<ApiDataSyncJob>();

// ������������ ������ ��� ���������� ���������������� ������
builder.Services.AddSingleton<IDataProtectionService, DataProtectionService>();
builder.Services.AddDataProtection().SetApplicationName("AggregatorShared");

// --- ��������� Identity ---
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // ��� ����� ������� ������������� ������������ ��������� ������������� ��� Enums
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// ��� ����������� � Blazor
var clientUrl = "https://localhost:7184";
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(clientUrl) // ��������� ������� ������ � ����� ������
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    // 1. ���������� ����� ������������
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "������� ����� JWT. ������: \"Bearer {token}\""
    });

    // 2. ��������� ���������� ������������ ��� ���� ����������, ������������ ��� �����
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// ������������ HTTP-���������.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // --- �������������� ���������� �������� ��� ������ (������ ��� ����������) ---
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
//app.UseAuthorization();

app.MapControllers();

app.Run();