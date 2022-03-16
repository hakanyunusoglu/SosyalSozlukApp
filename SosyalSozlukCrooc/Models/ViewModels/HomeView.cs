using SosyalSozlukCrooc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.ViewModels
{
    public class HomeView
    {
        public IEnumerable<Crooc> Croocs_icerik { get; set; }
        public IEnumerable<Crooc> Croocs_soru { get; set; }
        public IEnumerable<Crooc> Croocs_video { get; set; }
        public IEnumerable<Crooc> Croocs_anket { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}