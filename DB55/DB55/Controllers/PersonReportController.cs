using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using DB55.Models;
using DB55.Reports;
namespace DB55.Controllers
{
    public class PersonReportController : Controller
    {
        private DB55Entities db = new DB55Entities();
        public ActionResult Index()
        {
            ViewBag.ListPersons = db.People.ToList();

            return View();
        }
        public ActionResult Export()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/CrystalReportPerson.rpt")));
            rd.SetDataSource(db.People.Select(p => new
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Contact = p.Contact,
                Country = p.Country,
                Email = p.Email,
                Gender = p.Gender,
                Discriminator = p.Discriminator

            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "RegisteredUsers.pdf");
            
        }
        
    }
}