using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Artistic_Showroom_Web.Models
{
    [DataContract(IsReference = true)]
    public class GalleryViewModels
    {
     
        public int GalleryId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public int NumTel { get; set; }

        public string description { get; set; }

        public double lat { get; set; }

        public double lng { get; set; }

        public string galleryImage { get; set; }


    }
}