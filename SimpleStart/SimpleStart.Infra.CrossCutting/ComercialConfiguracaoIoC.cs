using Microsoft.Extensions.DependencyInjection;
using SimpleStart.Comercial.Comandos;
using SimpleStart.Comercial.Interfaces;
using SimpleStart.Comercial.Servicos;
using SimpleStart.Infra.Dados.Contextos;
using SimpleStart.Infra.Dados.Repositorios;
using SimpleStart.Infra.Dados.UoW;

namespace SimpleStart.Infra.CrossCutting
{
    public class ComercialConfiguracaoIoC
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<SimpleStartContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IManipuladorComando<ComandoClienteCriado>, ManipuladorComandosCliente>();
            services.AddTransient<IRepositorioBase, RepositorioBase>();
        }
    }
}
