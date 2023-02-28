using Sentry;
using UserService.Infrastructure.Interfaces;
using UserService.Interface;

namespace UserService.GraphQL.HotChocolate.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class UserQuery
    {
        public async Task<IEnumerable<ExistingUser>> getUsers([Service] IUserService userService) =>
            await userService.GetUsers();
    }
}
