using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data.Configuration.TelefonesPessoaFisica
{
    public class TelefonesPessoaFisicaConfiguration : IEntityTypeConfiguration<TelefonesPessoaFisicaEntity>
    {
        public void Configure(EntityTypeBuilder<TelefonesPessoaFisicaEntity> builder)
        {
            builder.ToTable("TelefonesPessoaFisica");
            builder.HasKey(p => p.Id);
        }
    }
}
