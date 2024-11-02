using Projeto_ecommerce.Data;
using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Repositorio
{
    public class UserRepositorio : InterfaceUserRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UserRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<UserModel> Buscar()
        {
            return _bancoContext.Users.ToList();
        }
        public UserModel BuscaPorId(int id)
        {
            return _bancoContext.Users.Find(id);
        }
    }
}
