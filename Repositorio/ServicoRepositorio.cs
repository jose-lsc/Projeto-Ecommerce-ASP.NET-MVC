using Projeto_ecommerce.Data;
using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Repositorio
{
    public class ServicoRepositorio : InterfaceServicoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ServicoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ServicoModel> Buscar()
        {
            return _bancoContext.Servicos.ToList();
        }

        public ServicoModel BuscaPorId(int id)
        {
            return _bancoContext.Servicos.Find(id);
        }
        public List<ServicoModel> BuscaPorTipo(int tipo)
        {
            return _bancoContext.Servicos.Where(s => s.Tipo == tipo).ToList();
        }

        public ServicoModel Adicionar(ServicoModel servico)
        {
            _bancoContext.Servicos.Add(servico);
            _bancoContext.SaveChanges();
            return servico;
        }

        public ServicoModel Editar(ServicoModel servico)
        {
            _bancoContext.Servicos.Update(servico);
            _bancoContext.SaveChanges();
            return servico;
        }
        public ServicoModel Apagar(ServicoModel servico)
        {
            _bancoContext.Servicos.Remove(servico);
            _bancoContext.SaveChanges();
            return servico;
        } 

    }
}
