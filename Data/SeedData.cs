using Microsoft.EntityFrameworkCore;
using Projeto_ecommerce.Enums;
using Projeto_ecommerce.Models;

namespace Projeto_ecommerce.Data
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BancoContext>();
                context.Database.EnsureCreated();

                if (!context.Users.Any() || !context.Servicos.Any())
                {
                    context.Users.AddRange(new List<UserModel>()
                    {
                        new UserModel
                        {
                         
                            Nome = "Admin",
                            Id_contato = 1,
                            Id_endereco = 1,
                            cpf_cnpj = 100,
                            Senha = "adm", // Lembre-se de hashear a senha corretamente em uma implementação real.
                            Perfil = PerfilEnum.Admin,
                            DataCadastro = DateTime.UtcNow
                        },
						new UserModel
						{

							Nome = "Cliente1",
							Id_contato = 2,
							Id_endereco = 2,
							cpf_cnpj = 200,
							Senha = "123", 
                            Perfil = PerfilEnum.Padrao,
                            DataCadastro = DateTime.UtcNow
                        },
						new UserModel
						{

							Nome = "Cliente2",
							Id_contato = 3,
							Id_endereco = 3,
							cpf_cnpj = 300,
							Senha = "123", 
                            Perfil = PerfilEnum.Padrao,
                            DataCadastro = DateTime.UtcNow
                        },

					});
                    context.Contatos.AddRange(new List<ContatoModel>()
                    {
						new ContatoModel
						{
							Contato = "Admin@email.com",
                            Tipo_contato = 1
						},
						new ContatoModel
						{
							Contato = "Cliente1@email.com",
							Tipo_contato = 1
						},
						new ContatoModel
						{
							Contato = "(14)99000-2222",
							Tipo_contato = 2
						}

					});
                    context.Enderecos.AddRange(new List<EnderecoModel>()
                    {
                        new EnderecoModel
                        {
                            Cep = 0,
                            Numero = 0
                        },
						new EnderecoModel
						{
							Cep = 17511333,
							Numero = 288
						},
						new EnderecoModel
						{
							Cep = 65433476,
							Numero = 777
						},
					});
                    context.Assinatura.AddRange(new List<AssinaturaModel>()
                    {
                        new AssinaturaModel
                        {
                            Id = 1,
                            NomeTitular = "Cliente1",
                            NumeroCartao = "123",
                            CodigoProtecao = "123",
                            TipoPagamento = "Debito"
                        },
                        new AssinaturaModel
                        {
                            Id = 2,
                            NomeTitular = "Cliente2",
                            NumeroCartao = "123",
                            CodigoProtecao = "123",
                            TipoPagamento = "Credito"
                        },
                        new AssinaturaModel
                        {
                            Id = 3,
                            NomeTitular = "Ruffs",
                            NumeroCartao = "777",
                            CodigoProtecao = "777",
                            TipoPagamento = "Debito"
                        }
                    });
					context.Servicos.AddRange(new List<ServicoModel>()
                    {
                        new ServicoModel
                        {
							Descricao = "Internet 50mega",
							Tipo = 1,
							Preco = 100,
							Up = "-",
							Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },
                        new ServicoModel
                        {
                            Descricao = "Internet 100mega",
                            Tipo = 1,
                            Preco = 150,
                            Up = "-",
                            Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },
                        new ServicoModel
                        {
                            Descricao = "Internet 200mega",
                            Tipo = 1,
                            Preco = 250,
                            Up = "-",
                            Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },
                        new ServicoModel
                        {
                            Descricao = "Televisão Basico",
                            Tipo = 2,
                            Preco = 200,
                            Up = "-",
                            Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },
                        new ServicoModel
                        {
                            Descricao = "Televisão Plus",
                            Tipo = 2,
                            Preco = 350.50,
                            Up = "-",
                            Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },
                        new ServicoModel
                        {
                            Descricao = "Televisão Premium",
                            Tipo = 2,
                            Preco = 499.99,
                            Up = "-",
                            Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },
                        new ServicoModel
                        {
                            Descricao = "Telefone 8Gb dados/mês",
                            Tipo = 3,
                            Preco = 25,
                            Up = "-",
                            Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },
                        new ServicoModel
                        {
                            Descricao = "Telefone 16Gb dados/mês",
                            Tipo = 3,
                            Preco = 35,
                            Up = "-",
                            Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },
                        new ServicoModel
                        {
                            Descricao = "Telefone 32Gb dados/mês",
                            Tipo = 3,
                            Preco = 45.90,
                            Up = "-",
                            Down = "Down",
                            DataCadastro = DateTime.UtcNow
                        },

                    });
                    context.SaveChanges();
                }
            } 
        }

    }
}
