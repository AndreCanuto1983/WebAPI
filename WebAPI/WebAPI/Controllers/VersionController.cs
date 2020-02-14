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
    [RoutePrefix("api/Version")]
    public class VersionController : ApiController
    {
        #region Controller for GET Version

        /// <summary>
        /// GET api/Version/GetVersion
        /// Se quiser validar o usuário para get, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpGet]
        [Route("GetVersion")]
        public async Task<IHttpActionResult> GetVersion([FromUri]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                VehicleService vehicleService = new VehicleService();
                IEnumerable<VehicleModels> vehicle = await vehicleService.GetVehicle(id);
                return Ok(vehicle.Select(v => v.VersionEntity2Front()));
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