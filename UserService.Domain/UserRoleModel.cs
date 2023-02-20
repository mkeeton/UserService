using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain
{
    public class UserRoleModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? SystemId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateRemoved { get; set; }
        public UserModel User { get; set; }
        public RoleModel Role { get; set; }
    }
}
