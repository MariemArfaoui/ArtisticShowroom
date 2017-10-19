using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class Association
    {

        public int AssociationId { get; set; }

        public string Name { get; set; }
        public Address Address { get; set; }
        [DataType(DataType.MultilineText)]

        public string Description { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string Image { get; set; }

        public int? VenteId { get; set; }
        [ForeignKey("VenteId")]

        public VenteAuxEncheres VenteAuxEncheres { get; set; }
    }
}
