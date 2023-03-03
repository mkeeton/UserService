﻿using GraphQL;

namespace UserService.GraphQL.Custom.Models
{
    public interface IGraphQlUserContext
    {
        string CorrelationId { get; set; }
        dynamic PropBag { get; set; }
    }

    public class GraphQLUserContext : Dictionary<string,object?>, IGraphQlUserContext
    {
        public GraphQLUserContext(string correlationId)
        {
            this.CorrelationId = correlationId;
            this.PropBag = new { };
        }

        public GraphQLUserContext()
        {
            this.CorrelationId = Guid.NewGuid().ToString();
            this.PropBag = new { };
        }

        public string CorrelationId { get; set; }
        public dynamic PropBag { get; set; }
    }
}
