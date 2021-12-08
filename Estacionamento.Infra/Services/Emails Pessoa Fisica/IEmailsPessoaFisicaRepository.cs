using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using System.Collections.Generic;

namespace Estacionamento.Domain.Services.Emails_Pessoa_Fisica
{
    public interface IEmailsPessoaFisicaRepository
    {
        bool PostEmail(EmailsPessoaFisicaEntity emailsPessoaFisicaEntity);
        IEnumerable<EmailsPessoaFisicaEntity> GetByidPessoaFisica(int pessoaFisica);
    }
}
