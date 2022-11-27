
namespace AppNet6.Core.Entities
{
    public partial class Usuario : BaseEntity
    {    
        
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Cuenta { get; set; }
        public string? Contrasena { get; set; }
        public string? Correo { get; set; }
        public int IdPerfil { get; set; }
    }
}
