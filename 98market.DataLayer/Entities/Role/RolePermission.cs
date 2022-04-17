using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Role
{
  public  class RolePermission
    {
        [Key]
        public int RolPermissionid { get; set; }

        public int Roleid { get; set; }

        public int Permissionid { get; set; }


        #region Relation

        [ForeignKey(nameof(Roleid))]
        public role role { get; set; }


        [ForeignKey(nameof(Permissionid))]
        public permission permission { get; set; }

        #endregion


    }
}
