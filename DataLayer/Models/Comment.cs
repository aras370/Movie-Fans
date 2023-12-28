using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Comment

    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required(ErrorMessage ="لطفا دیدگاه خودرا وارد کنید")]
        [MaxLength(300)]
        [Display(Name ="دیدگاه")]

        public string CommentText { get; set; }

        [Display(Name = "تاریخ ثبت دیدگاه")]

        public DateTime CreationDate { get; set; }


        #region Relations

        public User User { get; set; }

        #endregion

    }
}
