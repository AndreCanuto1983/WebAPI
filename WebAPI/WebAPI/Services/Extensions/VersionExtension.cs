using WebAPI.Models;
using static WebAPI.FrontModels.VersionFrontModel;

namespace WebAPI.Services.Extensions
{
    public static class VersionExtension
    {
        #region [ Entity2Front ]

        /// <summary>
        /// Formato de saída do back para o front
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GetOutVersionFrontModel VersionEntity2Front(this VehicleModel model)
        {
            return new GetOutVersionFrontModel()
            {
                id = model.id,
                name = model.versao
            };
        }

        #endregion

    }
}