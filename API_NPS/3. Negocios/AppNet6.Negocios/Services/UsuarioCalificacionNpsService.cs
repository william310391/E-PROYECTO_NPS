using AppNet6.Core.DTOs;
using AppNet6.Core.Entities;
using AppNet6.Core.Response;
using AppNet6.Infrestructuras.Interfaces;
using AppNet6.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Negocios.Services
{
    public class UsuarioCalificacionNpsService: IUsuarioCalificacionNpsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioCalificacionNpsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<UsuarioCalificacionNpsDTO>> RegistrarUsuarioCalificionNps(UsuarioCalificacionNpsDTO usuarioCalificacionNpsDTO)
        {
            //var entidad = _unitOfWork.Mapper.Map<UsuarioCalificacionNps>(usuarioCalificacionNpsDTO);
            var data = await _unitOfWork.UsuarioCalificacionNpsRepository.GetUsuarioCalificonPorUsuario(usuarioCalificacionNpsDTO);
            string calificacionDescripcion = "";


            if (usuarioCalificacionNpsDTO.CalificacionPuntuacion <= 6)
            {
                calificacionDescripcion = "Detractores";
            }
            else if (usuarioCalificacionNpsDTO.CalificacionPuntuacion >= 7 && usuarioCalificacionNpsDTO.CalificacionPuntuacion <= 8)
            {
                calificacionDescripcion = "Neutros";
            }
            else if (usuarioCalificacionNpsDTO.CalificacionPuntuacion >= 9 && usuarioCalificacionNpsDTO.CalificacionPuntuacion <= 10)
            {
                calificacionDescripcion = "Promotores";
            };
            CultureInfo cultureInfo = new CultureInfo("fr-FR");

            DateTime fecha = DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);


            if (data != null) {

                data.CalificacionPuntuacion = usuarioCalificacionNpsDTO.CalificacionPuntuacion;
                data.CalificacionDescripcion = calificacionDescripcion;
                data.FechaRegistro = DateTime.Now;

                data.FechaModificacion = DateTime.Now;
                await _unitOfWork.UsuarioCalificacionNpsRepository.Update(data); ;
            }
            else
            {
                data = new UsuarioCalificacionNps();
                data.IdUsuario = usuarioCalificacionNpsDTO.IdUsuario;
                data.IndActivo = true;
                data.FechaRegistro = DateTime.Now;
                data.FechaModificacion = DateTime.Now;
                data.IdUsuarioRegistro = 1;
                data.IdUsuarioModificacion = 1;
                data.CalificacionPuntuacion = usuarioCalificacionNpsDTO.CalificacionPuntuacion;
                data.CalificacionDescripcion = calificacionDescripcion;

                await _unitOfWork.UsuarioCalificacionNpsRepository.Add(data);

            }

            await _unitOfWork.SaveChangesAsync();
            usuarioCalificacionNpsDTO = _unitOfWork.Mapper.Map<UsuarioCalificacionNpsDTO>(data);
            var response = new ApiResponse<UsuarioCalificacionNpsDTO>(usuarioCalificacionNpsDTO);
            return response;
        }

        public async Task<ApiResponse<ResultadosEncuentaNpsDTO>> ResultadosNPS()
        {
            var dto = new ResultadosEncuentaNpsDTO();
            var dtoLista = new List<ResultadosEncuentaNpsDTO.DatoUsuarioDTO>();
            var data =  _unitOfWork.UsuarioCalificacionNpsRepository.GetAll();

            if (data != null)
            {

                int cantidadDetractores = 0;
                int cantidadPromotores = 0;

                foreach (UsuarioCalificacionNps item in data)
                {
                    var ent =new ResultadosEncuentaNpsDTO.DatoUsuarioDTO();
                    var usu = await _unitOfWork.UsuarioRepository.GetUsuarioByIdUsuario(item.IdUsuario);
                    ent.idUsuario = item.IdUsuario;
                    ent.Nombres = usu.Nombres;
                    ent.Apellidos = usu.Apellidos;
                    ent.CalificacionDescripcion = item.CalificacionDescripcion;
                    ent.CalificacionPuntuacion = item.CalificacionPuntuacion;
                    dtoLista.Add(ent);


                    if (item.CalificacionDescripcion == "Detractores") {
                        cantidadDetractores += 1;
                    }

                    if (item.CalificacionDescripcion == "Promotores")
                    {
                        cantidadPromotores += 1;
                    }

                }
                dto.ListaUsuario = dtoLista;
                dto.cantidadEncuestados = data.Count();
                dto.cantidadDetractores=cantidadDetractores;
                dto.cantidadPromotores = cantidadPromotores;
                dto.NPS = (dto.cantidadPromotores - dto.cantidadDetractores) / dto.cantidadEncuestados * 100;

            }

       
            var response = new ApiResponse<ResultadosEncuentaNpsDTO>(dto);
            return response;

        }

    }
}
