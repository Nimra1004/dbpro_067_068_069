using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB55.ViewModel
{
    public class DiseasesModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorId { get; set; }
        public int PredictionID { get; set; }
        public int CategoryId { get; set; }

        public static IEnumerable<SelectListItem> GetPredictionId()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new  SelectListItem{Text = "بیماری", Value = "6" },
                new  SelectListItem{Text = "حالت", Value = "7" },
            };
            return items;
        }

        public static IEnumerable<SelectListItem> GetCategoryId()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new  SelectListItem{Text = "سر", Value = "1" },
                new  SelectListItem{Text = "ٹانگ", Value = "2" },
                new  SelectListItem{Text = "پیٹ", Value = "3" },
                new  SelectListItem{Text = "منہ", Value = "4" },
                new  SelectListItem{Text = "آنکھ", Value = "5" },
                new  SelectListItem{Text = "ناک", Value = "6" },
                new  SelectListItem{Text = "پاؤں", Value = "7" },

            };
            return items;
        }
    }
}