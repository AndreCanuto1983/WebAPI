using System.ComponentModel.DataAnnotations;

namespace WebAPI.FrontModels
{
    public class VehicleFrontModel
    {
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
}