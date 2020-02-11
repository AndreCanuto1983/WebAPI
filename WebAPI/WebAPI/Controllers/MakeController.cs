using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Make")]
    public class MakeController : ApiController
    {
        #region Controller for GET Make

        // GET api/Make/GetMake
        [AllowAnonymous]
        [HttpGet]
        [Route("GetMake")]
        public async Task<IHttpActionResult> GetMake(string token)
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