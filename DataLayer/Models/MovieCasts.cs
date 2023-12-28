using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MovieCasts
    {

        [Key]      
        public int MovieCastId { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }


        [Display(Name ="بازیگر")]
        [Required(ErrorMessage ="لطفا نام بازیگر را وارد کنید")]
        [MaxLength(30)]

        public string CastName { get; set; }

        #region Relations

        public Movie Movie { get; set; }

        #endregion

    }
}
