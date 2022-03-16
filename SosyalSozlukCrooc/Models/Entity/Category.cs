using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Entity
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}