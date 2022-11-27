using AppNet6.Core.Entities;

namespace AppNet6.Core.DTOs
{
    public class UsuarioCalificacionNpsDTO
    {
        public int IdUsuario { get; set; }
        public int CalificacionPuntuacion { get; set; }
        public string CalificacionDescripcion { get; set; }
    }
}
