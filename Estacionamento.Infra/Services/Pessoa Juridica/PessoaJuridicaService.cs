using Estacionamento.Domain.Pessoa_Juridica.Entity;
using Estacionamento.Domain.Services.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Services.Pessoa_Juridica.Dto;
using Estacionamento.Domain.Services.Telefones_Pessoa_Juridica;
using Estacionamento.SharedKernel.Validations;
using SharedKernel.Domain.Notification;

namespace Estacionamento.Domain.Services.Pessoa_Juridica.Entity
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly INotification _notification;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly ITelefonesPessoaJuridicaRepository _telefonesPessoaJuridicaRepository;
        private readonly IEmailsPessoaJuridicaRepository _emailsPessoaJuridicaRepository;
        private readonly IValidations _validations;

        public PessoaJuridicaService(INotification notification, IPessoaJuridicaRepository pessoaJuridicaRepository, 
            ITelefonesPessoaJuridicaRepository telefonesPessoaJuridicaRepository,
            IEmailsPessoaJuridicaRepository emailsPessoaJuridicaRepository,
            IValidations validations)
        {
            _notification = notification;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _telefonesPessoaJuridicaRepository = telefonesPessoaJuridicaRepository;
            _emailsPessoaJuridicaRepository = emailsPessoaJuridicaRepository;
            _validations = validations;
        }

        public bool PostPessoaJuridica(PessoaJuridicaDto pessoajuridica, string[] telefones, string[] emails)
        {
            if (string.IsNullOrEmpty(pessoajuridica.CNPJ) || string.IsNullOrEmpty(pessoajuridica.RazaoSocial))
            {
                _notification.AddWithReturn<bool>("Ops, existem campos obrigatórios que não foram preenchidos");
                return false;
            }

            if (!_validations.CnpjIsValid(pessoajuridica.CNPJ))
            {
                _notification.AddWithReturn<bool>("Ops, o CNPJ não é válido");
                return false;
            }

            if (_pessoaJuridicaRepository.GetByCNPJ(pessoajuridica.CNPJ))
            {
                _notification.AddWithReturn<bool>("Ops, este CNPJ já foi cadastrado");
                return false;
            }

            var postPessoaJuridica = _pessoaJuridicaRepository.PostPessoaJuridica(new PessoaJuridicaEntity
            {
                CNPJ = pessoajuridica.CNPJ,
                Endereço = pessoajuridica.Endereço,
                NomeFantasia = pessoajuridica.NomeFantasia,
                RazaoSocial = pessoajuridica.RazaoSocial
            });
            return true;
        }
    }
}
