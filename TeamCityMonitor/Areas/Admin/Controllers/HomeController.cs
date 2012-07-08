using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BuildMonitor.Models;
using Simple.Data;

namespace BuildMonitor.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Default1/

        private dynamic GetDatabase()
        {
            var dbFile = Server.MapPath("~/App_Data/ApplicationData.db");
            var db = Database.OpenFile(dbFile);

            return db;
        }

        public ActionResult Index()
        {
            var features = GetDatabase().Feature.All();
            return View(features);
        }

        //
        // GET: /Admin/Default1/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Default1/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Default1/Create

        [HttpPost]
        public ActionResult Create(Feature feature)
        {
            try
            {

                GetDatabase().Feature.Insert(FeatureName: feature.FeatureName, Enabled: feature.Enabled);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        
        //
        // GET: /Admin/Default1/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Default1/Edit/5

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

        //
        // GET: /Admin/Default1/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Default1/Delete/5

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
