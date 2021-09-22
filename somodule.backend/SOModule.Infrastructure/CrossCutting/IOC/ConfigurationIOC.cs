using Autofac;
using AutoMapper;
using SOModule.Application;
using SOModule.Application.Interfaces;
using SOModule.Application.Mappers;
using SOModule.Domain.Core.Interfaces.Repositories;
using SOModule.Domain.Core.Interfaces.Services;
using SOModule.Domain.Services;
using SOModule.Infrastructure.Data.Repositories;

namespace SOModule.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceOrderApplicationService>().As<IServiceOrderApplicationService>();
            builder.RegisterType<ServiceOrderService>().As<IServiceOrderService>();
            builder.RegisterType<ServiceOrderRepository>().As<IServiceOrderRepository>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceOrderMapping());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}