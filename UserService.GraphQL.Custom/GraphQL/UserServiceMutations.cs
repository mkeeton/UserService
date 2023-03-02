using GraphQL.Types;
using UserService.GraphQL.Custom.GraphQL.Mutations;
using UserService.Infrastructure.Interfaces;

namespace UserService.GraphQL.Custom.GraphQL
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
