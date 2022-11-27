using AppNet6.Core.DTOs;
using AppNet6.Core.Entities;
using AppNet6.Core.Response;
using AppNet6.Infrestructuras.Interfaces;
using AppNet6.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Negocios.Services
{
    public class SeguridadService : ISeguridadService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeguridadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<SeguridadDTO>> AuthenticationApi(SeguridadDTO seguridadDTO)
        {
            var response = new ApiResponse<SeguridadDTO>(new SeguridadDTO());
            var seguridad = await _unitOfWork.SeguridadRepository.GetLoginByCredentials(seguridadDTO);

            if (seguridad != null)
            {
                var dto = _unitOfWork.Mapper.Map<SeguridadDTO>(seguridad);
                if (_unitOfWork.PasswordService.check(dto.Contrasena, seguridadDTO.Contrasena))
                {
                    seguridadDTO = dto;
                    seguridadDTO.Token = _unitOfWork.TokenService.GenerarToken(seguridadDTO);
                    response = new ApiResponse<SeguridadDTO>(seguridadDTO);
                }
                else
                {
                    //throw new BusinessException("Las credenciales para el token son invalidas");
                    response.ResultadoDescripcion = "La contraseña ingresado es incorrecta";
                    response.ResultadoIndicador = 0;
                    response.CodigoHTTP = 401;
                }
            }
            else
            {
                //throw new BusinessException("Las credenciales para el token son invalidas");
                response.ResultadoDescripcion = "El usuario ingresado es incorrecto";
                response.ResultadoIndicador = 0;
                response.CodigoHTTP = 400;
            }
            return response;
        }
        public async Task<ApiResponse<SeguridadDTO>> RegistrarUsuarioApi(SeguridadDTO seguridadDTO)
        {
            seguridadDTO.Contrasena = _unitOfWork.PasswordService.Hash(seguridadDTO.Contrasena);
            var seguridad = _unitOfWork.Mapper.Map<Seguridad>(seguridadDTO);
            await _unitOfWork.SeguridadRepository.Add(seguridad);
            await _unitOfWork.SaveChangesAsync();
            seguridadDTO = _unitOfWork.Mapper.Map<SeguridadDTO>(seguridad);
            var response = new ApiResponse<SeguridadDTO>(seguridadDTO);
            return response;
        }
    }
}
