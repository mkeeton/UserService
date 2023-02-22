using GraphQL;
using GraphQL.Types;
using UserService.Infrastructure.Interfaces;
using UserService.Interface;
using UserService.Interface.GraphQL.User;

namespace UserService.GraphQL.GraphQL.Queries
{
    public class UserQuery : ObjectGraphType
    {

        public static void AddQueries(ObjectGraphType graphQueries, IUserService userService)
        {
            //Field<ListGraphType<ExistingUserType>>("users",
            //    resolve: context => userService.GetUsers()
            //);

            graphQueries.Field<ListGraphType<ExistingUserType>>("getUsers")
                //.Argument<string>("name")              // required
                //.Argument<string>("description", true) // optional
                .ResolveAsync(async ctx => {
                    return await userService.GetUsers();
                });

            graphQueries.Field<ListGraphType<ExistingUserType>>("getUsers2")
                //.Argument<string>("name")              // required
                //.Argument<string>("description", true) // optional
                .Resolve(ctx => {
                    return userService.GetUsers2();
                });
        }
    }
}
