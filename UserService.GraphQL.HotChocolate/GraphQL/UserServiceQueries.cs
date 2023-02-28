using Sentry;
using UserService.GraphQL.HotChocolate.GraphQL.Queries;

namespace UserService.GraphQL.HotChocolate.GraphQL
{
    public class UserServiceQueries
    {

        public static void AddQueries(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                .AddType<UserQuery>()
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
