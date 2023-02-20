using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.Data.EF.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRoleModel>> GetRolesForUser(Guid userId);
        Task<IEnumerable<UserRoleModel>> GetUsersForRole(Guid roleId);
        Task<UserRoleModel> AddUserRole(UserRoleModel newUserRole);
    }
}
