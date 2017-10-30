using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking
    {
       
        [Key]
        [Column(Order = 1)]
        public int userId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int eventId { get; set; }
        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticketId { get; set; }

        public string qrcodeUrl { get; set; }

        public virtual User participiant { get; set; }
        public virtual Event events { get; set; }
    }
}
