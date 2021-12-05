using AutoMapper;
using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Estacionamento.Domain.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Pessoa_Juridica.Entity;
using Estacionamento.Domain.Services.Emails_Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Emails_Pessoa_Juridica.Dto;
using Estacionamento.Domain.Services.Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Pessoa_Juridica.Dto;
using Estacionamento.Domain.Services.Telefones_Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Telefones_Pessoa_Juridica.Dto;
using Estacionamento.Domain.Telefones_Pessoa_Juridica;
using Estacionamento.Infra.Pessoa_Fisica.Entity;
using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;

namespace Estacionamento.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmailsPessoaFisicaEntity, EmailsPessoaFisicaDto>();
            CreateMap<EmailsPessoaFisicaDto, EmailsPessoaFisicaEntity>();

            CreateMap<EmailsPessoaJuridicaEntity, EmailsPessoaJuridicaDto>();
            CreateMap<EmailsPessoaJuridicaDto, EmailsPessoaJuridicaEntity>();

            CreateMap<PessoaJuridicaEntity, PessoaJuridicaDto>();
            CreateMap<PessoaJuridicaDto, PessoaJuridicaEntity>();

            CreateMap<PessoaFisicaEntity, PessoaFisicaDto>();
            CreateMap<PessoaFisicaDto, PessoaFisicaEntity>();

            CreateMap<TelefonesPessoaFisicaEntity, TelefonesPessoaFisicaDto>();
            CreateMap<TelefonesPessoaFisicaDto, TelefonesPessoaFisicaEntity>();

            CreateMap<TelefonesPessoaJuridicaEntity, TelefonesPessoaJuridicaDto>();
            CreateMap<TelefonesPessoaJuridicaDto, TelefonesPessoaJuridicaEntity>();
        }
    }
}
