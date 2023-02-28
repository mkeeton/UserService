using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UserService.Interface.GraphQL.Inputs.User
{
    public class NewUserType : ObjectGraphType<NewUser>
    {
        public NewUserType()
        {
            Name = "NewUser";
            Description = "New User";
            Field(d => d.Firstname, nullable: true).Description("User First Name");
            Field(d => d.Lastname, nullable: true).Description("User Last Name");
            Field(d => d.Email, nullable: true).Description("User Email Address");
        }
    }
}
