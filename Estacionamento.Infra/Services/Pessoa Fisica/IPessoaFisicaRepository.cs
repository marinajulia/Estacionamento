using Estacionamento.Infra.Pessoa_Fisica.Entity;
using System.Collections.Generic;

namespace Estacionamento.Domain.Services.Pessoa_Fisica
{
    public interface IPessoaFisicaRepository
    {
        bool GetByCpf(string cpf);
        PessoaFisicaEntity PostPessoaFisica(PessoaFisicaEntity pessoaFisicaEntity);
        bool SexoIsValid(string sexo);
        IEnumerable<PessoaFisicaEntity> GetByCpfPessoaFisica(string cpf);
        IEnumerable<PessoaFisicaEntity> GetByRgPessoaFisica(string rg);
        IEnumerable<PessoaFisicaEntity> GetByName(string name);
    }
}
