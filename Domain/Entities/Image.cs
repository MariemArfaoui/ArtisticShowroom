using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Image
    {

        public int Id { get; set; }

        public string FileName { get; set; }

        public string Extension { get; set; }

        public string ContentType { get; set; }

        public int ContentLength { get; set; }

        public byte[] ImageArray { get; set; }

        public int? ItemId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}

