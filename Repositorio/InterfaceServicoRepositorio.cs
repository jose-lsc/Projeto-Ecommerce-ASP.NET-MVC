using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Repositorio
{
    public interface InterfaceServicoRepositorio
    {
        List<ServicoModel> Buscar();
        ServicoModel BuscaPorId(int id);
        List<ServicoModel> BuscaPorTipo(int tipo);
        ServicoModel Adicionar(ServicoModel servico);
        ServicoModel Editar(ServicoModel servico);
        ServicoModel Apagar(ServicoModel servico);
        
        
    }
}
