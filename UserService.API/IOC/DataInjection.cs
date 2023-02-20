using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UserService.Data.EF;
using UserService.Data.EF.Interfaces;
using UserService.Data.EF.Repositories;

namespace UserService.API.IOC
{
  public class DataInjection
  {
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
      DbConfig _dbConfig = configuration.GetSection("SqlDbConnection").Get<DbConfig>();
      services.AddDbContext<ApplicationDbContext>(opt => opt
      .UseSqlServer(_dbConfig.ConnectionString));
      services.AddScoped<UnitOfWork>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IRoleRepository, RoleRepository>();
      services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    }
  }
}
