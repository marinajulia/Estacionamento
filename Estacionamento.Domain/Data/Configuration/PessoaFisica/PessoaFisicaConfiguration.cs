using Estacionamento.Infra.Pessoa_Fisica.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data.Configuration.PessoaFisica
{
    public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisicaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaFisicaEntity> builder)
        {
            builder.ToTable("PessoaFisica");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.CPF).IsRequired();
        }
    }
}
