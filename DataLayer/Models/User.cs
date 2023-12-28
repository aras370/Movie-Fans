using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }


        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="لطفا نام کاربری را وارد کنید")]
        [MaxLength(30)]

        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل خودرا وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage ="فرمت ایمیل وارد شده صحیح نیست")]

        public string Email { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور خود را وارد کنید")]
        [MaxLength(30)]
        
        public string Password { get; set; }


        public string AvatarName { get; set; }

        public bool IsAdmin { get; set; }


        #region Relations

        public IList<Comment> Comments { get; set; }

        public IList<UserRole> UserRoles { get; set; }

        #endregion


    }
}
