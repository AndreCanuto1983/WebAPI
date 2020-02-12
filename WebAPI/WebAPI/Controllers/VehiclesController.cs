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
        #region Controller for CRUD Vehicles

        /// <summary>
        /// POST api/Vehicle/IUVehicle
        /// Este controller faz insert e update, se mandar id = 0 insert, senão update       
        /// Não utilizei o [HttpPut] para atualizar pois, desta maneira economizo código
        /// Se quiser que valida o usuário para gravar, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]        
        [Route("IUVehicle")]
        public async Task<IHttpActionResult> IUVehicle([FromBody]VehicleFrontModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

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

        #region Controller for CRUD Vehicles

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

            try
            {
                if (id == 0) throw new CustomErrorException("O id deve ser maior que zero.");

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