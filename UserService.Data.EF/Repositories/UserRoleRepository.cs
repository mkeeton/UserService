using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Data.EF.Interfaces;
using UserService.Domain;

namespace UserService.Data.EF.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserRoleModel>> GetUserRoles()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<IEnumerable<UserRoleModel>> GetRolesForUser(Guid userId)
        {
            return await _context.UserRoles.Where(ur => ur.User.Id==userId).ToListAsync();
        }
        public async Task<IEnumerable<UserRoleModel>> GetUsersForRole(Guid roleId)
        {
            return await _context.UserRoles.Where(ur => ur.Role.Id == roleId).ToListAsync();
        }

        public async Task<UserRoleModel> AddUserRole(UserRoleModel newUserRole)
        {
            return (await _context.UserRoles.AddAsync(newUserRole)).Entity;
        }
    }
}
