using System.ComponentModel.DataAnnotations;

namespace Projeto_ecommerce.Models
{
    public class EnderecoModel
    {
		[Key]
		public int Id { get; set; }
        public int Numero { get; set; }
        public int Cep{ get; set; }
        public ICollection<UserModel> User { get; set; }
    }
}
