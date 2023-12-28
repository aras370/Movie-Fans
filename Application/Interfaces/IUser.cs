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

        Task<bool>  IsExistUser(RegisterViewModel user);

        Task AddUser(User user);
    }
}
