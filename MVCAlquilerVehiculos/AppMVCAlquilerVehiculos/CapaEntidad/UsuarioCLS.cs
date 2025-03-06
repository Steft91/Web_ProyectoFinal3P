using Microsoft.AspNetCore.Identity;

namespace CapaEntidad
{
    public class UsuarioCLS : IdentityUser
    {
        public required string TipoUsuario { get; set; }
    }
}
