using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UserService.Interface.GraphQL.Outputs.User
{
    public class ExistingUserType : ObjectGraphType<ExistingUser>
    {
        public ExistingUserType()
        {
            Name = "ExistingUser";
            Description = "Existing User";
            Field(d => d.Id, nullable: false).Description("User Id");
            Field(d => d.Firstname, nullable: true).Description("User First Name");
            Field(d => d.Lastname, nullable: true).Description("User Last Name");
            Field(d => d.Email, nullable: true).Description("User Email Address");
        }
    }
}
