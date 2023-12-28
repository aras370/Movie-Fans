using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        public string PermissionName { get; set; }

        #region Relations

        public IList<RolePermission> RolePermission { get; set; }

        #endregion
    }
}
