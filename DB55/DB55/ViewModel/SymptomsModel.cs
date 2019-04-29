using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB55.ViewModel
{
    public class SymptomsModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorId { get; set; }
        public int DiseaseId { get; set; }
        public bool ckecked { get; set; }


    }
}