using Application.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Presentation.Pages.UserPanel
{
    [Authorize]
    public class IndexModel : PageModel
    {

        IUser _user;

        public IndexModel(IUser user)
        {
            _user = user;
        }

        [BindProperty]
        public User User1{ get; set; } 

        public async Task OnGet()
        {
          
            User1 =await _user.GetUserById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

     
    }
}
