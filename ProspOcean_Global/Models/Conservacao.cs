using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProspOcean_Global.Models
{
    [Table("Conservacao")]
    public class Conservacao
    {
        [Key]
        [Column("id_cons")]
        public int Id { get; set; }

        [Column("titulo_cons")]
        [StringLength(30)]
        [Required(ErrorMessage = "O titulo é obrigatório !")]
        public string Titulo { get; set; }

        [Column("desc_cons")]
        [StringLength(200)]
        [Required(ErrorMessage = "A descrição é obrigatório !")]
        public string Descricao { get; set; }

        [Column("dt_inicio")]
        [Required(ErrorMessage = "A data de inicio é obrigatório !")]
        public DateTime DataInicio { get; set; }

        [Column("contato_cons")]
        [StringLength(40)]
        [Required(ErrorMessage = "O contato é obrigatório !")]
        public string Contato { get; set; }

        [Column("Especie_id_esp")]
        public int EspecieId { get; set; }

        [ForeignKey("EspecieId")]
        public virtual Especie Especie { get; set; }
    }
}
