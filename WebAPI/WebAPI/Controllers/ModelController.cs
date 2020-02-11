using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Model")]
    public class ModelController : ApiController
    {
        #region Controller for GET Model

        // GET api/Model/GetModel
        [AllowAnonymous]
        [HttpGet]
        [Route("GetModel")]
        public async Task<IHttpActionResult> GetModel(string token)
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