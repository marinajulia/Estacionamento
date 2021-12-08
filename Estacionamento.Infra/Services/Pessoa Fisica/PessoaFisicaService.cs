using AutoMapper;
using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Estacionamento.Domain.Services.Emails_Pessoa_Fisica;
using Estacionamento.Domain.Services.Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Telefones_Pessoa_Fisica;
using Estacionamento.Infra.Pessoa_Fisica.Entity;
using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;
using Estacionamento.SharedKernel.Validations;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento.Domain.Services.Pessoa_Fisica
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly INotification _notification;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly ITelefonesPessoaFisicaRepository _telefonesPessoaFisicaRepository;
        private readonly IEmailsPessoaFisicaRepository _emailsPessoaFisicaRepository;
        private readonly IValidations _validations;

        public PessoaFisicaService(INotification notification, IPessoaFisicaRepository pessoaFisicaRepository,
            ITelefonesPessoaFisicaRepository telefonesPessoaFisica, IEmailsPessoaFisicaRepository emailsPessoaFisicaRepository,
            IValidations validations)
        {
            _notification = notification;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _telefonesPessoaFisicaRepository = telefonesPessoaFisica;
            _emailsPessoaFisicaRepository = emailsPessoaFisicaRepository;
            _validations = validations;
        }

        public IEnumerable<PessoaFisicaDto> GetByCpfPessoaFisica(string cpf)
        {
            var pessoaFisica = _pessoaFisicaRepository.GetByCpfPessoaFisica(cpf);

            return pessoaFisica.Select(x => new PessoaFisicaDto
            {
                Nome = x.Nome,
                Endereço = x.Endereço,
                CPF = x.CPF,
                RG = x.RG,
                DataNascimento = x.DataNascimento,
                Sexo = x.Sexo,
                Emails = GetEmailsPessoaFisica(x.Emails),
                Telefones = GetTelefonesPessoaFisica(x.Telefones)
            }).ToList();
        }
       
        public IEnumerable<PessoaFisicaDto> GetByName(string name)
        {
            var pessoaFisica = _pessoaFisicaRepository.GetByName(name);

            return pessoaFisica.Select(x => new PessoaFisicaDto
            {
                Nome = x.Nome,
                Endereço = x.Endereço,
                CPF = x.CPF,
                RG = x.RG,
                DataNascimento = x.DataNascimento,
                Sexo = x.Sexo,
                Emails = GetEmailsPessoaFisica(x.Emails),
                Telefones = GetTelefonesPessoaFisica(x.Telefones)
            }).ToList();
        }

        public IEnumerable<PessoaFisicaDto> GetByRgPessoaFisica(string rg)
        {
            var pessoaFisica = _pessoaFisicaRepository.GetByRgPessoaFisica(rg);

            return pessoaFisica.Select(x => new PessoaFisicaDto
            {
                Nome = x.Nome,
                Endereço = x.Endereço,
                CPF = x.CPF,
                RG = x.RG,
                DataNascimento = x.DataNascimento,
                Sexo = x.Sexo,
                Emails = GetEmailsPessoaFisica(x.Emails),
                Telefones = GetTelefonesPessoaFisica(x.Telefones)
            }).ToList();
        }

        private IEnumerable<EmailsPessoaFisicaEntity> GetEmailsPessoaFisica(IEnumerable<EmailsPessoaFisicaEntity> emailsPessoaFisicaEntity)
        {
            return emailsPessoaFisicaEntity.Select(x => new EmailsPessoaFisicaEntity
            {
                Email = x.Email
            });
        }
        private IEnumerable<TelefonesPessoaFisicaEntity> GetTelefonesPessoaFisica(IEnumerable<TelefonesPessoaFisicaEntity> telefonesPessoaFisicaEntity)
        {
            return telefonesPessoaFisicaEntity.Select(x => new TelefonesPessoaFisicaEntity
            {
                Telefone = x.Telefone
            });
        }

        public bool PostPessoaFisica(PessoaFisicaDto pessoaFisica)
        {
            if (string.IsNullOrEmpty(pessoaFisica.CPF) || string.IsNullOrEmpty(pessoaFisica.Nome))
            {
                _notification.AddWithReturn<bool>("Ops, existem campos obrigatórios que não foram preenchidos");
                return false;
            }

            if (!_validations.CpfIsValid(pessoaFisica.CPF))
            {
                _notification.AddWithReturn<bool>("Ops, este CPF não é valido");
                return false;
            }

            if (_pessoaFisicaRepository.GetByCpf(pessoaFisica.CPF))
            {
                _notification.AddWithReturn<bool>("Ops, este CPF já está cadastrado");
                return false;
            }

            if (!_validations.RgIsValid(pessoaFisica.RG))
            {
                _notification.AddWithReturn<bool>("Ops, este RG não é valido");
                return false;
            }

            if (!_pessoaFisicaRepository.SexoIsValid(pessoaFisica.Sexo))
            {
                _notification.AddWithReturn<bool>("Ops, insira um sexo válido");
                return false;
            }

            var postPessoaFisica = _pessoaFisicaRepository.PostPessoaFisica(new PessoaFisicaEntity
            {
                Nome = pessoaFisica.Nome,
                CPF = pessoaFisica.CPF,
                DataNascimento = pessoaFisica.DataNascimento,
                Endereço = pessoaFisica.Endereço,
                RG = pessoaFisica.RG,
                Sexo = pessoaFisica.Sexo
            });

            foreach (var telefone in pessoaFisica.Telefones)
            {
                if(pessoaFisica.Telefones == null || telefone == null)
                {
                    break;
                }
                _telefonesPessoaFisicaRepository.PostTelefone(new TelefonesPessoaFisicaEntity
                {
                    IdPessoaFisica = postPessoaFisica.Id,
                    Telefone = telefone.Telefone
                });
            }

            foreach (var email in pessoaFisica.Emails)
            {
                if (!_validations.EmailIsValid(email.Email))
                {
                    _notification.AddWithReturn<bool>("Ops, este um email é valido");
                    return false;
                }
                _emailsPessoaFisicaRepository.PostEmail(new EmailsPessoaFisicaEntity
                {
                    IdPessoaFisica = postPessoaFisica.Id,
                    Email = email.Email
                });
            }
            return true;
        }
    }
}
