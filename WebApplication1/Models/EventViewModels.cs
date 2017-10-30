using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Artistic_Showroom_Web.Models
{
    public class EventViewModels
    {
       
        public int eventId { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public DateTime actualDate { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string inclusions { get; set; }

        public string imageURL { get; set; }

        public string statEvent { get; set; }

        public int galleryId { get; set; }

        public IEnumerable<SelectListItem> galleries { get; set; }

        public int userId { get; set; }


        public int nbParticipant { get; set; }

        public EventViewModels()
        {

        }

    }
}