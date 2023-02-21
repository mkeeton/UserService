using GraphQL.Types;
using UserService.GraphQL.GraphQL.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UserService.GraphQL.GraphQL
{
    public class UserSchema : Schema
    {
        public UserSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<UserServiceQueries>();
        }
    }
}
