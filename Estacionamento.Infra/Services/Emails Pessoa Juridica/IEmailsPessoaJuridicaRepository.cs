using Estacionamento.Domain.Emails_Pessoa_Juridica;

namespace Estacionamento.Domain.Services.Emails_Pessoa_Juridica
{
    public interface IEmailsPessoaJuridicaRepository
    {
        bool PostEmail(EmailsPessoaJuridicaEntity emailsPessoaJuridica);
    }
}
