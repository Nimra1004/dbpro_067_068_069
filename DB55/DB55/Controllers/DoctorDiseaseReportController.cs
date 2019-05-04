using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using DB55.Models;
using DB55.Reports;
using DB55.ViewModel;

namespace DB55.Controllers
{
    public class DoctorDiseaseReportController : Controller
    {
        private DB55Entities db = new DB55Entities();
        public ActionResult Index()
        {
            List<Person> d1 = db.People.ToList();
            List<Doctor> d2 = db.Doctors.ToList();
            //PersonViewModel d = new PersonViewModel();
            //DoctorViewModel disease = new DoctorViewModel();
            List<PersonViewModel> list = d1.Select(x => new PersonViewModel
            { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, dId = x.Doctor.Id, LsNo = x.Doctor.LicenseNumber }).ToList();
            List<DoctorViewModel> list1 = d2.Select(x => new DoctorViewModel
            {Id = x.Id}).ToList();
            return View();
        }
        public ActionResult Export()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/DoctorDisease.rpt")));
            rd.SetDataSource(db.Doctors.Select(p => new
            {
                Id = p.Id,
                LicenseNumber = p.LicenseNumber
            }).ToList());
            rd.SetDataSource(db.People.Select(p => new
            {
                FirstName = p.FirstName,
                LastName = p.LastName,

            }).ToList());
            rd.SetDataSource(db.Symptoms.Select(p => new
            {
                Id = p.Id,
                Name = p.Name
            }).ToList());
            rd.SetDataSource(db.Reasons.Select(p => new
            {
                Id = p.Id,
                Name = p.Name
            }).ToList());
            rd.SetDataSource(db.Diseases.Select(p => new
            {
                Id = p.Id,
                Name = p.Name
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "RegisteredUsers.pdf");

        }
        public ActionResult ExportDisease()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/ReportsOfDiseases.rpt")));
            rd.SetDataSource(db.Diseases.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                PredictionId = p.PredictionID,
                DoctorId = p.DoctorId,
                CategoryId = p.CategoryId

            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Diseases.pdf");

        }
        

    }
}