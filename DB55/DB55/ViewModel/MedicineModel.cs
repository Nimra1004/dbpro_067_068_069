using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB55.ViewModel
{
    public class MedicineModel
    {
        
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int DoctorId { get; set; }

       
    }
}