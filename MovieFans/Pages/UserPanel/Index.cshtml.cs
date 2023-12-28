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

        public void OnGet()
        {
            ViewData["Email"] = User.FindFirst(ClaimTypes.Email).Value;
        }

     
    }
}
