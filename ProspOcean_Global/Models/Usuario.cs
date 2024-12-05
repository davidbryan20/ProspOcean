using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProspOcean_Global.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario()
        {
            Favoritadas = new HashSet<Favoritadas>();
        }

        [Key]
        [Column("id_usu")]
        public int Id { get; set; }

        [Column("email_usu")]
        [Required(ErrorMessage = "O email é obrigatório ! ")]
        [StringLength(40)]
        public string Email { get; set; }

        [Column("senha_usu")]
        [StringLength(40)]
        [Required(ErrorMessage = "A senha é obrigatória ! ")]
        public string Senha { get; set; }

        [Column("nome_usu")]
        [StringLength(40)]
        [Required(ErrorMessage = "O nome é obrigatório ! ")]
        public string Nome { get; set; }

        public virtual ICollection<Favoritadas> Favoritadas { get; set; }
    }

}
