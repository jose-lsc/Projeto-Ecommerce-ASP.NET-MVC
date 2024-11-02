using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto_ecommerce.Data;
using Projeto_ecommerce.Models;
using Projeto_ecommerce.Repositorio;

namespace Projeto_ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly InterfaceServicoRepositorio _servicoRepositorio;
        public HomeController(InterfaceServicoRepositorio servicoRepositorio)
        {
            _servicoRepositorio = servicoRepositorio;
        }
        public IActionResult Index()
        {
            List<ServicoModel> servico =  _servicoRepositorio.Buscar();
            return View(servico);
        }
        public IActionResult Carrinho()
        {
            return View();
        }
        public IActionResult Suporte()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
