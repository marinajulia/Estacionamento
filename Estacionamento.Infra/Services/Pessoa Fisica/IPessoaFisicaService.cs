using Estacionamento.Domain.Services.Pessoa_Fisica.Dto;
using System.Collections.Generic;

namespace Estacionamento.Domain.Services.Pessoa_Fisica
{
    public interface IPessoaFisicaService
    {
        bool PostPessoaFisica(PessoaFisicaDto pessoaFisica);
        IEnumerable<PessoaFisicaDto> GetByCpfPessoaFisica(string cpf);
        IEnumerable<PessoaFisicaDto> GetByRgPessoaFisica(string rg);
        IEnumerable<PessoaFisicaDto> GetByName(string name);
    }
}
