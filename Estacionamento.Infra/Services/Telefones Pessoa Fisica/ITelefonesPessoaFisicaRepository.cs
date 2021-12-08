using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;

namespace Estacionamento.Domain.Services.Telefones_Pessoa_Fisica
{
    public interface ITelefonesPessoaFisicaRepository
    {
        bool PostTelefone(TelefonesPessoaFisicaEntity telefonesPessoaFisica);
    }
}
