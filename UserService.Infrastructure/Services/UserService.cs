using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Data.EF;
using UserService.Domain;
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
            UserModel _newUser = new Domain.UserModel()
            {
                Firstname = "Bobby",
                Lastname = "Brown",
                Email = "Bobby@Brown",
            };
            await _unitOfWork.Users.AddUser(_newUser);
            await _unitOfWork.Commit();
      return (await _unitOfWork.Users.GetUsers()).Select(u => new ExistingUser() { Id = u.Id, Email = u.Email, Firstname = u.Firstname, Lastname = u.Lastname });
    }
    public async Task<ExistingUser> AddUser(NewUser newUser)
    {
            UserModel _newUser = new Domain.UserModel()
            {
                Firstname = "Billy",
                Lastname = "Batson",
                Email = "billy@shazam.com",
            };
            UserModel _addedUser = await _unitOfWork.Users.AddUser(_newUser);
            await _unitOfWork.Commit();
            return new ExistingUser()
            {
                Id = _addedUser.Id,
            Firstname=_addedUser.Firstname,
            Lastname = _addedUser.Lastname,
            Email = _addedUser.Email
            };
    }
  }
}
