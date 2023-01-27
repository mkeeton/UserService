using Microsoft.EntityFrameworkCore;
using UserService.Data.EF;
using UserService.Data.EF.Interfaces;
using UserService.Data.EF.Repositories;

namespace UserService.IOC
{
  public class DataInjection
  {
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
      builder.Services.AddDbContext<ApplicationDbContext>(opt => opt
      .UseSqlServer("Server=localhost:1433; Database=UserDb;Trusted_Connection=True;"));
      builder.Services.AddScoped<UnitOfWork>();
      builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
  }
}
