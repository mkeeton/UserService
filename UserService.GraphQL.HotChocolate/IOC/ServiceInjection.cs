﻿using UserService.Infrastructure.Interfaces;

namespace UserService.GraphQL.HotChocolate.IOC
{
    public class ServiceInjection
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService.Infrastructure.Services.UserService>();
        }
    }
}
