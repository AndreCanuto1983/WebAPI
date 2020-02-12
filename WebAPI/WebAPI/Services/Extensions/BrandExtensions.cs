using WebAPI.Models;
using static WebAPI.FrontModels.BrandFrontModel;

namespace WebAPI.Services.Extensions
{
    public static class BrandExtensions
    {
        #region [ Entity2Front ]

        /// <summary>
        /// Formato de saída do back para o front
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GetOutBrandFrontModel BrandEntity2Front(this VehicleModels model)
        {
            return new GetOutBrandFrontModel()
            {
                id = model.id,
                name = model.marca
            };
        }

        #endregion
    }
}