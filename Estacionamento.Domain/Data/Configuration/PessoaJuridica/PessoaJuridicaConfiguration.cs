using Estacionamento.Domain.Pessoa_Juridica.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Infra.Data.Configuration.PessoaJuridica
{
    public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridicaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridicaEntity> builder)
        {
            builder.ToTable("PessoaJuridica");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CNPJ).IsRequired();
            builder.Property(p => p.RazaoSocial).IsRequired();
        }
    }
}
