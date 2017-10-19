using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
   public class AddressConfiguration :ComplexTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            Property(p => p.City).IsRequired();
            Property(p => p.StreetAddress).HasMaxLength(200)
                .IsOptional();
        }
    }

}

