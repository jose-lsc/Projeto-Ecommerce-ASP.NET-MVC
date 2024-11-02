using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_ecommerce.Data;
using Projeto_ecommerce.Models;
using Projeto_ecommerce.Repositorio;

namespace Projeto_ecommerce.Controllers
{
    public class LoginController : Controller
    {
        private readonly BancoContext _context;
        
        public LoginController(BancoContext context) 
        {
            _context = context;
            
        }
        


        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Retorna a view de login
        }

        [HttpPost]
        public async Task<IActionResult> Logon(string login, string senha)
        {
            var usuario = _context.Users
                .Include(u => u.Contato)
                .FirstOrDefault(u => u.Nome == login && u.Senha == senha);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Contato", usuario.Contato.Contato),
                    new Claim("Tipo", usuario.Perfil.ToString()),
                    new Claim("Nome", usuario.Nome),
					new Claim("Id", usuario.Id.ToString()),
				};

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Home"); // Redireciona após o login
            }

            ModelState.AddModelError("", "Login ou senha inválidos");
            return RedirectToAction("Index", "Login"); // Retorna à view de login com erro
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var carrinhoItens = _context.Carrinho.ToList();
            _context.Carrinho.RemoveRange(carrinhoItens);
            _context.SaveChanges();

            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // Redireciona após o logout
        }
    }
}
