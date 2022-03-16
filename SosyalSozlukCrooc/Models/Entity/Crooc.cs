using SosyalSozlukCrooc.Models.Attributes.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Entity
{
    public class Crooc : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ContentType { get; set; }
        int _view = 0;
        public int view
        {
            get { return _view; }
            set { _view = value; }
        }
         
       
        public int UserID { get; set; }
       
        int _like = 0;
        public int like
        {
            get { return _like; }
            set { _like = value; }
        }

        public virtual User User { get; set; }
       
    }
}