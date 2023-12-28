using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [MaxLength(30)]

        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل خودرا وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست")]

        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "کلمه عبور باید حداقل 4 کاراکتر انگلیسی باشد")]
        [MaxLength(4)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$",
         ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, " +
            "one digit, and one special character.")]
        public string Password { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا تکرار کلمه عبور خود را وارد کنید")]
        [Compare("Password", ErrorMessage = "کلمه های عبور وارد شده با هم مطابقت ندارند")]
        public string RePassword { get; set; }

    }
}
