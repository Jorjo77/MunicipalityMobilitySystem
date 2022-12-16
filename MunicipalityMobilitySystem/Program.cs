using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MunicipalityMobilitySystem.Core.Contracts.Bike;
using MunicipalityMobilitySystem.Core.Contracts.Car;
using MunicipalityMobilitySystem.Core.Contracts.Scooter;
using MunicipalityMobilitySystem.Core.Contracts.Truck;
using MunicipalityMobilitySystem.Core.Services;
using MunicipalityMobilitySystem.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MunicipalityMobilitySystemDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<MunicipalityMobilitySystemDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();

builder.Services.AddResponseCaching();

WebApplication app = builder.Build();

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

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
