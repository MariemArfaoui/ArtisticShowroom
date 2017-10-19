using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Gallery
    {
        [Key]

        public int GalleryId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int NumTel { get; set; }
        public string description { get; set; }
        public string Owner { get; set; }
    }
}
