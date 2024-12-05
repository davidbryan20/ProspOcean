using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProspOcean_Global.Models
{
    [Table("Favoritadas")]
    public class Favoritadas
    {
        [Key]
        [Column("id_fav")]
        public int Id { get; set; }

        [Column("Usuario_id_usu")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [Column("Especie_id_esp")]
        public int EspecieId { get; set; }

        [ForeignKey("EspecieId")]
        public virtual Especie Especie { get; set; }
    }

}
