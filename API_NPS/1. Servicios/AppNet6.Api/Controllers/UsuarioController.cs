using AppNet6.Core.DTOs;
using AppNet6.Core.QueryFilters;
using AppNet6.Core.Response;
using AppNet6.Negocios.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace AppNet6.ApiChat.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ProducesErrorResponseType(typeof(ApiResponse<List<string>>))]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public UsuarioController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        /// <summary>
        /// Valida usuario y contraseña de usuario para acceder al sistema
        /// </summary>
        /// <param name="usuarioDTO">Ingresar cuenta y contraseña del usuario</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetLoginByCredentials([CustomizeValidator(RuleSet = "Login")] UsuarioDTO usuarioDTO)
        {
            var response = await _unitOfWorkService.UsuarioService.GetLoginByCredentials(usuarioDTO);
            return StatusCode(response.CodigoHTTP, response);
        }
        /// <summary>
        /// registro del usuario de sistema
        /// </summary>
        /// <param name="usuarioDTO">Datos de registro del usuario</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            var response = await _unitOfWorkService.UsuarioService.RegistrarUsuario(usuarioDTO);
            return StatusCode(response.CodigoHTTP, response);
        }



        [Authorize]
        [HttpPost(Name = nameof(GetListUsuario))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UsuarioDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetListUsuario(UsuarioDTO usuarioDTO)
        {        
            var response = await _unitOfWorkService.UsuarioService.GetListUsuario(usuarioDTO);
            return StatusCode(response.CodigoHTTP, response);
        }








    }
}
