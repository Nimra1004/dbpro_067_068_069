using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB55.Models;
using System.Web.Mvc;

namespace DB55.ViewModel
{
    public class Prediction
    {
        public int MedicineId { get; set; }
        public int DiseaseId { get; set; }
        public static List<SelectListItem> GetDiseaseId()
        {
            DB55Entities entities = new DB55Entities();
            List<SelectListItem> listDiseases = (from p in entities.Diseases.AsEnumerable()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.Name,
                                                     Value = p.Id.ToString(),
                                                 }).ToList();


            //Add Default Item at First Position.

            return listDiseases;
        }
        public static List<SelectListItem> GetMedicineId()
        {
            DB55Entities entities = new DB55Entities();
            List<SelectListItem> listmed = (from p in entities.Medicines.AsEnumerable()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.Name,
                                                     Value = p.Id.ToString(),
                                                 }).ToList();


            //Add Default Item at First Position.

            return listmed;
        }
    }
}