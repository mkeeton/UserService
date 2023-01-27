﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Data.EF.Interfaces;
using UserService.Domain;

namespace UserService.Data.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUserByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email.Equals(email,StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
        }
    }
}
