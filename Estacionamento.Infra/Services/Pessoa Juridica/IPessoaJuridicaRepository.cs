using Estacionamento.Domain.Pessoa_Juridica.Entity;
using System.Collections.Generic;

namespace Estacionamento.Domain.Services.Pessoa_Juridica
{
    public interface IPessoaJuridicaRepository
    {
        bool GetByCNPJ(string cnpj);
        PessoaJuridicaEntity PostPessoaJuridica(PessoaJuridicaEntity pessoaJuridicaEntity);
        IEnumerable<PessoaJuridicaEntity> GetByCNPJPessoaJuridica(string cnpj);
        IEnumerable<PessoaJuridicaEntity> GetByRazaoSocial(string razaoSocial);
        IEnumerable<PessoaJuridicaEntity> GetByNomeFantasia(string nomeFantasia);
    }
}
