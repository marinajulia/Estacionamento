using Estacionamento.Domain.Services.Pessoa_Juridica.Dto;
using System.Collections.Generic;

namespace Estacionamento.Domain.Services.Pessoa_Juridica
{
    public interface IPessoaJuridicaService
    {
        bool PostPessoaJuridica(PessoaJuridicaDto pessoajuridica);
        IEnumerable<PessoaJuridicaDto> GetByCNPJPessoaJuridica(string cnpj);
        IEnumerable<PessoaJuridicaDto> GetByRazaoSocial(string razaoSocial);
        IEnumerable<PessoaJuridicaDto> GetByNomeFantasia(string nomeFantasia);
    }
}
