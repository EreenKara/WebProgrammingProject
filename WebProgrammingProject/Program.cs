using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using WebProgrammingProject.Data;
using WebProgrammingProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

#region Localization
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
//builder.Services.AddMvc().AddViewLocalization();
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization();
//options =>

//options.DataAnnotationLocalizerProvider = (type, factory) =>
//{
//    var assemblyName = typeof(DenemelikSinif).GetTypeInfo().Assembly.FullName;
//    return factory.Create(nameof(DenemelikSinif), assemblyName);
//});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultures = new CultureInfo[]
    {
        new CultureInfo("tr-TR"),
        new CultureInfo("en-US"),
    };
    options.DefaultRequestCulture = new RequestCulture("tr-TR");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});
#endregion

#region Identity Services
builder.Services.AddDbContext<AirLineContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AirLineContext>()
                .AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<AirLineContext>();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
// istersen aþaðýdaki configure methodunu kulalanrak passwordün isteklerini customize edebilrisin.
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.Password.RequireNonAlphanumeric = false;
//});
#endregion

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication(); // Authentication
app.UseRouting();

// Localization
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value); 
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=AnaSayfa}/{action=Index}/{id?}");

    
});

await RoleAndAdminData.InitializeAsync(app.Services);

app.Run();
