using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAppMVC.Data;
using CapaDatos;
using CapaPresentacion;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MiPrimeraAppMVC;
using System.Web.Http.Dispatcher;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Contexto de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer((new CadenaDAL()).cadena));

// Autenticación
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Capa Presentación
// https://stackoverflow.com/questions/34236850/asp-net-mvc-6-view-components-in-a-separate-assembly/61158913#61158913
// https://github.com/dotnet/AspNetCore.Docs/issues/14593
builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
    {
        options.FileProviders.Add(new EmbeddedFileProvider(
             typeof(CapaPresentacion.Controllers.HomeController).Assembly
        ));
    }
);

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

app.Run();
