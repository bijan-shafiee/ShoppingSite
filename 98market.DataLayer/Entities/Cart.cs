using _98market.DataLayer.Entities.DisCount;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities
{
    public class Cart
    {
        [Key]
        public int cartid { get; set; }

        public int userid { get; set; }

        public bool ispay { get; set; }

        public string RefId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TotalPrice { get; set; }
        public int FinalPrice { get; set; }
        public int Status { get; set; }
        public string TrackingCode { get; set; }
        public string Description { get; set; }

        #region Relation

        [ForeignKey(nameof(userid))]
        public user user { get; set; }

        public List<CartDetail> cartDetails { get; set; }
        public List<UserDiscount> UserDiscount { get; set; }

        #endregion

    }
}
