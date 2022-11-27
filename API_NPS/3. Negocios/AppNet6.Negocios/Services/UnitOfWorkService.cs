using AppNet6.Infrestructuras.Interfaces;
using AppNet6.Negocios.Interfaces;

namespace AppNet6.Negocios.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioService _usuarioService;
        private readonly ISeguridadService _seguridadService;
        private readonly IUsuarioCalificacionNpsService _usuarioCalificacionNpsService;

        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IUsuarioService UsuarioService => _usuarioService ?? new UsuarioService(_unitOfWork);
        public ISeguridadService SeguridadService => _seguridadService ?? new SeguridadService(_unitOfWork);
        public IUsuarioCalificacionNpsService UsuarioCalificacionNpsService => _usuarioCalificacionNpsService ?? new UsuarioCalificacionNpsService(_unitOfWork);

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
            }
        }


    }

}
