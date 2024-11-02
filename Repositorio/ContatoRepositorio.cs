using Microsoft.EntityFrameworkCore;
using Projeto_ecommerce.Data;
using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Repositorio
{
    public class ContatoRepositorio : InterfaceContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> Buscar()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel BuscaPorId(int id)
        {
            return _bancoContext.Contatos.Find(id);
            // firstdefault é melhor para busca além da chave primaria
            //return _bancoContext.Contatos.FirstOrDefault(c => c.ID == id);
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        public ContatoModel Editar(ContatoModel contato)
        {
            _bancoContext.Contatos.Update(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        public ContatoModel Apagar(ContatoModel contato)
        {
            _bancoContext.Contatos.Remove(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
