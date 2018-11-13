using API.Data.Repositorio.Interface;
using API.Data.Serviço;
using API.Data.Serviço.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace API.AnotacaoCustomizada
{
    public static class Factory
    {
        public static ServiceProvider Services;

        public static void Build(IServiceCollection services)
        {

            services.AddTransient<IUsuarioServico, UsuarioServico>();
            services.AddTransient<IUsuarioRepositorio, IUsuarioRepositorio>();


            Services = services.BuildServiceProvider();
        }

        public static TS GetInstance<T, TS>()
        {
            return (TS)Services.GetService(typeof(T));
        }
    }
}