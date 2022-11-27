using AppNet6.Core.CustionEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }
        ISeguridadRepository SeguridadRepository { get; }
        IUsuarioCalificacionNpsRepository UsuarioCalificacionNpsRepository { get; }


        IMapper Mapper { get; }
        ITokenService TokenService { get; }
        PaginationOptions PaginationOptions { get; }
        public IUrlService UrlService { get; }
        public IPasswordService PasswordService { get; }


        void SaveChanges();
        Task SaveChangesAsync();
    }
}
