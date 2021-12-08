using Estacionamento.Domain.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Pessoa_Juridica.Entity;
using Estacionamento.Domain.Services.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Services.Pessoa_Juridica.Dto;
using Estacionamento.Domain.Services.Telefones_Pessoa_Juridica;
using Estacionamento.Domain.Telefones_Pessoa_Juridica;
using Estacionamento.SharedKernel.Validations;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<PessoaJuridicaDto> GetByCNPJPessoaJuridica(string cnpj)
        {
            var pessoaJuridica = _pessoaJuridicaRepository.GetByCNPJPessoaJuridica(cnpj);

            return pessoaJuridica.Select(x => new PessoaJuridicaDto
            {
                RazaoSocial= x.RazaoSocial,
                NomeFantasia = x.NomeFantasia,
                Endereço = x.Endereço,
                CNPJ = x.CNPJ,
                Emails = GetEmailsPessoaFisica(x.Emails),
                Telefones = GetTelefonesPessoaFisica(x.Telefones)
            }).ToList();
        }

        public IEnumerable<PessoaJuridicaDto> GetByNomeFantasia(string nomeFantasia)
        {
            var pessoaJuridica = _pessoaJuridicaRepository.GetByNomeFantasia(nomeFantasia);

            return pessoaJuridica.Select(x => new PessoaJuridicaDto
            {
                RazaoSocial = x.RazaoSocial,
                NomeFantasia = x.NomeFantasia,
                Endereço = x.Endereço,
                CNPJ = x.CNPJ,
                Emails = GetEmailsPessoaFisica(x.Emails),
                Telefones = GetTelefonesPessoaFisica(x.Telefones)
            }).ToList();
        }

        public IEnumerable<PessoaJuridicaDto> GetByRazaoSocial(string razaoSocial)
        {
            var pessoaJuridica = _pessoaJuridicaRepository.GetByRazaoSocial(razaoSocial);

            return pessoaJuridica.Select(x => new PessoaJuridicaDto
            {
                RazaoSocial = x.RazaoSocial,
                NomeFantasia = x.NomeFantasia,
                Endereço = x.Endereço,
                CNPJ = x.CNPJ,
                Emails = GetEmailsPessoaFisica(x.Emails),
                Telefones = GetTelefonesPessoaFisica(x.Telefones)
            }).ToList();
        }

        private IEnumerable<EmailsPessoaJuridicaEntity> GetEmailsPessoaFisica(IEnumerable<EmailsPessoaJuridicaEntity> emailsPessoaJuridicaEntity)
        {
            return emailsPessoaJuridicaEntity.Select(x => new EmailsPessoaJuridicaEntity
            {
                Email = x.Email
            });
        }
        private IEnumerable<TelefonesPessoaJuridicaEntity> GetTelefonesPessoaFisica(IEnumerable<TelefonesPessoaJuridicaEntity> telefonesPessoaJuridicaEntity)
        {
            return telefonesPessoaJuridicaEntity.Select(x => new TelefonesPessoaJuridicaEntity
            {
                Telefone = x.Telefone
            });
        }

        public bool PostPessoaJuridica(PessoaJuridicaDto pessoajuridica)
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

            foreach (var telefone in pessoajuridica.Telefones)
            {
                _telefonesPessoaJuridicaRepository.PostTelefone(new TelefonesPessoaJuridicaEntity
                {
                    IdPessoaJuridica = postPessoaJuridica.Id,
                    Telefone = telefone.Telefone
                });
            }

            foreach (var email in pessoajuridica.Emails)
            {
                if (!_validations.EmailIsValid(email.Email))
                {
                    _notification.AddWithReturn<bool>("Ops, este um email é valido");
                    return false;
                }
                _emailsPessoaJuridicaRepository.PostEmail(new EmailsPessoaJuridicaEntity
                {
                    IdPessoaJuridica = postPessoaJuridica.Id,
                    Email = email.Email
                });
            }
            return true;
        }
    }
}
