using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Biography { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Linkedin { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Nickname { get; set; }

        public string Recovery_Code { get; set; }

        private string _profilepicture = "/Areas/Crooc/Content/images/avatar.png";
        public string ProfilePicture
        {
            get { return _profilepicture; }
            set { _profilepicture = value; }
        }

        public DateTime? LastLogin { get; set; }

        private bool _firstTimeLogin = true;
        public bool FirstTimeLogin
        {
            get { return _firstTimeLogin; }
            set { _firstTimeLogin = value; }
        }
    }
}