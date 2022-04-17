using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    public class ProductView
    {
        [Key]
        public int ProductViewId { get; set; }
        #region Foreign Keys
        public int userid { get; set; }
        public int productid { get; set; }
        #endregion
        #region Relations
        public product Product { get; set; }
        public user User { get; set; }
        #endregion
    }
}
