using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB55.ViewModel
{
    public class ShowDisease
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; }
        public string PredictionName { get; set; }
        public string CategoryName { get; set; }
        public string DoctorName { get; set; }
        public string ReasonName { get; set; }
        public string MedicineName { get; set; }
    }
}