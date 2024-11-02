using Microsoft.AspNetCore.Mvc;
using Projeto_ecommerce.Models;
using Projeto_ecommerce.Repositorio;

namespace Projeto_ecommerce.Controllers
{
    public class ServicoController : Controller
    {
        private readonly InterfaceServicoRepositorio _servicoRepositorio;
        public ServicoController (InterfaceServicoRepositorio servicoRepositorio)
        {
            _servicoRepositorio = servicoRepositorio;
        }


        public IActionResult Index()
        {
            List<ServicoModel> servicos = _servicoRepositorio.Buscar();
            return View(servicos);
        }

        public IActionResult DetalheServico(int tipo)
        {
            List<ServicoModel> servicos = _servicoRepositorio.BuscaPorTipo(tipo);
            return View(servicos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ServicoModel servico= _servicoRepositorio.BuscaPorId(id);
            if (servico == null)
            {
                return NotFound();
            }
            return View(servico);
        }
        public ActionResult ApagarConfirmacao(int id)
        {
            ServicoModel servico = _servicoRepositorio.BuscaPorId(id);
            if (servico == null)
            {
                return NotFound();
            }
            return View(servico);
        }

        [HttpPost]
        public IActionResult Criar(ServicoModel servico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicoRepositorio.Adicionar(servico);
                    TempData["msgSucesso"] = "Cadastro Concluido ";
                    return RedirectToAction("Index");
                }
                return View(servico);
            }
            catch (System.Exception erro)
            {
                TempData["msgErro"] = $"Não conseguimos cadastrar o contato, {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
