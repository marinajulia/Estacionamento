using Estacionamento.Domain.Services.Emails_Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Telefones_Pessoa_Fisica.Dto;
using Estacionamento.Infra.Pessoa_Fisica.Entity;
using SharedKernel.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services.Pessoa_Fisica
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly INotification _notification;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaService(INotification notification, IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _notification = notification;
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public bool PostPessoaFisica(PessoaFisicaDto pessoaFisica, EmailsPessoaFisicaDto[] emails, TelefonesPessoaFisicaDto[] telefones)
        {
            if (string.IsNullOrEmpty(pessoaFisica.CPF) || string.IsNullOrEmpty(pessoaFisica.Nome))
            {
                _notification.AddWithReturn<bool>("Ops, existem campos obrigatórios que não foram preenchidos");
                return false;
            }

            if (!_pessoaFisicaRepository.GetByCpf(pessoaFisica.CPF))
            {
                _notification.AddWithReturn<bool>("Ops, este CPF já está cadastrado");
                return false;
            }

            if (!_pessoaFisicaRepository.CpfIsValid(pessoaFisica.CPF))
            {
                _notification.AddWithReturn<bool>("Ops, este CPF não é valido");
                return false;
            }

            var postPessoaFisica = _pessoaFisicaRepository.PostPessoaFisica(new PessoaFisicaEntity
            {
                Nome = pessoaFisica.Nome,
                CPF = pessoaFisica.CPF,
                DataNascimento = pessoaFisica.DataNascimento,
                Endereço = pessoaFisica.Endereço,
                RG = pessoaFisica.RG,
                Sexo= pessoaFisica.Sexo
            });
        }
    }
}
