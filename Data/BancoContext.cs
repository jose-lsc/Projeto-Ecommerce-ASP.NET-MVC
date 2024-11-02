using Microsoft.EntityFrameworkCore;
using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ServicoModel> Servicos { get; set; }
		public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<CompraModel> Compras { get; set; }
        public DbSet<AssinaturaModel> Assinatura { get; set; }
        public DbSet<CarrinhoModel> Carrinho { get; set; }
            
	}
}
