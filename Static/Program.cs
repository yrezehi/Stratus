using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using Static.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"apsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables().Build()
                ).CreateLogger();

builder.RegisterConfiguration();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHealthChecks();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.RegisterSingletonServices();
builder.RegisterTransientServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
