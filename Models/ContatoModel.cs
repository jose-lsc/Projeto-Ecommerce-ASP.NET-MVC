using System.ComponentModel.DataAnnotations;

namespace Projeto_ecommerce.Models
{
    public class ContatoModel
    {
        [Key]
        public int Id { get; set; }
        public string Contato { get; set; }
        public int Tipo_contato {  get; set; }
        public ICollection<UserModel> User { get; set; }
    }
}
