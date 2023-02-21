using GraphQL.Types;
using UserService.GraphQL.GraphQL.Queries;
using UserService.Infrastructure.Interfaces;

namespace UserService.GraphQL.GraphQL
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
