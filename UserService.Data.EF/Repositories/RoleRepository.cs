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
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoleModel>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<RoleModel> AddRole(RoleModel newRole)
        {
            return (await _context.Roles.AddAsync(newRole)).Entity;
        }
    }
}
