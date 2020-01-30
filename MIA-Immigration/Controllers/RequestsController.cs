using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using MIA_Immigration.Models;
using Rotativa;

namespace MIA_Immigration.Controllers
{
    public class RequestsController : Controller
    {
        private ModelDB db = new ModelDB();
        public int? TestId;
        // GET: Requests
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Countries).Include(a => a.Educations);
            return View(requests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }


            TempData["data1"] = id;
            TempData["data2"] = request.Full_Name + id;
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            ViewBag.CountryRID = new SelectList(db.CountryResidences, "CountryRID", "Name");

            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EducationName");

            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName");
            ViewBag.MoneyID = new SelectList(db.Moneys, "MoneyID", "Price");

          

            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Request category)
        {
            if (this.IsCaptchaValid("Validate your captcha"))
            {
                ViewBag.ErrMessage = "Validation Messgae";
            }

            if (ModelState.IsValid)
            {
                db.Requests.Add(category);
                db.SaveChanges();

                category.File.SaveAs(Server.MapPath("~/PDF/") + category.ID + ".pdf");
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", category.CountryID);
            ViewBag.CountryRID = new SelectList(db.CountryResidences, "CountryRID", "Name", category.CountryRID);

            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EducationName", category.EducationID);

            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", category.ProvinceID);
            ViewBag.MoneyID = new SelectList(db.Moneys, "MoneyID", "Price", category.MoneyID);


            return View(category);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            ViewBag.CountryRID = new SelectList(db.CountryResidences, "CountryRID", "Name");

            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EducationName");

            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName");
            ViewBag.MoneyID = new SelectList(db.Moneys, "MoneyID", "Price");
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Full_Name,Citizenship,Email,Marital_Status,Birthday,Country_of_Residence,Phone,Children_and_Ages,Profesional1,Profesional2,Profesional3,Profesional4,Profesional5,Profesional6,ToDo1,ToDo2,ToDo3,ToDo4,ToDo5,ToDo6,ToDo7,CountryID")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", request.CountryID);

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", request.CountryID);
            ViewBag.CountryRID = new SelectList(db.CountryResidences, "CountryRID", "Name", request.CountryRID);

            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EducationName", request.EducationID);

            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", request.ProvinceID);
            ViewBag.MoneyID = new SelectList(db.Moneys, "MoneyID", "Price", request.MoneyID);
            return View(request);
        }


        public ActionResult DownloadFile(Request category)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/PDF/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + TempData["data1"] + ".pdf");
            string fileName =  TempData["data2"] + ".pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }




        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }



        public ActionResult PrintPartialViewToPdf(int id)
        {
            using (ModelDB db = new ModelDB())
            {
                Request request = db.Requests.Include(e => e.Educations).Include(c => c.Countries).Include(cr => cr.CountryResidence).Include(p => p.Provinces).Include(m => m.Moneys).FirstOrDefault(c => c.ID == id);

                var report = new PartialViewAsPdf("~/Views/Shared/DetailsPDF.cshtml", request);
                return report;
            }

        }



        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
