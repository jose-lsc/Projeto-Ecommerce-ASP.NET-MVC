using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Projeto_ecommerce.Data;
using Projeto_ecommerce.Migrations;
using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Controllers
{
    public class CompraController : Controller
    {
        private readonly BancoContext _context;

        public CompraController(BancoContext context)
        {
            _context = context;
        }
        int id_user = 0;
        public ActionResult Assinar(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var Id = User.FindFirst("Id")?.Value;

                if (Id != null)
                {
                    id_user = int.Parse(Id);
                    var JaPossui =  _context.Compras.Any(a =>
                    a.Id_user == id_user &&
                    a.Id_servico == id);
                    if (JaPossui )
                    {
                        ServicoModel temp = _context.Servicos.Where(a=> a.Id == id).FirstOrDefault();
                        TempData["Mensagem"] = "Você já possui esse serviço!";
                        return RedirectToAction("DetalheServico", "Servico",new { tipo = temp.Tipo });
                    }

                }
                var model = new AssinaturaModel
                {
                    ServicoId = id // Atribuindo o ID do serviço
                };
                

                return View("~/Views/User/Assinatura.cshtml", model);
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> ConfirmarCompra(AssinaturaModel model)
        {
            var Id = User.FindFirst("Id")?.Value;
            ServicoModel temp = _context.Servicos.Where(a => a.Id == model.ServicoId).FirstOrDefault();
            if (Id != null)
            {
                id_user = int.Parse(Id);
            }
            if (_context.Compras.Any(s => s.Id_user == id_user && s.Servico.Tipo == temp.Tipo))

            {
                CompraModel compra = _context.Compras.Where(s => s.Id_user == id_user && s.Servico.Tipo == temp.Tipo).FirstOrDefault();

                await this.SubCompra(id_user, model.ServicoId,compra.Id );
                return RedirectToAction("Index", "Home");
            }
            
            if ( await _context.Assinatura.AnyAsync(a => 
                a.NomeTitular == model.NomeTitular &&
                a.NumeroCartao == model.NumeroCartao &&
                a.CodigoProtecao == model.CodigoProtecao &&
                a.TipoPagamento == model.TipoPagamento))
                
            {
                await this.Comprar(id_user, model.ServicoId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                return RedirectToAction("Assinar","Compra", new { id = model.ServicoId });
                
            }

        }
        public async Task<ActionResult> Comprar(int Id_User, int? Id_Servico)
        {
            var usuario = await _context.Users.FindAsync(Id_User);
            var servico = await _context.Servicos.FindAsync(Id_Servico);

            if (usuario == null || servico == null)
            {
                return NotFound();
            }

            var compra = new CompraModel
            {
                Id_user = Id_User,
                Id_servico = servico.Id,
                Usuario = usuario,
                Servico = servico
            };
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
        public async Task<ActionResult> SubCompra(int Id_User, int? Id_Servico, int Id_Compra)
        {
            var usuario = await _context.Users.FindAsync(Id_User);
            var servico = await _context.Servicos.FindAsync(Id_Servico);
            var compra = await _context.Compras.FindAsync(Id_Compra);
            if (usuario == null || servico == null || compra == null)
            {
                return NotFound();
            }
            compra.Id_servico = servico.Id;
            compra.Servico = servico;
            await _context.SaveChangesAsync();

            return RedirectToAction("DetalheServico", "Servico", new { tipo = servico.Tipo });
        }
    }
}
