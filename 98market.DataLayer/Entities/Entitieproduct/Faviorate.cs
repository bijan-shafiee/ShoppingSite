using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    public class Faviorate
    {
        [Key]
        public int Faviorateid { get; set; }

        public int userid { get; set; }

        public int productid { get; set; }


        #region Relation

        [ForeignKey(nameof(productid))]
        public product product { get; set; }


        [ForeignKey(nameof(userid))]
        public user user { get; set; }

        #endregion
    }
}
