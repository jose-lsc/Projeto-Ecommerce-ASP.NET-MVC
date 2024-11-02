﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Projeto_ecommerce.Data;

#nullable disable

namespace Projeto_ecommerce.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Projeto_ecommerce.Models.AssinaturaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoProtecao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeTitular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumeroCartao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ServicoId")
                        .HasColumnType("integer");

                    b.Property<string>("TipoPagamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Assinatura");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.CarrinhoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ServicoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServicoId");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.CompraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_servico")
                        .HasColumnType("integer");

                    b.Property<int>("Id_user")
                        .HasColumnType("integer");

                    b.Property<int>("ServicoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServicoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.ContatoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tipo_contato")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.EnderecoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cep")
                        .HasColumnType("integer");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.ServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Down")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.Property<string>("Up")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_contato")
                        .HasColumnType("integer");

                    b.Property<int>("Id_endereco")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("cpf_cnpj")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id_contato");

                    b.HasIndex("Id_endereco");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.CarrinhoModel", b =>
                {
                    b.HasOne("Projeto_ecommerce.Models.ServicoModel", "Servicos")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.CompraModel", b =>
                {
                    b.HasOne("Projeto_ecommerce.Models.ServicoModel", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_ecommerce.Models.UserModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.UserModel", b =>
                {
                    b.HasOne("Projeto_ecommerce.Models.ContatoModel", "Contato")
                        .WithMany("User")
                        .HasForeignKey("Id_contato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_ecommerce.Models.EnderecoModel", "Endereco")
                        .WithMany("User")
                        .HasForeignKey("Id_endereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.ContatoModel", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Projeto_ecommerce.Models.EnderecoModel", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
