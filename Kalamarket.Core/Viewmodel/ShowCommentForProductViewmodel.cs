using System;
using System.Collections.Generic;
using System.Text;

namespace _98market.Core.Viewmodel
{
    public class ShowCommentForProductViewmodel
    {
        public int CommentId { get; set; }
        public string username { get; set; }
        public DateTime CreateDate { get; set; }
        public byte Recomment { get; set; }

        public string commentTitle { get; set; }

        public string CommentDescription { get; set; }

        public int Commentlike { get; set; }
        public int commentDislike { get; set; }

        public int Star { get; set; }

        public int Quality { get; set; }

        public int BuyWorth { get; set; }

        public int Innovation { get; set; }

        public int Abilities { get; set; }

        public int EaseOfUse { get; set; }

        public int Appearance { get; set; }
    }
}
