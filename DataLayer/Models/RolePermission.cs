using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class RolePermission

    {
        [Key]
        public int RpId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }



        #region Relations

        public Role Role { get; set; }

        public Permission Permission { get; set; }

        #endregion
    }
}
