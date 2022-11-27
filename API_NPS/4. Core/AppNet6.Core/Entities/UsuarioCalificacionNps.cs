namespace AppNet6.Core.Entities
{
    public class UsuarioCalificacionNps: BaseEntity
    {   
        public int IdUsuario { get; set; }
        public int CalificacionPuntuacion { get; set; }
        public string CalificacionDescripcion { get; set;}

       
    }
}
