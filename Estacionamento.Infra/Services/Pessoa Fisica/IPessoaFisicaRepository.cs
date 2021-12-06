using Estacionamento.Infra.Pessoa_Fisica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services.Pessoa_Fisica
{
    public interface IPessoaFisicaRepository
    {
        bool GetByCpf(string cpf);
        PessoaFisicaEntity PostPessoaFisica(PessoaFisicaEntity pessoaFisicaEntity);
    }
}
