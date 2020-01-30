using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIA_Immigration.Models;

namespace MIA_Immigration.Controllers
{
    public class HomeController : Controller
    {
        private ModelDB db = new ModelDB();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Test()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Request requests)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Requests.Add(requests);
            //    db.SaveChanges();


            //    requests.File.SaveAs(Server.MapPath("~/PDF/") + requests.Full_Name + ".pdf");

            //    return RedirectToAction("Index");
            //}

            return View(requests);
        }
    }
}