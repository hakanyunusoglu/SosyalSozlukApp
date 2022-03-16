using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Entity
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public int CroocID { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
        public virtual Crooc Crooc { get; set; }
    }
}