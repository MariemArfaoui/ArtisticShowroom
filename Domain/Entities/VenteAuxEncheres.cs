using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VenteAuxEncheres
    {
        [Key]
        public int VenteId { get; set; }
        
        [Required(ErrorMessage = "A Title is required")]
        [StringLength(60, MinimumLength = 4)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateClose { get; set; }
        public string Estimation { get; set; }
        public DateTime Duration { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOpen { get; set; }
       
        [Required]
        [Range(1, int.MaxValue)]
        public decimal? MinPrice { get; set; }
        //    public int Increment {get; set;}

        public ICollection<Artworks> Artworks { get; set; }
        public ICollection<Association> Associations { get; set; }
        public IEnumerable<Type> Types { get; set; }
        //username
        //[ScaffoldColumn(false)] 
        public VenteAuxEncheres()
        {

        }
    }
}