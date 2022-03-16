using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Entity
{
    public class UserSetting : BaseEntity
    {
        public bool Profile { get; set; }
        public bool ProfilePicture { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}