using AppNet6.Core.DTOs;
using AppNet6.Core.Entities;
using AppNet6.Infrestructuras.Data;
using AppNet6.Infrestructuras.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppNet6.Infrestructuras.Repositories
{
    public class SeguridadRepository : BaseRepository<Seguridad>, ISeguridadRepository
    {
        public SeguridadRepository(AppContextBD context) : base(context) { }

        public async Task<Seguridad> GetLoginByCredentials(SeguridadDTO seguridadDTO)
        {
            return await _entities.AsQueryable()
                .Where(x => x.Usuario == seguridadDTO.Usuario.Trim())
                // .Where(x => x.Contrasena == seguridadDTO.Contrasena)
                .FirstOrDefaultAsync();
        }
    }
}
