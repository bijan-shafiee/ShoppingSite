using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Role
{
    public class UserRole
    {
        [Key]
        public int userRoleid { get; set; }

        public int userid { get; set; }

        public int Roleid { get; set; }

        #region Relation

        [ForeignKey(nameof(userid))]
        public user user { get; set; }

        [ForeignKey(nameof(Roleid))]
        public role role { get; set; }
        #endregion
    }
}
