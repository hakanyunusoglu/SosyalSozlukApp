using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Entity
{
    public class Story : BaseEntity
    {
        public int Title { get; set; }
        public string CoverImage { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        public int View { get; set; }
        public int Like { get; set; }


        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}