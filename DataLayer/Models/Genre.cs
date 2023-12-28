using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Genre

    {
        [Key]
        public int GenreId { get; set; }


        [MaxLength(30)]
        [Display(Name ="ژانرفیلم")]
        [Required(ErrorMessage ="لطفا ژانر فیلم را وارد کنید")]

        public string GenreName { get; set; }

        #region Relations

        public IList<Movie> Movies { get; set; }

        #endregion


    }
}
