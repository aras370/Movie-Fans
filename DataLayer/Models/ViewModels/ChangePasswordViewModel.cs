using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور خود را وارد کنید")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$",
         ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, " +
            "one digit, and one special character.")]
        public string Password { get; set; }


        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور خود را وارد کنید")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

    }
}
