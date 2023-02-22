﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Interface;

namespace UserService.Infrastructure.Interfaces
{
  public interface IUserService
  {

    Task<IEnumerable<ExistingUser>> GetUsers();
        IEnumerable<ExistingUser> GetUsers2();
        Task<ExistingUser> AddUser(NewUser newUser);
  }
}
