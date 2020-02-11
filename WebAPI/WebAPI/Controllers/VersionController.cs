using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Version")]
    public class VersionController : ApiController
    {
        #region Controller for GET Version

        // GET api/Version/GetVersion
        [AllowAnonymous]
        [HttpGet]
        [Route("GetVersion")]
        public async Task<IHttpActionResult> GetVersion()
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