using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto_ecommerce.Enums;

namespace Projeto_ecommerce.Models
{
    public class UserModel
    {
		[Key]
		public int Id { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Nome { get; set; }

        public int Id_contato { get; set; }
        [ForeignKey("Id_contato")]
        public ContatoModel Contato { get; set; }

        public string Senha { get; set; }
        public int cpf_cnpj { get; set; }

        public int Id_endereco { get; set; }
        [ForeignKey("Id_endereco")]
        public EnderecoModel Endereco { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}
