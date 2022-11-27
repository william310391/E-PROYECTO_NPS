using AppNet6.Core.DTOs;
using AppNet6.Core.Enumerations;
using AppNet6.Core.Response;
using AppNet6.Negocios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace AppNet6.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ProducesErrorResponseType(typeof(ApiResponse<List<string>>))]
    [ApiController]
    public class UsuarioCalificacionNpsController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public UsuarioCalificacionNpsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        /// <summary>
        /// Registrar Calificon por usuario
        /// </summary>
        /// <param name="UsuarioCalificacionNpsDTO">Registrar Calificon por usuario</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Name = nameof(RegistrarUsuarioCalificionNps))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioCalificacionNpsDTO>))]
        public async Task<IActionResult> RegistrarUsuarioCalificionNps(UsuarioCalificacionNpsDTO usuarioCalificacionNpsDTO)
        {
            var response = await _unitOfWorkService.UsuarioCalificacionNpsService.RegistrarUsuarioCalificionNps(usuarioCalificacionNpsDTO);
            return StatusCode(response.CodigoHTTP, response);
         
        }

        /// <summary>
        /// ResultadosNPS
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost(Name = nameof(ResultadosNPS))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ResultadosEncuentaNpsDTO>))]
        public async Task<IActionResult> ResultadosNPS()
        {
            var response = await _unitOfWorkService.UsuarioCalificacionNpsService.ResultadosNPS();
            return StatusCode(response.CodigoHTTP, response);
        }

 


    }
}
