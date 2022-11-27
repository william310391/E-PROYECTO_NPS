using AppNet6.Core.CustionEntities;
using AppNet6.Infrestructuras.Data;
using AppNet6.Infrestructuras.Interfaces;
using AppNet6.Infrestructuras.Options;
using AppNet6.Infrestructuras.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AppNet6.Infrestructuras.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContextBD _context;
        private readonly ISeguridadRepository _seguridadRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioCalificacionNpsRepository _UsuarioCalificacionNpsRepository;


        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly PaginationOptions _paginationOptions;
        private readonly PasswordOptions _passwordOptions;
        private readonly IOptions<PasswordOptions> _ipasswordOptions;
        private readonly IUrlService _urlService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;

 


        public UnitOfWork(AppContextBD context, IMapper mapper, IOptions<PaginationOptions> options, IUrlService urlService, IConfiguration configuration, IOptions<PasswordOptions> passwordOptions, AutoMapper.IConfigurationProvider configurationProvider)
        {
            _context = context;
            _mapper = mapper;
            _paginationOptions = options.Value;
            _urlService = urlService;
            _configuration = configuration;
            _passwordOptions = passwordOptions.Value;
            _ipasswordOptions = passwordOptions;
            _configurationProvider = configurationProvider;
        }

        public ISeguridadRepository SeguridadRepository => _seguridadRepository ?? new SeguridadRepository(_context);
        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? new UsuarioRepository(_context);

        public IUsuarioCalificacionNpsRepository UsuarioCalificacionNpsRepository => _UsuarioCalificacionNpsRepository ?? new UsuarioCalificacionNpsRepository(_context);



        public IMapper Mapper => _mapper ?? new Mapper(_configurationProvider);
        public PaginationOptions PaginationOptions => _paginationOptions ?? new PaginationOptions();
        public PasswordOptions PasswordOptions => _passwordOptions ?? new PasswordOptions();
        public IUrlService UrlService => _urlService;
        public ITokenService TokenService => _tokenService ?? new TokenService(_configuration);
        public IPasswordService PasswordService => _passwordService ?? new PasswordService(_ipasswordOptions);

 

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
