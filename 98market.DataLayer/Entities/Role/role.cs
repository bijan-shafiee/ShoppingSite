using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.DataLayer.Entities.Role
{
    public class role
    {
        [Key]
        public int roleid { get; set; }

        public string roltitle { get; set; }


        #region Relation
        public List<RolePermission> rolePermissions { get; set; }
        public List<UserRole> UserRoles { get; set; }
        #endregion

    }
}
