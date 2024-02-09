using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUser
    {
        Task<User> Login(LoginViewModel login);

        Task<bool> IsExistUser(RegisterViewModel user);

        Task AddUser(User user);

        Task<EditUserByUserViewModel> GetUserForEditByUser(int userId);

        Task<User> GetUserById(int id);

        Task EditUserByUser(EditUserByUserViewModel user);

        Task ChangePasswordByUser(ChangePasswordViewModel Password);

        Task<List<string>> GetAllUserRoles(int userId);
    }
}
