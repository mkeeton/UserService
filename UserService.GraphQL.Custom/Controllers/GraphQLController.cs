using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.GraphQL.Custom.Models;
using GraphQL.DataLoader;
using GraphQL.NewtonsoftJson;

namespace UserService.GraphQL.Custom.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {

        public GraphQLController(ISchema schema,
            IDocumentExecuter documentExecutor,
            DataLoaderDocumentListener dataLoaderDocumentListener)
        {
            this.schema = schema;
            this.documentExecutor = documentExecutor;
            this.dataLoaderDocumentListener = dataLoaderDocumentListener;
        }

        private readonly DataLoaderDocumentListener dataLoaderDocumentListener;
        private readonly IDocumentExecuter documentExecutor;

        private readonly ISchema schema;

        private ExecutionOptions CreateGraphExecutionOptions(GraphQLQuery query)
        {
            var executionOptions = new ExecutionOptions
            {
                Schema = this.schema,
                Query = query.Query,
                Variables = new Inputs(query.Variables?.ToObject<Dictionary<string,object?>>()),
                UserContext = new GraphQLUserContext()
            };
            executionOptions.Listeners.Add(this.dataLoaderDocumentListener);

            return executionOptions;
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            return Execute();

            // local function to make sure validation errors are raised immediately but execution is still deferred using async task.
            async Task<IActionResult> Execute()
            {
                var options = this.CreateGraphExecutionOptions(query);

                var result = await this.documentExecutor.ExecuteAsync(options);

                if (result.Errors?.Count > 0)
                {
                    return this.StatusCode(500, result);
                }

                return this.Ok(result);
            }
        }

    }
}
