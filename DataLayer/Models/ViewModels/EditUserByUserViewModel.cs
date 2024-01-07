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



      

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل خودرا وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست")]

        public string Email { get; set; }

     



        public string AvatarName { get; set; }


        public IFormFile UserAvatar { get; set; }

    }
}
