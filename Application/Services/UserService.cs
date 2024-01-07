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


        public async Task<EditUserByUserViewModel> GetUserForEditByUser(int userId)
        {
            return await _context.Users.Where(u => u.UserId == userId).Select(u => new EditUserByUserViewModel
            {
                AvatarName = u.AvatarName,
                UserId = userId,
                Email = u.Email,
            }).FirstOrDefaultAsync();
           
        }

        public async Task EditUserByUser(EditUserByUserViewModel user)
        {
            if (user.UserAvatar!=null)
            {
                string imagePath = "";
                if (user.AvatarName != "Defaulte.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UsersAvatars", user.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
                user.AvatarName = user.UserId + Path.GetExtension(user.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UsersAvatars", user.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }

            var olduser =await GetUserById(user.UserId);
            olduser.AvatarName=user.AvatarName;
            olduser.Email = user.Email;
            _context.Update(olduser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task ChangePasswordByUser(ChangePasswordViewModel Password)
        {
            var user=await _context.Users.FindAsync(Password.UserId);
            user.Password=Password.Password;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
