using Artistic_Showroom_Web.Models;
using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookingController : Controller
    {

        BookingService BS = new BookingService();
        UserService US = new UserService();
        EventServices ES = new EventServices();

        //GET : ListEvent
        public ActionResult GetListEvent()
        {
            List<EventViewModels> eventList = new List<EventViewModels>();

            foreach (var item in ES.GetAll())
            {       

                EventViewModels EVM = new EventViewModels();
               
                    EVM.eventId = item.eventId;
                    EVM.statEvent = item.statEvent;
                    EVM.userId = item.userId;
                    EVM.title = item.title;
                    EVM.description = item.description;
                    EVM.inclusions = item.inclusions;
                    EVM.startDate = item.startDate;
                    EVM.actualDate = DateTime.Now;
                    EVM.endDate = item.endDate;
                    EVM.imageURL = item.imageURL;
                    EVM.nbParticipant = item.nbParticipant;
                    eventList.Add(EVM);

                
            }

            return View(eventList);
        }

        //GET : ParticipantList
        public ActionResult GetParticipateUsers(int id)
        {
            List<UserViewModel> ListUsers = new List<UserViewModel>();

            foreach (var item in BS.getUsersParticipate(id))
            {
                User u = US.GetById(item);

                UserViewModel UVM = new UserViewModel();

                    UVM.firstName = u.firstName;
                    UVM.lastName = u.lastName;
                     UVM.email = u.email;
                    ListUsers.Add(UVM);

                }
            return View(ListUsers);
        }

            
        

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
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

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
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

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
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
