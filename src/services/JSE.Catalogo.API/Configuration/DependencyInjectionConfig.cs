using JSE.Catalogo.API.Data;
using JSE.Catalogo.API.Data.Repository;
using JSE.Catalogo.API.Models;

namespace JSE.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}