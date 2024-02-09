using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CreateMovieViewModel
    {

        [Display(Name = "نام فیلم")]
        [MaxLength(30)]
        [Required(ErrorMessage = "لطفا نام فیلم را وارد کنید")]

        public string MovieName { get; set; }

        [Required(ErrorMessage = "لطفا ژانر فیلم را وارد کنید")]
        [Display(Name = "ژانر")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "لطفا سال ساخت فیلم را وارد کنید")]
        [Display(Name = "سال ساخت")]
     
        public int DateOfMake { get; set; }

        [Required(ErrorMessage = "لطفاعکس فیلم را وارد کنید")]

        public IFormFile MovieAvatar{ get; set; }

    }
}
