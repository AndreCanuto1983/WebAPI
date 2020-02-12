using WebAPI.FrontModels;
using WebAPI.Models;

namespace WebAPI.Services.Extensions
{
    /// <summary>
    /// Extensions tem o objetivo de filtrar e exibir um modelo específico o que entra ou sai no controller 
    /// </summary>
    public static class VehicleExtension
    {
        #region [ Front2Entity ]

        /// <summary>
        /// Formato de entrada do front para o back
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static VehicleModels VehicleFront2Entity(this VehicleFrontModel model)
        {
            return new VehicleModels()
            {
                id = model.id,
                marca = model.marca,
                modelo = model.modelo,
                versao = model.versao,
                ano = model.ano,
                quilometragem = model.quilometragem,
                observacao = model.observacao
            };
        }

        #endregion

        #region [ Entity2Front ]

        /// <summary>
        /// Formato de saída do back para o front
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static VehicleFrontModel VehicleEntity2Front(this VehicleModels model)
        {
            return new VehicleFrontModel()
            {
                id = model.id,
                marca = model.marca,
                modelo = model.modelo,
                versao = model.versao,
                ano = model.ano,
                quilometragem = model.quilometragem,
                observacao = model.observacao
            };
        }

        #endregion
    }
}