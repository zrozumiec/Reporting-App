using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportingApp.Application.Extensions;
using ReportingApp.Domain.Entities;
using ReportingApp.Infrastructure;
using ReportingApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.RegisterMappers();
builder.Services.RegisterMediatR();
builder.Services.RegisterRepositories();
builder.Services.RegisterFluentValidator();
builder.Services.RegisterUserContext();

var app = builder.Build();

var cultureInfo = new CultureInfo("en-US");
cultureInfo.NumberFormat.CurrencySymbol = "€";
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using var scope = app.Services.CreateScope();
var appDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
var pendingMigrations = await appDbContext.Database.GetPendingMigrationsAsync();

if (pendingMigrations.Any())
{
    appDbContext.Database.Migrate();
}

app.Run();
