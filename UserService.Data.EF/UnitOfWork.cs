﻿using System;
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

        public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            _context = dbContext;
            Users = userRepository;
        }

        public async Task<int> Commit()
        {
          return await _context.SaveChangesAsync();
        }
    }
}
