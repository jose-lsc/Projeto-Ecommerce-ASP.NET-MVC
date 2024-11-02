namespace Projeto_ecommerce.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
		public int Tipo { get; set; }
		public double Preco { get; set; }
        public string Up{ get; set; }
        public string Down { get; set; }
		public DateTime DataCadastro { get; set; }
        
    }
}
