using AppNet6.Core.DTOs;
using AppNet6.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Interfaces
{
    public interface IUsuarioCalificacionNpsRepository : IBaseRepository<UsuarioCalificacionNps>
    {
        Task<UsuarioCalificacionNps> GetUsuarioCalificonPorUsuario(UsuarioCalificacionNpsDTO usuarioCalificacionNpsDTO);
    }
}
