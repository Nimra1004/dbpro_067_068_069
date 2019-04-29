using DB55.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB55.ViewModel;

namespace DB55.Controllers
{
    public class CategoryController : Controller
    {
        DB55Entities db = new DB55Entities();
        List<int> SelectedIds = new List<int>();

        // GET: Category
        public ActionResult Index()
        {
            
            List<Category> list1 = db.Categories.ToList();
            List<CategoryViewModel> viewList = new List<CategoryViewModel>();
            foreach (Category s in list1)
            {
                CategoryViewModel obj = new CategoryViewModel();
                obj.Id = s.Id;
                obj.Name = s.Name;
                viewList.Add(obj);

            }
            return View(viewList);

           
        }

        // GET: Category/Details/5
        public ActionResult SelectSymptoms(int id)
        {
            List<Symptom> list1 = db.Symptoms.ToList();

            List<Disease> list2 = db.Diseases.ToList();

            List<SymptomsModel> viewList = new List<SymptomsModel>();
            foreach (Symptom s in list1)
            {
                foreach(Disease d in list2)
                {

                    if (s.DiseaseId == d.Id && d.CategoryId == id)
                    {
                        SymptomsModel obj = new SymptomsModel();
                        obj.Id = s.Id;
                        obj.Name = s.Name;
                        obj.DoctorId = s.DoctorId;
                        obj.DiseaseId = s.DiseaseId;
                        obj.ckecked = false;
                        viewList.Add(obj);
                    }
                }       
            }
            return View(viewList);
            //return View("SelectSymptoms");
        }

        //hhtppost: Select
        [HttpPost]
        public ActionResult SelectSymptoms(List<SymptomsModel> list)
        {
            var userSelectedProducts = list.Where(m => m.ckecked);
            List<Disease> list1 = db.Diseases.ToList();
            List<ShowDisease> list2 = new List<ShowDisease>();
            if (userSelectedProducts != null && userSelectedProducts.Any())
            {

                List<Lookup> Lokup = db.Lookups.ToList();

                List<Person> doc_list = db.People.ToList();

                List<Category> cat_list = db.Categories.ToList();

                List<PredictedTreatment> Pre_trt = db.PredictedTreatments.ToList();

                List<Medicine> Med_trt = db.Medicines.ToList();

                List<Reason> reas_list = db.Reasons.ToList();

                foreach (SymptomsModel s in list)
                {
                    foreach (Disease d in list1)
                    {
                        if (s.ckecked == true && s.DiseaseId == d.Id)
                        {
                            ShowDisease obj = new ShowDisease();
                            obj.Id = d.Id;
                            obj.DiseaseName = d.Name;

                            foreach (Lookup f in Lokup)
                            {
                                if (f.Id == d.PredictionID && f.Category == "PredictionID")
                                {
                                    obj.PredictionName = f.Value;
                                }
                                else
                                {

                                }
                            }

                            foreach (Person f in doc_list)
                            {
                                if (f.Id == d.DoctorId)
                                {
                                    obj.DoctorName = f.FirstName + " " + f.LastName;
                                }
                                else
                                {

                                }
                            }

                            foreach (Category f in cat_list)
                            {
                                if (f.Id == d.CategoryId)
                                {
                                    obj.CategoryName = f.Name;
                                }
                                else
                                {

                                }
                            }

                            foreach (Reason f in reas_list)
                            {
                                if (f.DoctorId == d.DoctorId && f.DiseaseId == s.DiseaseId)
                                {
                                    obj.ReasonName = f.Name;
                                }
                                else
                                {

                                }
                            }

                            foreach (PredictedTreatment f in Pre_trt)
                            {
                                if (f.DiseaseId == s.DiseaseId)
                                {
                                    foreach (Medicine m in Med_trt)
                                    {
                                        if (f.MedicineId == m.Id)
                                        {
                                            obj.MedicineName = m.Name;
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                                else
                                {

                                }
                            }
                            list2.Add(obj);

                        }
                    }
                }

                
            }
            return View("Select", list2);
        }



        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                DB55Entities db = new DB55Entities();
                //var userdbmodel = db.AspNetUsers.Where(a => a.Email.Equals(model.Email)).FirstOrDefault();
                Category c = new Category();
                c.Name = model.Name;
                db.Categories.Add(c);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        

       

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
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
    }
}
