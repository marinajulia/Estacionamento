using Estacionamento.Domain.Services.Emails_Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Telefones_Pessoa_Fisica.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services.Pessoa_Fisica
{
    public interface IPessoaFisicaService
    {
        bool PostPessoaFisica(PessoaFisicaDto pessoaFisica, string[] telefones, string[] emails);
    }
}
