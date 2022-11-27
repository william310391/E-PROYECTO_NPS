using AppNet6.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Interfaces
{
    public interface ITokenService
    {
        string GenerarToken(SeguridadDTO seguridadDTO);
    }
}