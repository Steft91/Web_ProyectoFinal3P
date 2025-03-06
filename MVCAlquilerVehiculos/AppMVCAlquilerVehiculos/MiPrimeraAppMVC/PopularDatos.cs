using Microsoft.AspNetCore.Identity;
using CapaEntidad;

namespace MiPrimeraAppMVC
{
    public class PopularDatos
    {
        public static async Task Inicializar(IServiceProvider serviceProvider, UserManager<UsuarioCLS> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Empleado", "Usuario" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            System.Console.WriteLine("Se crearon los roles");

            // Administrador por defecto
            UsuarioCLS? user = await userManager.FindByEmailAsync("komodroid@outlook.com");

            if (user != null)
            {
                await userManager.AddToRoleAsync(user, "Empleado");
                System.Console.WriteLine("Se asignó el rol de Empleado al usuario por defecto");
            } else
            {
                System.Console.WriteLine("No se encontró el usuario para asignar administrador por defecto");
            }
        }
    }
}
