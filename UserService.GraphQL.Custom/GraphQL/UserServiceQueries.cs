using GraphQL.Types;
using UserService.GraphQL.Custom.GraphQL.Queries;
using UserService.Infrastructure.Interfaces;

namespace UserService.GraphQL.Custom.GraphQL
{
    public class UserServiceQueries : ObjectGraphType
    {
        public UserServiceQueries(IUserService userService)
        {
            this.Description = "Queries for the User Service";

            UserQuery.AddQueries(this, userService);

        }
    }
}
