using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB55.Controllers
{
    public class MedicineReportController : Controller
    {
        private DB55Entities db = new DB55Entities();
        public ActionResult Index()
        {
            ViewBag.ListMedicine = db.Medicines.ToList();
            return View();
        }
        public ActionResult Export()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/AdvisorReport.rdlc")));
            rd.SetDataSource(db.Medicines.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Details = p.Details,
                DoctorId = p.DoctorId

            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Medicines.pdf");

        }

    }
}