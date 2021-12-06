using AutoMapper;
using Estacionamento.Domain.Mapper;
using Estacionamento.Domain.Services.Emails_Pessoa_Fisica;
using Estacionamento.Domain.Services.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Services.Pessoa_Fisica;
using Estacionamento.Domain.Services.Pessoa_Juridica;
using Estacionamento.Domain.Services.Pessoa_Juridica.Entity;
using Estacionamento.Domain.Services.Telefones_Pessoa_Fisica;
using Estacionamento.Domain.Services.Telefones_Pessoa_Juridica;
using Estacionamento.Infra.Data;
using Estacionamento.Infra.Repositories.Emails_Pessoa_Fisica;
using Estacionamento.Infra.Repositories.Emails_Pessoa_Juridica;
using Estacionamento.Infra.Repositories.Pessoa_Juridica;
using Estacionamento.Infra.Repositories.PessoaFisica;
using Estacionamento.Infra.Repositories.Telefones_Pessoa_Fisica;
using Estacionamento.Infra.Repositories.Telefones_Pessoa_Juridica;
using Estacionamento.SharedKernel.Validations;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Domain.Notification;

namespace Estacionamento_rift.Infra
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new AutoMapperProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<INotification, Notification>();
            services.AddDbContext<ApplicationContext>();

            Repositories(services);
            Services(services);
        }

        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IEmailsPessoaFisicaRepository, EmailsPessoaFisicaRepository>();
            services.AddScoped<IEmailsPessoaJuridicaRepository, EmailsPessoaJuridicaRepository>();
            services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            services.AddScoped<ITelefonesPessoaFisicaRepository, TelefonesPessoaFisicaRepository>();
            services.AddScoped<ITelefonesPessoaJuridicaRepository, TelefonesPessoaJuridicaRepository>();
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<IPessoaFisicaService, PessoaFisicaService>();
            services.AddScoped<IPessoaJuridicaService, PessoaJuridicaService>();
            services.AddScoped<IValidations, Validations>();
        }
    }
}
