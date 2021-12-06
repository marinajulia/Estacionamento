using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services.Emails_Pessoa_Fisica
{
    public interface IEmailsPessoaFisicaRepository
    {
        bool PostEmail(EmailsPessoaFisicaEntity emailsPessoaFisicaEntity);
    }
}
