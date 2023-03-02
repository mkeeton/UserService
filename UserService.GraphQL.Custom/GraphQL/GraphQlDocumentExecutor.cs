using GraphQL.Execution;
using GraphQL;
using GraphQLParser.AST;
using ExecutionContext = GraphQL.Execution.ExecutionContext;

namespace UserService.GraphQL.Custom.GraphQL
{
    public class GraphQlDocumentExecutor : DocumentExecuter
    {
        protected override IExecutionStrategy SelectExecutionStrategy(ExecutionContext context)
        {
            if (context.Operation.Operation == OperationType.Query)
            {
                return new SerialExecutionStrategy();
            }
            return base.SelectExecutionStrategy(context);
        }
    }
}
