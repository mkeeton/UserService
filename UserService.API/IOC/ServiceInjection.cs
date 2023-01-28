using UserService.Infrastructure.Interfaces;
using UserService.Infrastructure.Services;

namespace UserService.API.IOC
{
  public class ServiceInjection
  {
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<IUserService, UserService.Infrastructure.Services.UserService>();
    }
  }
}
