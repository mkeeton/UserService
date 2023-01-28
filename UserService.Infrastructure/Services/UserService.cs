using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Data.EF;
using UserService.Infrastructure.Interfaces;
using UserService.Interface;

namespace UserService.Infrastructure.Services
{
  public class UserService: IUserService
  {

    UnitOfWork _unitOfWork;
    public UserService(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<ExistingUser>> GetUsers()
    {
      return (await _unitOfWork.Users.GetUsers()).Select(u => new ExistingUser() { Id = u.Id, Email = u.Email, Firstname = u.Firstname, Lastname = u.Lastname });
    }
    public async Task<ExistingUser> AddUser(NewUser newUser)
    {
      return new ExistingUser();
    }
  }
}
