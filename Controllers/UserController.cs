using Microsoft.AspNetCore.Mvc;
using Projeto_ecommerce.Models;
using Projeto_ecommerce.Repositorio;

namespace Projeto_ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly InterfaceUserRepositorio _userRepositorio;
        public UserController(InterfaceUserRepositorio userRepositorio) 
        {
            _userRepositorio = userRepositorio;
        }
        public ActionResult Index()
        {
            List<UserModel> users = _userRepositorio.Buscar();
            return View(users);
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        
        public ActionResult Perfil(int id)
        {
            UserModel user = _userRepositorio.BuscaPorId(id);
            return View(user);
        }
        
    }
    
}
