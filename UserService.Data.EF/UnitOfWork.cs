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

        IUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            _context = dbContext;
            Users = userRepository;
        }
    }
}
