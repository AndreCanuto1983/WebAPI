using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Common.Exceptions;
using WebAPI.FrontModels;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Services.Extensions;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Vehicle")]
    public class VehiclesController : ApiController
    {
        #region Controller for Insert Vehicles

        /// <summary>
        /// POST api/Vehicle/InsertVehicle
        /// Este controller faz insert do veículo
        /// Se quiser que valida o usuário para gravar, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]        
        [Route("InsertVehicle")]
        public async Task<IHttpActionResult> InsertVehicle([FromBody]VehicleFrontModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (model.id > 0) return Ok("Para atualizar o registro, utilize o protocolo PUT");
            
            try
            {
                var entity = model.VehicleFront2Entity();

                VehicleModels vehicle = null;

                VehicleService vehicleService = new VehicleService();
                vehicle = await vehicleService.InsertOrUpdate(entity);

                return Ok("ok");
            }
            catch (CustomErrorException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

        #region Controller for Update Vehicles

        /// <summary>
        /// POST api/Vehicle/UpdateVehicle
        /// Este controller faz update do veículo       
        /// Se quiser que valida o usuário para gravar, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut]
        [Route("UpdateVehicle")]
        public async Task<IHttpActionResult> UpdateVehicle([FromBody]VehicleFrontModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (model.id <= 0) return Ok("Para inserir o registro, utilize o protocolo POST");

            try
            {
                var entity = model.VehicleFront2Entity();

                VehicleModels vehicle = null;

                VehicleService vehicleService = new VehicleService();
                vehicle = await vehicleService.InsertOrUpdate(entity);

                return Ok("ok");
            }
            catch (CustomErrorException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

        #region Controller for Partial Update Vehicles

        /// <summary>
        /// POST api/Vehicle/PartialUpdateVehicle
        /// Este controller faz update parcial do veículo       
        /// Se quiser que valida o usuário para gravar, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPatch]
        [Route("PartialUpdateVehicle")]
        public async Task<IHttpActionResult> PartialUpdateVehicle([FromBody]PartialVehicleFrontModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (model.id <= 0) return Ok("Para inserir o registro, utilize o protocolo POST");

            try
            {
                var entity = model.PartialVehicleFront2Entity();

                VehicleModels vehicle = null;

                VehicleService vehicleService = new VehicleService();
                vehicle = await vehicleService.PartialUpdate(entity);

                return Ok("ok");
            }
            catch (CustomErrorException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

        #region Controller for Delete Vehicles

        /// <summary>
        /// POST api/Vehicle/DeleteVehicle     
        /// Se quiser validar o usuário para deletar, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpDelete]
        [Route("DeleteVehicle")]
        public async Task<IHttpActionResult> DeleteVehicle([FromUri]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id <= 0) return Ok("Para deletar o registro, o id deve ser maior que zero");

            try
            {
                using (var context = new Context())
                {
                    if (context.Vehicle.AsNoTracking().Any(a => a.id == id))
                    {
                        VehicleService vehicleService = new VehicleService();                        
                        return Ok(await vehicleService.DeleteVehicle(id));
                    }
                    else
                    {
                        return Ok("Nada para excluir");
                    }
                }
            }
            catch (CustomErrorException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

        #region Controller for GET Vehicles

        /// <summary>
        /// GET api/Vehicle/GetVehicle
        /// Se quiser validar o usuário para get, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("GetVehicle")]
        public async Task<IHttpActionResult> GetVehicle([FromUri]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                VehicleService vehicleService = new VehicleService();
                IEnumerable<VehicleModels> vehicle = await vehicleService.GetVehicle(id);
                return Ok(vehicle.Select(v => v.VehicleEntity2Front()));
            }
            catch (CustomErrorException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}