using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain
{
    public class RoleModel
    {
        [Key]
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<UserRoleModel> RoleUsers { get; set; } = new List<UserRoleModel>();
    }
}
