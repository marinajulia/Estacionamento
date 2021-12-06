using Estacionamento.Domain.Pessoa_Juridica.Entity;

namespace Estacionamento.Domain.Services.Pessoa_Juridica
{
    public interface IPessoaJuridicaRepository
    {
        bool GetByCNPJ(string cnpj);
        PessoaJuridicaEntity PostPessoaJuridica(PessoaJuridicaEntity pessoaJuridicaEntity);
    }
}
