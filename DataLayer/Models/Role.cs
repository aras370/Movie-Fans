using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        #region Relations

        public IList<RolePermission> RolePermission { get; set; }

        public IList<UserRole> UserRoles { get; set; }

        #endregion
    }
}
