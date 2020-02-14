using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Common.Exceptions;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Services.Extensions;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Model")]
    public class ModelController : ApiController
    {
        #region Controller for GET Model

        /// <summary>
        /// GET api/Model/GetModel
        /// Se quiser validar o usuário para get, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpGet]
        [Route("GetModel")]
        public async Task<IHttpActionResult> GetModel([FromUri]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                VehicleService vehicleService = new VehicleService();
                IEnumerable<VehicleModels> vehicle = await vehicleService.GetVehicle(id);
                return Ok(vehicle.Select(v => v.ModelEntity2Front()));
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