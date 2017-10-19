using Data.Configurations;
using Domain.Entities;
using firstGallery.Data.CustumConventions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
     public class FirstGalleryContext : DbContext
    {

        public FirstGalleryContext() : base("Name=FirstGallery")
        {
         //    Database.SetInitializer<FirstGalleryContext>(new FirstGalleryContextInitializer());
        }

        public DbSet<Artworks> Artworks { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<VenteAuxEncheres> VenteAuxEncheres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //If you want to remove all Convetions and work only with configuration :
            //  modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Conventions.Add(new DateTime2Convention());
            modelBuilder.Configurations.Add(new VenteConfiguration());       }
    }
}
