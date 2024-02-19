using LegelProNewVersion;
using LegelProNewVersion.Data;
using LegelProNewVersion.Repository.Interface;
using LegelProNewVersion.Repository.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Security;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("cs") ?? throw new InvalidOperationException("Connection string 'cs' not found.");
builder.Services.AddDbContext<LegelProNewVersionDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<ISystemConfigRepository, SystemConfigRepository>();
builder.Services.AddScoped<IMainDashboardRepository, MainDashboardRepository>();
builder.Services.AddScoped<IUserPermissionReposetory, UserPermissionReposetory>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ILoginStyleRepository, LoginStyleRepository>();
builder.Services.AddScoped<IImportanceOfMailRepository, ImportanceOfMailRepository>();
builder.Services.AddScoped<IAreasRepository, AreasRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IEntityRepository, EntityRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IMailerRepository, MailerRepository>();
builder.Services.AddScoped<ITypeOfMailRepository, TypeOfMailRepository>();
builder.Services.AddScoped<IApproveStatusRepository, ApproveStatusRepository>();
builder.Services.AddScoped<ITypeOfJobRepository, TypeOfJobRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<ISubDepartmentRepository, SubDepartmentRepository>();
builder.Services.AddScoped<ISupDepartRoleRepository,SupDepartRoleRepository>();
builder.Services.AddScoped<IAdvancedSettingRepository, AdvancedSettingRepository>();
builder.Services.AddScoped<IPageRepository, PageRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();


builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar"),

    };

    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

TimeSpan DefaultUserSessionSpan = new(12, 0, 0);
builder.Services.AddSession(o =>
{
    o.IdleTimeout = DefaultUserSessionSpan;
});

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "LegelProNewVersion.Session";
        options.Cookie.IsEssential = true;
        options.SlidingExpiration = false;
        options.ExpireTimeSpan = DefaultUserSessionSpan;
        options.LoginPath = "/LoginStyle/style3";
        options.AccessDeniedPath = "/Error/AccessDenied";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDefaultFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
var options = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=WelcomePage}/{action=Index}/{id?}");

app.Run();
