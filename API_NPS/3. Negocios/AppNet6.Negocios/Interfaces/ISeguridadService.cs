using AppNet6.Core.DTOs;
using AppNet6.Core.Response;

namespace AppNet6.Negocios.Interfaces
{
    public interface ISeguridadService
    {
        Task<ApiResponse<SeguridadDTO>> RegistrarUsuarioApi(SeguridadDTO seguridadDTO);
        Task<ApiResponse<SeguridadDTO>> AuthenticationApi(SeguridadDTO seguridadDTO);

    }
}
