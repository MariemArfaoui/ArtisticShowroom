using Artistic_Showroom_Web.Models;

using Domain.Entities;

using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using WebApplication1.Helpers;
using System.Net.Mail;
using System.Text;
using System.Drawing.Printing;
using System.Diagnostics;

namespace Artistic_Showroom_Web.Controllers
{
    public class EventController : Controller
    {
        EventServices ES = null;
        GalleryService GS = new GalleryService();
        UserService US = new UserService();
        BookingService BS = new BookingService();
        public EventController()
        {
            ES = new EventServices();      

        }
    

        //GET : Event
        public ActionResult Index()
        {
            List<EventViewModels> eventList = new List<EventViewModels>();

            foreach (var item in ES.GetAll())
            {
                if (item.endDate < DateTime.Now)
                {
                    ES.changeStateEvent(item);
                }

                EventViewModels EVM = new EventViewModels();

                if (item.statEvent == "UpComing")
                {

                    EVM.eventId = item.eventId;
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

            }

            return View(eventList);


        }


        // GET : Event/Details
        public ActionResult Details(int id)
        {
            EventViewModels EVM = new EventViewModels();
            Event e = ES.GetById(id);
            EVM.eventId = e.eventId;
            EVM.title = e.title;
            EVM.description = e.description;
            EVM.inclusions = e.inclusions;
            EVM.startDate = e.startDate;
            EVM.actualDate = e.actualDate;
            EVM.endDate = e.endDate;
            EVM.statEvent = e.statEvent;
            EVM.nbParticipant = e.nbParticipant;

            return View(EVM);
        }

        // GET : Event/Create
        public ActionResult Create()
        {
            EventViewModels GVM = new EventViewModels();
            GVM.galleries = ES.GetAllGalleries().ToSelectListItems();
           
            
            return View(GVM);
           
        }

        // POST : Event/Create
        [HttpPost]
        public ActionResult Create(EventViewModels EVM, HttpPostedFileBase Image1)
        {
            if (!ModelState.IsValid || Image1 == null || Image1.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            EVM.imageURL = Image1.FileName;




            Event e = new Event();
            e.title = EVM.title;
            e.description = EVM.description;
            e.inclusions = EVM.inclusions;
            e.startDate = EVM.startDate;
            e.actualDate = DateTime.Now ;
            e.endDate = EVM.endDate;
            e.GalleryId = EVM.galleryId;
            e.statEvent = "UpComming";
            e.userId = 1;

            e.imageURL = EVM.imageURL;
            e.nbParticipant = EVM.nbParticipant;

            ES.Add(e);
            ES.Commit();

            // Sauvgarde de l'image

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image1.FileName);
            Image1.SaveAs(path);

            return RedirectToAction("Details", new { id = e.eventId});            

        }

        //GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            EventViewModels PVM = new EventViewModels();
            Event p = ES.GetById(id);
            PVM.eventId = p.eventId;
            PVM.title = p.title;
            PVM.description = p.description;
            PVM.startDate = p.startDate;
            PVM.actualDate = p.actualDate;
            PVM.endDate = p.endDate;
            PVM.inclusions = p.inclusions;
            PVM.nbParticipant = p.nbParticipant;

            if (PVM == null)
            {
                return HttpNotFound();
            }
            return View(PVM);

          
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventViewModels EVM)
        {
            Event e = ES.GetById(id);
            e.title = EVM.title;
            e.description = EVM.description;
            e.inclusions = EVM.inclusions;
            e.startDate = EVM.startDate;
            e.actualDate = EVM.actualDate;
            e.endDate = EVM.endDate;
            e.nbParticipant = EVM.nbParticipant;

            ES.Update(e);
            ES.Commit();
            return RedirectToAction("Details", new { id = e.eventId });
        }

        // GET: Event/Delete/1
        public ActionResult Delete(int id)
        {

            EventViewModels EVM = new EventViewModels();
            Event e = ES.GetById(id);
            EVM.eventId = e.eventId;
            EVM.title = e.title;
            EVM.description = e.description;
            EVM.inclusions = e.inclusions;
            EVM.startDate = e.startDate;
            EVM.actualDate = e.actualDate;
            EVM.endDate = e.endDate;
            EVM.nbParticipant = e.nbParticipant;

            if (EVM == null)
            {
                return HttpNotFound();
            }
            return View(EVM);

        }


        //POST: Event/Delete/1
        [HttpPost]
        public ActionResult Delete(int id, EventViewModels EVM)
        {
            Event e = ES.GetById(id);
            
            e.title = EVM.title;
            e.description = EVM.description;
            e.inclusions = EVM.inclusions;
            e.startDate = EVM.startDate;
            e.actualDate = EVM.actualDate;
            e.endDate = EVM.endDate;
            e.nbParticipant = EVM.nbParticipant;

            ES.Delete(e);
            ES.Commit();
            return RedirectToAction("Index");

        }

      

        // GET: Event/Paricipate/1
        public ActionResult Participate(int id)
        {

            
            //Booking b = .GetById(id);
            //EVM.eventId = e.eventId;
            //EVM.title = e.title;
            //EVM.description = e.description;
            //EVM.inclusions = e.inclusions;
            //EVM.startDate = e.startDate;
            //EVM.actualDate = e.actualDate;
            //EVM.endDate = e.endDate;

            //if (EVM == null)
            //{
            //    return HttpNotFound();
            //}
            Event e = ES.GetById(id);
            int idUS = e.userId;

            User user = US.GetById(idUS);
            string username = user.firstName + "   " + user.lastName;
            string usermail = user.email;
           
            string eventname = e.title;

            ViewBag.usersname = username;
            ViewBag.usersmail = usermail;
            ViewBag.evs = eventname;

            BookingViewModels BVM = new BookingViewModels();
            BVM.qrcodeUrl = user.email;
            return View(BVM);

        }


