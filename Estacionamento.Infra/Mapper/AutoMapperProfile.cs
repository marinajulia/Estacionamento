using AutoMapper;
using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Estacionamento.Domain.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Pessoa_Juridica.Entity;
using Estacionamento.Domain.Services.Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Pessoa_Juridica.Dto;
using Estacionamento.Infra.Pessoa_Fisica.Entity;

namespace Estacionamento.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PessoaJuridicaEntity, PessoaJuridicaDto>();
            CreateMap<PessoaJuridicaDto, PessoaJuridicaEntity>();

            CreateMap<PessoaFisicaEntity, PessoaFisicaDto>();
            CreateMap<PessoaFisicaDto, PessoaFisicaEntity>();
        }
    }
}
