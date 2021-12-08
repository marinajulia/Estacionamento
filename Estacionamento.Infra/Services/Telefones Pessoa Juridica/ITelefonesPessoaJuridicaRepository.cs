using Estacionamento.Domain.Telefones_Pessoa_Juridica;

namespace Estacionamento.Domain.Services.Telefones_Pessoa_Juridica
{
    public interface ITelefonesPessoaJuridicaRepository
    {
        bool PostTelefone(TelefonesPessoaJuridicaEntity telefonesPessoaJuridica);
    }
}
