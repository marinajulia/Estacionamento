using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Estacionamento.Domain.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Telefones_Pessoa_Juridica;
using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;
using Microsoft.EntityFrameworkCore;


namespace Estacionamento.Infra.Data
{
    public static class BaseMap
    {
        public static ModelBuilder CreateMap(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailsPessoaFisicaEntity>()
                .HasOne(x => x.PessoaFisica)
                .WithMany(x => x.Emails)
                .HasForeignKey(x => x.IdPessoaFisica);

            modelBuilder.Entity<EmailsPessoaJuridicaEntity>()
                .HasOne(x => x.PessoaJuridica)
                .WithMany(x => x.Emails)
                .HasForeignKey(x => x.IdPessoaJuridica);

            modelBuilder.Entity<TelefonesPessoaJuridicaEntity>()
               .HasOne(x => x.PessoaJuridica)
               .WithMany(x => x.Telefones)
               .HasForeignKey(x => x.IdPessoaJuridica);

            modelBuilder.Entity<TelefonesPessoaFisicaEntity>()
               .HasOne(x => x.PessoaFisica)
               .WithMany(x => x.Telefones)
               .HasForeignKey(x => x.IdPessoaFisica);

            return modelBuilder;
        }
    }
}
