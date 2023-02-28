﻿using System;
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
                IEnumerable<ExistingUser> _users = (await _unitOfWork.Users.GetUsers()).Select(u => new ExistingUser() { Id = u.Id, Email = u.Email, Firstname = u.Firstname, Lastname = u.Lastname });
                return (_users);
        }

        public async Task<ExistingUser?> GetUser(Guid userId)
        {
            UserModel _user = await _unitOfWork.Users.GetUser(userId);
            if(_user!=null)
            {
                return await GetUser(_user);
            }
            return null;
        }

        public async Task<ExistingUser> GetUser(UserModel user)
        {
            return new ExistingUser()
            {
                Id = user.Id,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
        }

        public IEnumerable<ExistingUser> GetUsers2()
        {
            ExistingUser _newUser = new ExistingUser()
            {
                Firstname = "Bobby",
                Lastname = "Brown",
                Email = "Bobby@Brown",
            };
            List<ExistingUser> _users = new List<ExistingUser>();
            _users.Add(_newUser);
            //await _unitOfWork.Users.AddUser(_newUser);
            //await _unitOfWork.Commit();
            //var _temp = "hello there";

            //IEnumerable<ExistingUser> _users = (await _unitOfWork.Users.GetUsers()).Select(u => new ExistingUser() { Id = u.Id, Email = u.Email, Firstname = u.Firstname, Lastname = u.Lastname });
            return (_users);
        }
        public async Task<ExistingUser> AddUser(NewUser newUser)
    {
            UserModel _newUser = new Domain.UserModel()
            {
                Firstname = newUser.Firstname,
                Lastname = newUser.Lastname,
                Email = newUser.Email,
            };
            UserModel _addedUser = await _unitOfWork.Users.AddUser(_newUser);
            await _unitOfWork.Commit();
            return await GetUser(_addedUser);
    }
  }
}
