using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("tb_AnuncioWebmotors")]
    public class VehicleModel : ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [MaxLength(45)]
        public string marca { get; set; }

        [Required]
        [MaxLength(45)]
        public string modelo { get; set; }

        [Required]
        [MaxLength(45)]
        public string versao { get; set; }

        [Required]
        public int ano { get; set; }

        [Required]
        public int quilometragem { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string observacao { get; set; }
    }
}