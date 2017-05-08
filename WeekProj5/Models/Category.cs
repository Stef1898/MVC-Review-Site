using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeekProj5.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Weapon Type")]
        public string WeaponType { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<WeapDetail> WeapDetails { get; set; }
    }
}