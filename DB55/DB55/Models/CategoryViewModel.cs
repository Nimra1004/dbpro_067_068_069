using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB55.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

    }
}