using Application.Interfaces;
using DataLayer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Presentation.Pages.UserPanel
{
    public class EditModel : PageModel
    {

        IUser _user;
        ILogger<EditModel> _logger;


        public EditModel(IUser user, ILogger<EditModel> logger)
        {
            _user = user;
            _logger = logger;

        }


        [BindProperty]

        public EditUserByUserViewModel User { get; set; }


        public async Task OnGet(int userid)
        {
            User = await _user.GetUserForEditByUser(userid);
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }




            await _user.EditUserByUser(User);

            return RedirectToPage("Index");


            //try
            //{
            //    await _user.EditUserByUser(User);

            //}
            //catch (Exception ex)
            //{
            //    _logger.Log(LogLevel.Error, ex.Message);
            //}

            //return RedirectToPage("Index");



        }

    }
}


