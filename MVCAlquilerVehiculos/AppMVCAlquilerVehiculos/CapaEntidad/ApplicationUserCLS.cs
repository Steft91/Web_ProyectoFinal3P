
using Microsoft.AspNet.Identity.EntityFramework;

namespace CapaEntidad
{
    public class ApplicationUserCLS : IdentityUser
    {
        public string TipoUsuario { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUserCLS>
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
