namespace Projeto_ecommerce.Models
{
    public class AssinaturaModel
    {
        public int Id { get; set; }
        public string NomeTitular { get; set; }
        public string NumeroCartao { get; set; }
        public string CodigoProtecao { get; set; }
        public string TipoPagamento { get; set; }
        public int? ServicoId { get; set; } // Propriedade para o ID do serviço

    }
}
