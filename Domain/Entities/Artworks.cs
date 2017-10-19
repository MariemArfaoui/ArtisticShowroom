using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Artworks
    {
        [Key]
        public int ArtworkId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAjout { get; set; }
        public float Price { get; set; }
       // public Category Category { get; set; }
        public SubCategory subCategory { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string User { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string Image { get; set; }

        public int? VenteId { get; set; }
        //[ForeignKey("VenteId")]
        public VenteAuxEncheres VenteAuxEncheres { get; set; }


    }
    
}
