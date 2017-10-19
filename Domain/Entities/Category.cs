using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public IEnumerable<Type> ItemsType { get; set; }



        // public ICollection<Artworks> artworks { get; set; } 
        public ICollection<SubCategory> SubCategory { get; set; }

    }
}
