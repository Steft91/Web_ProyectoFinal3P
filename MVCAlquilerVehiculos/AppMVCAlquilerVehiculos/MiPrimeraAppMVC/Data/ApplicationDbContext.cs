using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CapaEntidad;

namespace MiPrimeraAppMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<UsuarioCLS>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
