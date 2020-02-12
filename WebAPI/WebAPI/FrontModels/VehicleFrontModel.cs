using System.ComponentModel.DataAnnotations;

namespace WebAPI.FrontModels
{
    /// <summary>
    /// Padronização para insert e update
    /// </summary>
    public class VehicleFrontModel
    {
        //passe o id > 0 para atualizar e id = 0 para inserir
        public int id { get; set; }

        [MaxLength(45)]
        [Required(ErrorMessage = "O campo marca é obrigatório")]
        public string marca { get; set; }

        [MaxLength(45)]
        [Required(ErrorMessage = "O campo modelo é obrigatório")]
        public string modelo { get; set; }

        [MaxLength(45)]
        [Required(ErrorMessage = "O campo versao é obrigatório")]
        public string versao { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatório")]
        public int ano { get; set; }

        [Required(ErrorMessage = "O campo quilometragem é obrigatório")]
        public int quilometragem { get; set; }

        [Required(ErrorMessage = "O campo observacao é obrigatório")]
        public string observacao { get; set; }
    }

    public class GetOutVehicleFrontModel
    {
        public int id { get; set; }
               
        public string marca { get; set; }

        public string modelo { get; set; }

        public string versao { get; set; }
                
        public int ano { get; set; }
                
        public int quilometragem { get; set; }
                
        public string observacao { get; set; }
    }
}