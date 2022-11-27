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
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppContextBD context) : base(context) { }

        public async Task<Usuario> GetLoginByCredentials(UsuarioDTO usuarioDTO)
        {
            return await _entities.AsQueryable()
                .Where(x => x.Cuenta == usuarioDTO.Cuenta.Trim())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> GetListUsuario(UsuarioDTO usuarioDTO)
        {
            return await _entities.AsQueryable()
                .Where(x => x.Id != usuarioDTO.Id)
                .ToListAsync();
        }
        public async Task<Usuario> GetUsuarioByIdUsuario(int idUsuario)
        {    
            return await _entities.AsQueryable()
                 .Where(x => x.Id == idUsuario)
                 .FirstOrDefaultAsync();
        }
    }
}
