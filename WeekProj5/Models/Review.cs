using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeekProj5.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Category2")]
        public int Category2ID { get; set; }
        public virtual Category2 Category2 { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Review")]
        public string CustomerReview { get; set; }

        [Display(Name = "Date Published")] [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }

    }
}