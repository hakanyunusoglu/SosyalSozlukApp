using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Entity
{
    public class Poll : BaseEntity
    {
        public string Name { get; set; }

        int _value = 0;
        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int CroocID { get; set; }

        public virtual Crooc Crooc { get; set; }
    }
}