using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB55.ViewModel;
using DB55.Models;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;

namespace DB55.Controllers
{
    public class DiseaseController : Controller
    {
        // GET: Disease
        public ActionResult Index()
        {

            return View();

        }
        [HttpGet]
        public ActionResult AddDisease()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDisease(DiseasesModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {

                    DB55Entities db = new DB55Entities();
                    int docID = 0;
                    int CatId = 0;
                    int predId = 0;
                    //---------------------------------------------------------------------
                    List<PersonModel> viewlist = new List<PersonModel>();
                    PersonModel obj = new PersonModel();
                    List<Person> list1 = db.People.ToList();
                    string Login = User.Identity.GetUserId();
                    for (int i = 0; i < list1.Count(); i++)
                    {
                        Person req = list1.ElementAt(i);
                        if (req.UserId == Login)
                        {
                            docID = req.Id;
                        }
                    }
                    //---------------------------------------------------------------------
                    List<CategoryViewModel> viewlist2 = new List<CategoryViewModel>();
                    CategoryViewModel obj2 = new CategoryViewModel();
                    List<Category> list2 = db.Categories.ToList();
                    int Cat = model.CategoryId;
                    for (int i = 0; i < list2.Count(); i++)
                    {
                        Category req = list2.ElementAt(i);
                        if (req.Id == Cat) // change with name
                        {
                            CatId = req.Id;
                        }
                    }
                    //----------------------------------------------------------------------

                    List<CategoryViewModel> viewlist3 = new List<CategoryViewModel>();
                    CategoryViewModel obj3 = new CategoryViewModel();
                    List<Lookup> list3 = db.Lookups.ToList();
                    int pred = model.PredictionID;
                    for (int i = 0; i < list3.Count(); i++)
                    {
                        Lookup req = list3.ElementAt(i);
                        if (req.Id == pred)
                        {
                            predId = req.Id;
                        }
                    }
                    //-------------------------------------------------                    
                    Disease d1 = new Disease();
                    d1.Name = model.Name;
                    d1.PredictionID = predId;
                    d1.DoctorId = docID;
                    d1.CategoryId = CatId;
                    db.Diseases.Add(d1);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
            return View();

        }
        // GET: Disease/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Disease/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disease/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Disease/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Disease/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Disease/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Disease/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddReason(ReasonModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DB55Entities db = new DB55Entities();
                    int docID = 0;
                    //---------------------------------------------------------------------
                    List<PersonModel> viewlist = new List<PersonModel>();
                    PersonModel obj = new PersonModel();
                    List<Person> list1 = db.People.ToList();
                    string Login = User.Identity.GetUserId();
                    for (int i = 0; i < list1.Count(); i++)
                    {
                        Person req = list1.ElementAt(i);
                        if (req.UserId == Login)
                        {
                            docID = req.Id;
                        }
                    }
                    //---------------------------------------------------------------------
                    int dID = Convert.ToInt32(model.DiseaseId);
                    Reason r1 = new Reason();
                    r1.Name = model.Name;
                    r1.DoctorId = docID;
                    r1.DiseaseId = model.DiseaseId;
                    db.Reasons.Add(r1);
                    db.SaveChanges();

                    db.SaveChanges();

                    return RedirectToAction("Index", "Disease");
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
            return View();

        }

        public ActionResult AddSymptom(SymptomsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DB55Entities db = new DB55Entities();
                    int docID = 0;
                    //---------------------------------------------------------------------
                    List<PersonModel> viewlist = new List<PersonModel>();
                    PersonModel obj = new PersonModel();
                    List<Person> list1 = db.People.ToList();
                    string Login = User.Identity.GetUserId();
                    for (int i = 0; i < list1.Count(); i++)
                    {
                        Person req = list1.ElementAt(i);
                        if (req.UserId == Login)
                        {
                            docID = req.Id;
                        }
                    }
                    //---------------------------------------------------------------------
                    Symptom s1 = new Symptom();
                    s1.Name = model.Name;
                    s1.DoctorId = docID;
                    s1.DiseaseId = model.DiseaseId;
                    db.Symptoms.Add(s1);
                    db.SaveChanges();

                    db.SaveChanges();

                    return RedirectToAction("Index", "Disease");
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
            return View();

        }

        public ActionResult AddMedicine(MedicineModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DB55Entities db = new DB55Entities();
                    int docID = 0;
                    //---------------------------------------------------------------------
                    List<PersonModel> viewlist = new List<PersonModel>();
                    PersonModel obj = new PersonModel();
                    List<Person> list1 = db.People.ToList();
                    string Login = User.Identity.GetUserId();
                    for (int i = 0; i < list1.Count(); i++)
                    {
                        Person req = list1.ElementAt(i);
                        if (req.UserId == Login)
                        {
                            docID = req.Id;
                        }
                    }
                    //---------------------------------------------------------------------
                    Medicine m1 = new Medicine();
                    m1.Name = model.Name;
                    m1.Details = model.Details;
                    m1.DoctorId = docID;
                    db.Medicines.Add(m1);
                    db.SaveChanges();

                    db.SaveChanges();

                    return RedirectToAction("Index", "Disease");
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
            return View();

        }
        [HttpGet]
        public ActionResult AddTreatment()
        {
            return View("AddTreatment");
        }
        [HttpPost]
        public ActionResult AddTreatment(Prediction model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DB55Entities db = new DB55Entities();
                    //---------------------------------------------------------------------
                    PredictedTreatment m1 = new PredictedTreatment();

                    //---------------------------------------------------------------------
                    m1.DiseaseId = model.DiseaseId;
                    m1.MedicineId = model.MedicineId;

                    db.PredictedTreatments.Add(m1);
                    db.SaveChanges();

                    db.SaveChanges();

                    return RedirectToAction("Index", "Disease");
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
            return View();
        }
        private static List<SelectListItem> GetDiseaseId()
        {
            DB55Entities entities = new DB55Entities();
            List<SelectListItem> listDiseases = (from p in entities.Diseases.AsEnumerable()
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
