using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class EditUserByUserViewModel
    {

        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [MaxLength(30)]

        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل خودرا وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست")]

        public string Email { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور خود را وارد کنید")]
        [MaxLength(30)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$",
         ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, " +
            "one digit, and one special character.")]
        public string Password { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور خود را وارد کنید")]
        [MaxLength(30)]
        [Compare("Password")]
        public string RePassword { get; set; }


        public IFormFile MyProperty { get; set; }

    }
}
