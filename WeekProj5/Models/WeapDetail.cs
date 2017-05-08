using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeekProj5.Models
{
    public class WeapDetail
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Category2")]
        public int Category2ID { get; set; }
        public virtual Category2 Category2 { get; set; }

        public string Description { get; set; }

    }
}