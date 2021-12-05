using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data.Configuration.EmailsPessoaFisica
{
    public class EmailsPessoaFisicaConfiguration : IEntityTypeConfiguration<EmailsPessoaFisicaEntity>
    {
        public void Configure(EntityTypeBuilder<EmailsPessoaFisicaEntity> builder)
        {
            builder.ToTable("EmailsPessoaFisica");
            builder.HasKey(p => p.Id);
        }
    }
}
