using Sentry;
using UserService.GraphQL.HotChocolate.GraphQL.Mutations;
using UserService.GraphQL.HotChocolate.GraphQL.Queries;

namespace UserService.GraphQL.HotChocolate.GraphQL
{
    public class GraphQLConfig
    {

        public static void Configure(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                .AddType<UserQuery>()
                .AddMutationType(q => q.Name("Mutation"))
                .AddType<UserMutation>()
                .AddErrorFilter(error =>
                {
                    if (error.Exception!=null)
                    {
                        SentrySdk.CaptureException(error.Exception);
                    }
                    return error;
                });
        }
    }
}
