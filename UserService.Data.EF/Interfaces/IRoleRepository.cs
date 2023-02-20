using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.Data.EF.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleModel>> GetRoles();
        Task<RoleModel> AddRole(RoleModel newRole);
    }
}
