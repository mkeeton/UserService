using GraphQL;
using GraphQL.Types;
using System.Security.Cryptography;
using UserService.Infrastructure.Interfaces;
using UserService.Infrastructure.Services;
using UserService.Interface;
using UserService.Interface.GraphQL.Inputs.User;
using UserService.Interface.GraphQL.Outputs.User;

namespace UserService.GraphQL.GraphQL.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        public static void AddMutations(ObjectGraphType graphQueries, IUserService userService)
        {
            graphQueries.Field<ExistingUserType>("addUser")
                .Argument<NewUserType>("newUser")              // required
                //.Argument<string>("description", true) // optional
                .ResolveAsync(async ctx =>
                {
                    var newUser = ctx.GetArgument<NewUser>("newUser");
                    return await userService.AddUser(newUser);
                });

        }
    }
}
