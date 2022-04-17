using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.DisCount
{
    public class UserDiscount
    {
        [Key]
        public int userdiscountid { get; set; }

        public int userid { get; set; }
        public int Discountid { get; set; }
        public int CartId { get; set; }
        public DateTime CreateDate { get; set; }



        #region Relation

        [ForeignKey(nameof(userid))]
        public user user { get; set; }

        [ForeignKey(nameof(Discountid))]
        public discount discount { get; set; }
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        #endregion


    }
}
