using GraphQL.Types;
using UserService.GraphQL.GraphQL.Mutations;
using UserService.Infrastructure.Interfaces;

namespace UserService.GraphQL.GraphQL
{
    public class UserServiceMutations : ObjectGraphType
    {
        public UserServiceMutations(IUserService userService)
        {
            this.Description = "Mutatuions for the User Service";

            UserMutation.AddMutations(this, userService);

        }
    }
}
