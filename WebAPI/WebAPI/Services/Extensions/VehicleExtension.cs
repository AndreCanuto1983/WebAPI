using WebAPI.FrontModels;
using WebAPI.Models;

namespace WebAPI.Services.Extensions
{
    public static class VehicleExtension
    {
        #region [ Front2Entity ]

        public static VehicleModel Front2Entity(this VehicleFrontModel model)
        {
            return new VehicleModel()
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

        public static VehicleFrontModel Entity2Front(this VehicleModel model)
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