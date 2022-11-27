using AppNet6.Core.DTOs;
using AppNet6.Core.Entities;

namespace AppNet6.Infrestructuras.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetLoginByCredentials(UsuarioDTO usuarioDTO);
        Task<IEnumerable<Usuario>> GetListUsuario(UsuarioDTO usuarioDTO);
        Task<Usuario> GetUsuarioByIdUsuario(int idUsuario);

    }
}
