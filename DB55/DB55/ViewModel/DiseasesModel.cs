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
        
        public static List<SelectListItem> GetPredictionId()
        {
            DB55Entities entities = new DB55Entities();
            List<SelectListItem> listDiseases = (from p in entities.Lookups.AsEnumerable()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.Value,
                                                     Value = p.Id.ToString()
                                                 }).ToList();


            //Add Default Item at First Position.
            return listDiseases;
        }

        public static List<SelectListItem> GetCategoryId()
        {
            DB55Entities entities = new DB55Entities();
            List<SelectListItem> listDiseases = (from p in entities.Categories.AsEnumerable()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.Name,
                                                     Value = p.Id.ToString()
                                                 }).ToList();


            //Add Default Item at First Position.
            return listDiseases;
        }

    }
}