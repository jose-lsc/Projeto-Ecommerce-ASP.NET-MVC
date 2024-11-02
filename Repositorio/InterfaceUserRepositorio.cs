using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Repositorio
{
    public interface InterfaceUserRepositorio
    {
        List<UserModel> Buscar();
        UserModel BuscaPorId(int id);
    }
}
