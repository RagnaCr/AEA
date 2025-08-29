using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Presentation.Web.Auth;
using Presentation.Web.Client.Pages;
using Presentation.Web.Components;
using Presentation.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// ������������ ������� ��� �����������, ��� � ������ ������
builder.Services.AddAuthorization();

// ������������ ������� ��� ��������� �������� ��������� ��������������
builder.Services.AddCascadingAuthenticationState();

// � ������������ ��� ���������-��������, ����� ������ ��� ����������
builder.Services.AddScoped<AuthenticationStateProvider, ServerSideAuthStateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Presentation.Web.Client._Imports).Assembly);

app.Run();
