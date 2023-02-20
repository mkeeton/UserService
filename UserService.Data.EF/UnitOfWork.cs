using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Data.EF.Interfaces;

namespace UserService.Data.EF
{
    public class UnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IUserRoleRepository UserRoles { get; }

        public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _context = dbContext;
            Users = userRepository;
            Roles = roleRepository;
            UserRoles = userRoleRepository;
        }

        public async Task<int> Commit()
        {
          return await _context.SaveChangesAsync();
        }
    }
}
