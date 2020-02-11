using System;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.FrontModels;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Vehicle")]
    public class VehiclesController : ApiController
    {
        #region Controller for CRUD Vehicles

        // POST api/Vehicle/CudVehicle
        [AllowAnonymous]
        [HttpPost]
        [Route("CudVehicle")]
        public async Task<IHttpActionResult> CudVehicle([FromBody]VehicleFrontModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                Teste_WebMotorsModel teste_WebModetorModel = null;

                VehicleService vehicleService = new VehicleService();
                await vehicleService.CudVehicle(model);
              
                return Ok("ok");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion

        #region Controller for GET Vehicles

        // GET api/Vehicle/CudVehicle/GetVehicle
        [AllowAnonymous]
        [HttpGet]
        [Route("GetVehicle")]
        public async Task<IHttpActionResult> GetVehicle(string token)
        {
            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}