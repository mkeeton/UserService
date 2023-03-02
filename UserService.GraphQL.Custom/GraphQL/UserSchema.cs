using GraphQL.Types;
using UserService.GraphQL.Custom.GraphQL.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UserService.GraphQL.Custom.GraphQL
{
    public class UserSchema : Schema
    {
        public UserSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<UserServiceQueries>();
            Mutation = serviceProvider.GetRequiredService<UserServiceMutations>();
        }
    }
}
