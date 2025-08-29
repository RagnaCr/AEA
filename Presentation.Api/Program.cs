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

// --- Настройка слоя Infrastructure.Persistence ---
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        // Говорим EF, где искать миграции
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

// Регистрируем реализацию нашего интерфейса. Теперь любой, кто попросит IApplicationDbContext, получит сконфигурированный ApplicationDbContext.
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

// Временно для разработки !!!!! ПЕРЕСМОТРЕТЬ
builder.Services.AddSingleton<IMarketDataService, StubMarketDataService>();

// фоновый воркер для снапшотов каждый день в 2 часа ночи
builder.Services.AddHostedService<PortfolioSnapshotJob>();

// --- Настройка слоя Core.Application ---
// Регистрируем СВОЙ MediatR, чтобы он нашел все наши команды и обработчики
builder.Services.AddMediatR(typeof(IApplicationDbContext).Assembly);

// Регистрируем фабрику для связи апи_нейм-пользователь
builder.Services.AddScoped<IExchangeApiClientFactory, ExchangeApiClientFactory>();
// биржи
builder.Services.AddScoped<IExchangeApiClient, BybitApiClient>();
builder.Services.AddScoped<IExchangeApiClient, QuestradeApiClient>();
// фоновый воркер для синхронизаций
builder.Services.AddHostedService<ApiDataSyncJob>();

// Регестрируем сервис для шифрования пользовательских данных
builder.Services.AddSingleton<IDataProtectionService, DataProtectionService>();
builder.Services.AddDataProtection().SetApplicationName("AggregatorShared");

// --- Настройка Identity ---
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
        // Эта опция говорит сериализатору использовать строковые представления для Enums
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Для подключение к Blazor
var clientUrl = "https://localhost:7184";
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(clientUrl) // Разрешаем запросы только с этого адреса
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    // 1. Определяем схему безопасности
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Введите токен JWT. Пример: \"Bearer {token}\""
    });

    // 2. Добавляем требование безопасности для всех эндпоинтов, использующих эту схему
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

// Конфигурация HTTP-пайплайна.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // --- Автоматическое применение миграций при старте (удобно для разработки) ---
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