using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _98market.DataLayer.Entities.DisCount
{
    public class discount
    {
        [Key]
        public int discountid { get; set; }

        public string discountcode { get; set; }

        public int Discountpersent { get; set; }

        public int? Useablecount { get; set; }
        public int MinPrice { get; set; }

        public bool IsDelete { get; set; }


        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        #region Relation
        public List<UserDiscount> UserDiscount { get; set; }
        #endregion

    }
}
