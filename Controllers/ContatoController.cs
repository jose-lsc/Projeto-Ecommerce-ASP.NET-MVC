using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_ecommerce.Models;
using Projeto_ecommerce.Repositorio;

namespace Projeto_ecommerce.Controllers
{
    public class ContatoController : Controller
    {
        private readonly InterfaceContatoRepositorio _contatoRepositorio;
        public ContatoController(InterfaceContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public ActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.Buscar(); 

            return View(contatos);
        }

        public ActionResult Criar()
        {
            return View();
           
        }

        public ActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscaPorId(id);
            if (contato == null)
            {
                return NotFound(); 
            }
            return View(contato);
        }
        public ActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscaPorId(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }
        [HttpPost]
        public ActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["msgSucesso"] = "Cadastro Concluido ";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["msgErro"] = $"Não conseguimos cadastrar o contato, {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Editar(contato);
                    TempData["msgSucesso"] = "Edição Concluida ";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["msgErro"] = $"Não conseguimos editar o contato, {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public ActionResult ApagarController(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscaPorId(id);
            try
            {
                if (contato == null)
                {
                    return NotFound();
                }
                TempData["msgSucesso"] = "Contato Excluido ";
                _contatoRepositorio.Apagar(contato);
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["msgErro"] = $"Não conseguimos excluir o contato, {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        
        
    }
}
