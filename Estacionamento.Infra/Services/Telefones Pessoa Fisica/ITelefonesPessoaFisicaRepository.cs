using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services.Telefones_Pessoa_Fisica
{
    public interface ITelefonesPessoaFisicaRepository
    {
        bool PostTelefone(TelefonesPessoaFisicaEntity telefonesPessoaFisica);
    }
}
