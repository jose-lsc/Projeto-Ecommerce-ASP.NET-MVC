using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Repositorio
{
    public interface InterfaceContatoRepositorio
    {
        List<ContatoModel> Buscar();
        ContatoModel BuscaPorId(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        ContatoModel Apagar(ContatoModel contato);
    }
}
