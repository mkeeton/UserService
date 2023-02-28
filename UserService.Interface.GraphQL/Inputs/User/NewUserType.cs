using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UserService.Interface.GraphQL.Inputs.User
{
    public class NewUserType : InputObjectGraphType<NewUser>
    {
        public NewUserType()
        {
            Name = "NewUser";
            Description = "New User";
            Field<NonNullGraphType<StringGraphType>>("firstname");
            Field< NonNullGraphType<StringGraphType>>("lastname");
            Field<NonNullGraphType<StringGraphType>>("email");
        }
    }
}
