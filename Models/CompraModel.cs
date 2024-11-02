namespace Projeto_ecommerce.Models
{
    public class CompraModel
    {
        public int Id { get; set; }
        public int Id_user { get; set; }
        public int Id_servico { get; set; }
        public DateTime DataCompra { get; set; }
        public virtual UserModel Usuario { get; set; } 
        public virtual ServicoModel Servico { get; set; }
    }
}
