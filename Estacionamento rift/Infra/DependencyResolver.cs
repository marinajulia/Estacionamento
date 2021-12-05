using AutoMapper;
using Estacionamento.Domain.Mapper;
using Estacionamento.Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //services.AddScoped<INewsRepository, NewsRepository>();
        }

        public static void Services(IServiceCollection services)
        {
            //services.AddScoped<INewsService, NewsService>();
        }
    }
}
