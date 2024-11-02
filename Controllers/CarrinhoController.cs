using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_ecommerce.Data;
using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly BancoContext _bancoContext;
        public CarrinhoController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IActionResult Carrinho()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            List<CarrinhoModel> carrinho = _bancoContext.Carrinho
        .Include(c => c.Servicos) 
        .ToList();
            return View("~/Views/Home/Carrinho.cshtml", carrinho);
        }


        public IActionResult AdicionarServico(int id)
        {
            if (!User.Identity.IsAuthenticated)
                {
                return RedirectToAction("Index", "Login");
                }
            var servico = _bancoContext.Servicos.Find(id);
            var TipoExiste = _bancoContext.Carrinho.FirstOrDefault(
                a => a.Servicos != null && 
                a.Servicos.Tipo == servico.Tipo);

            if (TipoExiste != null)
            {
                if (TipoExiste.Servicos != null && TipoExiste.Servicos.Id == servico.Id)
                {
                    return RedirectToAction("DetalheServico", "Servico", new { tipo = servico.Tipo });
                }
                else
                {
                    _bancoContext.Carrinho.Remove(TipoExiste);

                }
            }
            CarrinhoModel carrinho = new CarrinhoModel()
            {
                ServicoId = id,
                Servicos = _bancoContext.Servicos.Find(id)
            };
            
            
            _bancoContext.Carrinho.Add(carrinho);
            _bancoContext.SaveChanges();
            
            return RedirectToAction("DetalheServico", "Servico", new {tipo = carrinho.Servicos.Tipo});
        }
        [HttpPost]
        public IActionResult RemoverServico(int id)
        {
            var item = _bancoContext.Carrinho.Find(id);
            if (item != null)
            {
                _bancoContext.Carrinho.Remove(item);
                _bancoContext.SaveChanges();
            }
            return RedirectToAction("Carrinho");
        }
        [HttpPost]
        public IActionResult Apagar()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
          
            var carrinhoItens = _bancoContext.Carrinho.ToList();
            _bancoContext.Carrinho.RemoveRange(carrinhoItens);
            _bancoContext.SaveChanges();

            return RedirectToAction("Carrinho");
        }
    }
}
