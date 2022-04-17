using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.DataLayer.Entities.Role
{
    public class permission
    {
        [Key]
        public int permissionid { get; set; }

        public string permissionTitle { get; set; }

        #region Relation
        public List<RolePermission> rolePermissions { get; set; }
        #endregion

    }
}
