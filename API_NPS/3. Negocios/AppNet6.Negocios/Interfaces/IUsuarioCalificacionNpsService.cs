using AppNet6.Core.DTOs;
using AppNet6.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Negocios.Interfaces
{
    public interface IUsuarioCalificacionNpsService
    {
        Task<ApiResponse<UsuarioCalificacionNpsDTO>> RegistrarUsuarioCalificionNps(UsuarioCalificacionNpsDTO usuarioCalificacionNpsDTO);
        Task<ApiResponse<ResultadosEncuentaNpsDTO>> ResultadosNPS();

    }
}
