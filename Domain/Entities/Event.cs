using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        [Key]
        public int eventId { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public DateTime actualDate { get; set; }

        public string title { get; set; }

        [DataType(DataType.MultilineText)]
        public string description { get; set; }


        public int GalleryId { get; set; }

        [ForeignKey("GalleryId")]
        public virtual Gallery gallery { get; set; }

        public int userId { get; set; }

        [ForeignKey("userId")]
        public virtual User user { get; set; }

        public string inclusions { get; set; }

        public string imageURL { get; set; }

        public string statEvent { get; set; }

        public int nbParticipant { get; set; }
    }
}
