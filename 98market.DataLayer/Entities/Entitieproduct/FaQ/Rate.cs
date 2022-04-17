using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace _98market.DataLayer.Entities.Entitieproduct.FaQ
{
    public class Rate
    {
        [Key]
        public int RateId { get; set; }
        public int Star { get; set; }
        #region Foreign Keys
        public int userid { get; set; }
        public int productid { get; set; }
        #endregion
        #region Relations
        public user User { get; set; }
        public product Product { get; set; }
        #endregion
    }
}
