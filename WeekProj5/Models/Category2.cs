using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeekProj5.Models
{
    public class Category2
    {
        [Key]
        public int ID { get; set; }

        public string Weapon { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<WeapDetail> WeapDetails { get; set; }
    }
}