using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Projeto_ecommerce.Models
{
    public class CarrinhoModel
    {
        public int Id { get; set; }
      
        
        [ForeignKey("Servicos")]
        public int ServicoId { get; set; }
        public virtual ServicoModel? Servicos { get; set; }

    }
}
