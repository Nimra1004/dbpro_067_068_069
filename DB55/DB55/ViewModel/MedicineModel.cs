using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB55.Models;
using System.Web.Mvc;

namespace DB55.ViewModel
{
    public class MedicineModel
    {
        
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int DoctorId { get; set; }
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

    }
}