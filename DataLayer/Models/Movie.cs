using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        [Display(Name ="نام فیلم")]
        [MaxLength(30)]
        [Required(ErrorMessage ="لطفا نام فیلم را وارد کنید")]

        public string MovieName { get; set; }

       

        [Required(ErrorMessage ="لطفا سال ساخت فیلم را وارد کنید")]
        [Display(Name ="سال ساخت")]
        [MaxLength(30)]

        public int DateOfMake { get; set; }

        [Required]
        public string ImageName { get; set; }


        #region Relations

        public Genre Genre { get; set; }

        public List<MovieCasts> MovieCasts { get; set; }

        #endregion

    }
}
