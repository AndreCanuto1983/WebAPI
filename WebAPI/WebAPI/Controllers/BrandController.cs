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
    [RoutePrefix("api/Brand")]
    public class BrandController : ApiController
    {
        #region Controller for GET Brand

        /// <summary>
        /// GET api/Brand/GetBrand
        /// Não entendi o contexto do nome "Brand" mais vou seguir o padrão de vocês
        /// Se quiser validar o usuário para get, comente o "[AllowAnonymous]" abaixo
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [HttpGet]
        [Route("GetBrand")]
        public async Task<IHttpActionResult> GetBrand([FromUri]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                VehicleService vehicleService = new VehicleService();
                IEnumerable<VehicleModel> vehicle = await vehicleService.GetVehicle(id);
                return Ok(vehicle.Select(v => v.BrandEntity2Front()));
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