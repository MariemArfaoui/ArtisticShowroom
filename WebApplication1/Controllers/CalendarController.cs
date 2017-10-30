using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    //[Authorize(Roles ="Client")]
    public class CalendarController : Controller
    {

        EventServices ES = new EventServices();
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {

            var events = ES.GetAll();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;
            
                if (e.eventId > 0)
                {
                    //Update the event
                    var v = ES.GetAll().Where(a => a.eventId == e.eventId).FirstOrDefault();
                    if (v != null)
                    {
                        v.title = e.title;
                        v.description = e.description;
                        v.startDate = e.startDate;
                        v.endDate = e.endDate;
                        v.inclusions = e.inclusions;
                        v.actualDate = DateTime.Now;
                  
                }
                }
                else
                {
                    ES.Add(e);
                }
                ES.Commit();
                status = true;
            

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventId)
        {
            var status = false;
            
                var v = ES.GetAll().Where(a => a.eventId == eventId).FirstOrDefault();
                if (v != null)
                {
                    ES.Delete(v);
                    ES.Commit();
                    status = true;
                }
            
            return new JsonResult { Data = new { status = status } };
        }

        // GET: Calendar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calendar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calendar/Create
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

        // GET: Calendar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calendar/Edit/5
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

        // GET: Calendar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calendar/Delete/5
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
