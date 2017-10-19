using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {


        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Range(0, 99)]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Address Address { get; set; }


        // TODO: validate only picture formats
        public string AvatarFileName { get; set; }

        /*   public enum UserKind
           {
               Admin, Client, Artist, GalleryOwner
           }*/
        /*    public virtual ICollection<VenteAuxEncheres> VenteAuxEncheres
            {
                get { return this.VenteAuxEncheres; }
                set { this.VenteAuxEncheres = value; }
            }
            */
    }
}
