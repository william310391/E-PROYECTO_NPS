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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<UsuarioDTO>> GetLoginByCredentials(UsuarioDTO usuarioDTO)
        {
            var response = new ApiResponse<UsuarioDTO>(new UsuarioDTO());
            var ent = await _unitOfWork.UsuarioRepository.GetLoginByCredentials(usuarioDTO);
            if (ent != null)
            {
                var dto = _unitOfWork.Mapper.Map<UsuarioDTO>(ent);
                if (_unitOfWork.PasswordService.check(dto.Contrasena, usuarioDTO.Contrasena))
                {
                    usuarioDTO = dto;
                    response = new ApiResponse<UsuarioDTO>(usuarioDTO);
                }
                else
                {
                    //throw new BusinessException("El usuario o contraseña ingresados son son incorrectas");
                    response.ResultadoDescripcion = "La contraseña ingresado es incorrecta";
                    response.ResultadoIndicador = 0;
                    response.CodigoHTTP = 401;
                }
            }
            else
            {
                response.ResultadoDescripcion = "El usuario ingresado es incorrecto";
                response.ResultadoIndicador = 0;
                response.CodigoHTTP = 400;
            }
            return response;
        }

        public async Task<ApiResponse<UsuarioDTO>> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Contrasena = _unitOfWork.PasswordService.Hash(usuarioDTO.Contrasena);
            var ent = _unitOfWork.Mapper.Map<Usuario>(usuarioDTO);
            await _unitOfWork.UsuarioRepository.Add(ent);
            await _unitOfWork.SaveChangesAsync();
            usuarioDTO = _unitOfWork.Mapper.Map<UsuarioDTO>(ent);
            var response = new ApiResponse<UsuarioDTO>(usuarioDTO);
            return response;
        }

        public async Task<ApiResponse<IEnumerable<UsuarioDTO>>> GetListUsuario(UsuarioDTO usuarioDTO)
        {
            var listUsuario = await _unitOfWork.UsuarioRepository.GetListUsuario(usuarioDTO);
            var ListUsuarioDTO = _unitOfWork.Mapper.Map<IEnumerable<UsuarioDTO>>(listUsuario);
            var response = new ApiResponse<IEnumerable<UsuarioDTO>>(ListUsuarioDTO);
            return response;
        }
    }
}
