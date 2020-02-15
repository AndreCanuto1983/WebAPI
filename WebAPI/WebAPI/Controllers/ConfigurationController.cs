using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Teste;
using Teste.Models;
using WebAPI.Common.Exceptions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Configuration")]
    public class ConfigurationController : ApiController
    {
        #region Configurations

        private ApplicationUserManager _userManager;

        public ConfigurationController()
        {
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // Nenhum erro ModelState disponível para envio; retorne um BadRequest vazio.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion

        #region Controller for Insert Configuration Admin

        /// <summary>
        /// POST api/Configuration/Admin
        /// Este controller faz insert das roles do usuário admin
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [Route("Admin")]
        public async Task<IHttpActionResult> ConfigurationAdmin()
        {
            try
            {
                RegisterBindingModel model = new RegisterBindingModel()
                {
                    Email = "admin@canuto.adm",
                    Password = "@adminCanuto8",
                    ConfirmPassword = "@adminCanuto8"
                };

                var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                               
                if (!result.Succeeded) return Ok(result);

                using (var context = new Context())
                {
                    var localUser = await context.Users.Where(u => u.UserName == "admin@canuto.adm").FirstOrDefaultAsync();

                    //if (await UserManager.IsInRoleAsync(localUser.Id, "Administrador"))
                    //{
                    //    await UserManager.AddToRoleAsync(localUser.Id, "Administrador");
                    //}
                }

                return Ok("Modo Admin configurado com sucesso!");
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