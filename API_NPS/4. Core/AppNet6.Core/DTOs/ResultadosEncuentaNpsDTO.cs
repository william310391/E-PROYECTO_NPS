using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Core.DTOs
{
    public class ResultadosEncuentaNpsDTO
    {
        public List<DatoUsuarioDTO> ListaUsuario { get; set; }
        public int cantidadPromotores { get; set; }
        public int cantidadDetractores { get; set; }
        public int cantidadEncuestados { get; set; }        
        public decimal NPS { get; set; }

        public class DatoUsuarioDTO
        {
            public int idUsuario { get; set; }
            public string? Nombres { get; set; }
            public string? Apellidos { get; set; }
            public int CalificacionPuntuacion { get; set; }
            public string CalificacionDescripcion { get; set; }

        }
    }


}
