using AppNet6.Core.Entities;

namespace AppNet6.Core.DTOs
{
    public class UsuarioDTO:BaseEntity 
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Cuenta { get; set; }
        public string? Contrasena { get; set; }
        public string? Correo { get; set; }
        public int IdPerfil { get; set; }
    }
}
