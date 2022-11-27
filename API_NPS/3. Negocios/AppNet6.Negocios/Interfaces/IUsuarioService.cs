using AppNet6.Core.DTOs;
using AppNet6.Core.Response;

namespace AppNet6.Negocios.Interfaces
{
    public interface IUsuarioService
    {
        Task<ApiResponse<UsuarioDTO>> GetLoginByCredentials(UsuarioDTO usuarioDTO);
        Task<ApiResponse<UsuarioDTO>> RegistrarUsuario(UsuarioDTO usuarioDTO);
        Task<ApiResponse<IEnumerable<UsuarioDTO>>> GetListUsuario(UsuarioDTO usuarioDTO);
    }
}
