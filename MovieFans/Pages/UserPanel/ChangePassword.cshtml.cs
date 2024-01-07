using Application.Interfaces;
using DataLayer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace Presentation.Pages.UserPanel
{
    public class ChangePasswordModel : PageModel
    {
        IUser _user;

        public ChangePasswordModel(IUser user)
        {
            _user = user;
        }

        public void OnGet()
        {

        }


        [BindProperty]
        public ChangePasswordViewModel Password { get; set; }

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!Regex.IsMatch(Password.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$"))
            {
                ModelState.AddModelError(string.Empty, "Password must have at least one lowercase letter, one uppercase letter, one digit, and one special character.");
                return Page();
            }

            await _user.ChangePasswordByUser(Password);

            return RedirectToPage("Index");
        }
    }
}
