using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Estacionamento.Domain.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Pessoa_Juridica.Entity;
using Estacionamento.Domain.Telefones_Pessoa_Juridica;
using Estacionamento.Infra.Pessoa_Fisica.Entity;
using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-SN81A5J\SQLEXPRESS;Initial Catalog=Estacionamento;Integrated Security=True");
        }

        public DbSet<EmailsPessoaJuridicaEntity> EmailsPessoaJuridica { get; set; }
        public DbSet<EmailsPessoaFisicaEntity> EmailsPessoaFisica { get; set; }
        public DbSet<PessoaFisicaEntity> PessoaFisica { get; set; }
        public DbSet<PessoaJuridicaEntity> PessoaJuridica { get; set; }
        public DbSet<TelefonesPessoaJuridicaEntity> TelefonesPessoaJuridica { get; set; }
        public DbSet<TelefonesPessoaFisicaEntity> TelefonesPessoaFisica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CreateMap();

            base.OnModelCreating(modelBuilder);
        }
    }
}
