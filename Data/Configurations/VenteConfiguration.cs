using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
  public  class VenteConfiguration:EntityTypeConfiguration <VenteAuxEncheres>
    {
        public VenteConfiguration()
        {
            HasMany(e => e.Artworks)
                .WithRequired(e=>e.VenteAuxEncheres)
                .HasForeignKey(e=>e.VenteId)
                .WillCascadeOnDelete(false); 
            HasMany(e => e.Associations).WithRequired(e => e.VenteAuxEncheres).HasForeignKey(e => e.VenteId).WillCascadeOnDelete(false); ;


        }
    }
}
