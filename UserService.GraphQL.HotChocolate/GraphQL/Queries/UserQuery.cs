using UserService.Infrastructure.Interfaces;
using UserService.Interface;

namespace UserService.GraphQL.HotChocolate.GraphQL.Queries
{
    public class UserQuery: ObjectTypeExtension
    {
        public async Task<IEnumerable<ExistingUser>> getUsers([Service] IUserService userService) =>
            await userService.GetUsers();
    }
}
