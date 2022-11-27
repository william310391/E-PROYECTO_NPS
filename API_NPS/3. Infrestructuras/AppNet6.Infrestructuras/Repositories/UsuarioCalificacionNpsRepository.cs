using AppNet6.Core.DTOs;
using AppNet6.Core.Entities;
using AppNet6.Infrestructuras.Data;
using AppNet6.Infrestructuras.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Repositories
{
    public class UsuarioCalificacionNpsRepository : BaseRepository<UsuarioCalificacionNps>, IUsuarioCalificacionNpsRepository
    {
        public UsuarioCalificacionNpsRepository(AppContextBD context) : base(context) { }


        public async Task<UsuarioCalificacionNps> GetUsuarioCalificonPorUsuario(UsuarioCalificacionNpsDTO usuarioCalificacionNpsDTO)
        {
            return await _entities.AsQueryable()
                .Where(x => x.IdUsuario == usuarioCalificacionNpsDTO.IdUsuario)
                .FirstOrDefaultAsync();       
        }

    }
}
