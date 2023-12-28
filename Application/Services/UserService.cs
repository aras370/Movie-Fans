using Application.Interfaces;
using DataLayer;
using DataLayer.Models;
using DataLayer.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUser
    {

        Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            _context.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistUser(RegisterViewModel user)
        {
            return await _context.Users.AnyAsync(u => u.UserName == user.UserName);
        }

        public async Task<User> Login(LoginViewModel login)
        {
            return await _context.Users.Where(u => u.UserName == login.UserName && u.Password == login.Password)
                .FirstOrDefaultAsync();
        }
    }
}
