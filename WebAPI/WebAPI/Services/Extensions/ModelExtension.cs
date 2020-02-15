using WebAPI.Models;
using static WebAPI.FrontModels.ModelFrontModel;

namespace WebAPI.Services.Extensions
{
    public static class ModelExtension
    {
        #region [ Entity2Front ]

        /// <summary>
        /// Formato de saída do back para o front
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GetOutModelFrontModel ModelEntity2Front(this VehicleModel model)
        {
            return new GetOutModelFrontModel()
            {
                id = model.id,
                name = model.modelo
            };
        }

        #endregion
    }
}