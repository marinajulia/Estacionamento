using Estacionamento.Domain.Telefones_Pessoa_Juridica;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Infra.Data.Configuration.TelefonesPessoaJuridica
{
    public class TelefonesPessoaJuridicaConfiguration : IEntityTypeConfiguration<TelefonesPessoaJuridicaEntity>
    {
        public void Configure(EntityTypeBuilder<TelefonesPessoaJuridicaEntity> builder)
        {
            builder.ToTable("TelefonesPessoaJuridica");
            builder.HasKey(p => p.Id);
        }
    }
}
