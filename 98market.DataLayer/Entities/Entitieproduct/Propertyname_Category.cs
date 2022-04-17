using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _98market.DataLayer.Entities.Entitieproduct
{
    public class Propertyname_Category
    {
        [Key]
        public int pcId { get; set; }

        public int PropertyNameId { get; set; }

        public int Categoryid { get; set; }

        #region Relation
        [ForeignKey("Categoryid")]
        public Category Category { get; set; }

        [ForeignKey("PropertyNameId")]
        public PropertyName PropertyName { get; set; }
        #endregion
    }
}
