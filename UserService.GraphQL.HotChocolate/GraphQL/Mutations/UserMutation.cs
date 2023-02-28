using UserService.Infrastructure.Interfaces;
using UserService.Interface;

namespace UserService.GraphQL.HotChocolate.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class UserMutation
    {
        public async Task<ExistingUser> addUser(NewUser newUser, [Service] IUserService userService) =>
            await userService.AddUser(newUser);
    }
}
