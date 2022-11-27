using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Negocios.Interfaces
{
    public interface IUnitOfWorkService : IDisposable
    {   
        IUsuarioService UsuarioService { get; }
        ISeguridadService SeguridadService { get; }
        IUsuarioCalificacionNpsService UsuarioCalificacionNpsService { get; }

    }
}
