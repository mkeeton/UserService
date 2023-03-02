using GraphQL.Types;
using Newtonsoft.Json.Linq;

namespace UserService.GraphQL.Custom.Models
{
    public class GraphQLQuery : ObjectGraphType
    {
        public string NamedQuery { get; set; }

        public string OperationName { get; set; }

        public string Query { get; set; }

        public JObject Variables { get; set; } //https://github.com/graphql-dotnet/graphql-dotnet/issues/389
    }
}
