using GraphQL;
using GraphQL.DataLoader;
using UserService.GraphQL.Custom.GraphQL;
using UserService.Infrastructure.Interfaces;

namespace UserService.GraphQL.Custom.IOC
{
    public class ServiceInjection
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();
            services.AddScoped<IUserService, UserService.Infrastructure.Services.UserService>();
            services.AddTransient<IDocumentExecuter, GraphQlDocumentExecutor>();
        }
    }
}
