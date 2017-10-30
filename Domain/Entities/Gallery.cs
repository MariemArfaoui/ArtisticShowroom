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

        public double lat { get; set; }

        public double lng { get; set; }

        public string galleryImage { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int NumTel { get; set; }

        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        
        public int userId { get; set; }
        public virtual User Owner { get; set; }
    }
}
