using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class SubCategory
    {
        [Key]

        public int SubCategoryId { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        private ICollection<Image> images;
        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
        public string Title { get; set; }

       

       
        [Required]
        public string Description { get; set; }

        public int? UserId { get; set; }
        [Required]
        public string User { get; set; }
        public virtual VenteAuxEncheres VenteAuxEncheres { get; set; }

    
    public SubCategory()
        {
            this.images = new HashSet<Image>();
        }


    }
}
