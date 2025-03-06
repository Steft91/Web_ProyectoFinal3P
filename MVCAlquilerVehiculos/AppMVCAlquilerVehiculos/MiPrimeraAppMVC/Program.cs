using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAppMVC.Data;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;
using CapaDatos;
using CapaEntidad;
using MiPrimeraAppMVC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Contexto de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer((new CadenaDAL()).cadena));

// Autenticaci�n
builder.Services.AddIdentity<UsuarioCLS, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();


builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Capa Presentaci�n
// https://stackoverflow.com/questions/34236850/asp-net-mvc-6-view-components-in-a-separate-assembly/61158913#61158913
// https://github.com/dotnet/AspNetCore.Docs/issues/14593
builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
    {
        options.FileProviders.Add(new EmbeddedFileProvider(
             typeof(CapaPresentacion.Controllers.HomeController).Assembly
        ));
    }
);

// Roles usuarios
builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireEmpleadoRole", policy => policy.RequireRole("Empleado"));
    }
);


builder.Services.AddRazorPages();

var app = builder.Build();

// Asignar roles por defecto
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<UsuarioCLS>>();
    PopularDatos.Inicializar(services, userManager).Wait();
}

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
