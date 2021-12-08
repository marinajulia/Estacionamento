using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
