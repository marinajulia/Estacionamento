using Estacionamento.Domain.Emails_Pessoa_Juridica;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Infra.Data.Configuration.EmailsPessoaJuridica
{
    public class EmailsPessoaJuridicaConfiguration : IEntityTypeConfiguration<EmailsPessoaJuridicaEntity>
    {
        public void Configure(EntityTypeBuilder<EmailsPessoaJuridicaEntity> builder)
        {
            builder.ToTable("EmailsPessoaJuridica");
            builder.HasKey(p => p.Id);
        }
    }
}
