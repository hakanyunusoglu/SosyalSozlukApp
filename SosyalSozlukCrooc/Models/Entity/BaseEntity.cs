using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Entity
{
    public class BaseEntity
    {
        public int ID { get; set; }

        DateTime _addDate = DateTime.Now;
        public DateTime AddDate
        {
            get { return _addDate; }
            set { _addDate = value; }
        }

        private bool _IsDelete = false;
        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; }
        }

        DateTime _UpdateDate = DateTime.Now;
        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }

    }
}