        //POST: Event/Paricipate/1
        [HttpPost]
        public ActionResult Participate(int id, EventViewModels EVM)
        {
            
            Event e = ES.GetById(id);
            if (e.nbParticipant > 0)
            {
                int idUS = e.userId;
                User usr = US.GetById(idUS);
                Booking b = new Booking();
                b.eventId = id;
                b.userId = 1;
                b.qrcodeUrl = usr.email;
                ES.EventParticipation(b);
                //  BS.Add(b);
                ES.Commit();

                e.nbParticipant--;
                ES.Update(e);
                ES.Commit();


                PrintDocument imp = new PrintDocument();
                imp.DocumentName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\fichier1.pdf";
                string vue = imp.ToString();
                imp.Print();



                //Process proc = new Process();
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //proc.StartInfo.Verb = "print";
                //string pdfFileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicaC:\Users\Asus\Documents\Esprit\4éme Année\PI\Project.net\ArtisticShowroomV2\Services\IBookingService.cstionData) + "\\fichier1.pdf";
                //proc.StartInfo.FileName = @"C:\Program Files (x86)\Adobe\Reader 10.0\Reader\AcroRd32.exe";
                //proc.StartInfo.Arguments = @"/p /h " + pdfFileName;
                //proc.StartInfo.UseShellExecute = false;
                //proc.StartInfo.CreateNoWindow = true;
                //proc.Start();
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //if (proc.HasExited == false)
                //{
                //    proc.WaitForExit(1000);
                //    //proc.Kill();
                //}
                //proc.EnableRaisingEvents = true;
                ////proc.Kill();
                //////  AcroRd32.exe
                ////proc.CloseMainWindow();
                ////proc.Close();

                return RedirectToAction("Index") ;

            }
            else
            {
                ViewBag.msg = "No more places available";

                return View();
            }

        }
       

        //GET : PassedEvent
        public ActionResult GetPassedEvent()
        {
            List<EventViewModels> eventList = new List<EventViewModels>();

            foreach (var item in ES.GetAll())
            {
                if (item.endDate < DateTime.Now)
                {
                    ES.changeStateEvent(item);
                }

                EventViewModels EVM = new EventViewModels();

                if (item.statEvent == "Passed")
                {

                    EVM.eventId = item.eventId;
                    EVM.userId = item.userId;
                    EVM.title = item.title;
                    EVM.description = item.description;
                    EVM.inclusions = item.inclusions;
                    EVM.startDate = item.startDate;
                    EVM.actualDate = DateTime.Now;
                    EVM.endDate = item.endDate;
                    EVM.imageURL = item.imageURL;

                    eventList.Add(EVM);

                }

            }

            return View(eventList);


        }

        // Get : BestEvent
        public ActionResult BestEvent()
        {
            EventViewModels EVM = new EventViewModels();
            int id = BS.RenderBest();
           
            Event e = new Event();
            e = ES.GetById(id);

           
            EVM.title = e.title;
            EVM.description = e.description;
            EVM.inclusions = e.inclusions;
            EVM.startDate = e.startDate;
            EVM.actualDate = e.actualDate;
            EVM.endDate = e.endDate;
            EVM.statEvent = e.statEvent;
            EVM.nbParticipant = e.nbParticipant;

            return View(EVM);


        }

        //POST: Event/ParicipateToEvent/1
        //[HttpPost]
        //public ActionResult ParticipateToEvent(int eventId, int userId, BookingViewModels BVM)
        //{


        //    User u = US.GetById(id);

        //    Booking b = new Booking();
        //    b.eventId = eventId;
        //    b.userId = userId;
        //    b.qrcodeUrl = imgBarCode.ImageUrl;
        //    ES.EventParticipation(b);
        //    ES.Commit();


        //    return View();
        //    imgBarCode

        //}

        ////GET: Event/ParicipateToEvent/1/1
        //public ActionResult ParticipateToEvent(int id, int id1, int id2, BookingViewModels BVM)
        //{
        //    IEnumerable<Booking> listBooking = ES.getEventParticipation(id, id1, id2);
        //      Booking b = new Booking();
        //    b = listBooking.First();
        //    b.eventId = evm;
        //    //   EVM.eventId = e.eventId;

        //    User usr = US.GetById(id);
        //    // User user = ES.getUserInformations(eventId);
        //    string username = usr.firstName + "   " + usr.lastName;
        //    string usermail = usr.email;
        //    Event ev = ES.GetById(id1);
        //    string eventname = ev.title;

        //    ViewBag.usersname = username;
        //    ViewBag.usersmail = usermail;
        //    ViewBag.evs = eventname;


        //    return View();

        //}



        //// POST: Event/InviteWithMail
        //private void InviteWithMail()
        //{
        //    string subject = "Email Subject";
        //    string body = "Email body";
        //    string FromMail = "meriemarfaoui123@gmail.com";
        //    string emailTo = "meriemarfaoui123@gmail.com";
        //    MailMessage mail = new MailMessage();
        //    SmtpClient SmtpServer = new SmtpClient("mail.reckonbits.com.pk");

        //    mail.From = new MailAddress(FromMail);
        //    mail.To.Add(emailTo);
        //    mail.Subject = subject;
        //    mail.Body = body;

        //    SmtpServer.Port = 25;
        //    SmtpServer.Credentials = new System.Net.NetworkCredential("meriemarfaoui123@gmail.com", "alipapa12");
        //    SmtpServer.EnableSsl = false;
        //    SmtpServer.Send(mail);
        //}


    }
}