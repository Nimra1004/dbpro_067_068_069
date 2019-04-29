using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB55.ViewModel
{
    public class DoctorModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public int Discriminator { get; set; }
        public string UserId { get; set; }
        public int LicenseNumber { get; set; }
    }

}