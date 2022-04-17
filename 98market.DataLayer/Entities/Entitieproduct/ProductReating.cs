using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
     public class ProductReating
     {
        [Key]
        public int Reatingid { get; set; }

        public int productid { get; set; }

        public int userid { get; set; }

        public int propnameid { get; set; }


        public byte Value { get; set; }


        #region Relation

        [ForeignKey(nameof(productid))]
        public product product { get; set; }

       /*reignKey(nameof(userid))]
        public user user { get; set; }*/

        [ForeignKey(nameof(propnameid))]
        public PropertyName PropertyName { get; set; }
        #endregion
    }
}
