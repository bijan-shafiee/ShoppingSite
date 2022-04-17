using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities
{
    public class CartDetail
    {
        [Key]
        public int CartDetailid { get; set; }

        public int productid { get; set; }

        public int count { get; set; }

        public long PriceWithoutDiscount { get; set; }

        public int price { get; set; }

        public DateTime CreateDate { get; set; }

        public int Cartid { get; set; }

        #region Relation

        [ForeignKey(nameof(Cartid))]
        public Cart Cart { get; set; }

        #endregion

    }
}
