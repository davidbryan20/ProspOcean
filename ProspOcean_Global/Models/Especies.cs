using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProspOcean_Global.Models
{
    [Table("Especie")]
    public class Especie
    {
        public Especie()
        {
            Favoritadas = new HashSet<Favoritadas>();
            Conservacoes = new HashSet<Conservacao>();
        }

        [Key]
        [Column("id_esp")]
        public int Id { get; set; }

        [Column("nm_commum_esp")]
        [StringLength(40)]
        [Required(ErrorMessage = "O nome comum é obrigatório !")]
        public string NomeComum { get; set; }

        [Column("nm_cientifico_esp")]
        [StringLength(40)]
        [Required(ErrorMessage = "O nome cientifico é obrigatório !")]
        public string NomeCientifico { get; set; }

        [Column("desc_esp")]
        [StringLength(200)]
        [Required(ErrorMessage = "A Descrição é obrigatória !")]
        public string Descricao { get; set; }

        [Column("habitat_esp")]
        [StringLength(100)]
        [Required(ErrorMessage = "O Habitat é obrigatório !")]
        public string Habitat { get; set; }

        public virtual ICollection<Favoritadas> Favoritadas { get; set; }
        public virtual ICollection<Conservacao> Conservacoes { get; set; }
    }
}
