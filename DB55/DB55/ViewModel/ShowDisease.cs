using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB55.ViewModel
{
    public class ShowDisease
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "بیماری کا نام")]
        public string DiseaseName { get; set; }
        [Required]
        [Display(Name = "اعضاء")]
        public string PredictionName { get; set; }
        [Required]
        [Display(Name = "قسم")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "ڈاکٹر کا نام")]
        public string DoctorName { get; set; }
        [Required]
        [Display(Name = "وجہ")]
        public string ReasonName { get; set; }
        [Required]
        [Display(Name = "روا")]
        public string MedicineName { get; set; }
    }
}