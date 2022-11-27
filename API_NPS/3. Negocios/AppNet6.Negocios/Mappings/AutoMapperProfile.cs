using AppNet6.Core.DTOs;
using AppNet6.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Negocios.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Seguridad, SeguridadDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioCalificacionNps, UsuarioCalificacionNpsDTO>().ReverseMap();

        }
    }
}
