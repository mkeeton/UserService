using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.Data.EF.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel?> GetUser(Guid userId);
        Task<UserModel> AddUser(UserModel newUser);
    }
}
