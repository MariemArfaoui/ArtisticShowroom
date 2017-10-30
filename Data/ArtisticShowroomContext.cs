using Data.CustumConventions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ArtisticShowroomContext : DbContext
    {
        public ArtisticShowroomContext() : base("Name=FirstGallery")
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Gallery> galleries { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Booking> BookingList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateTime2Convention());

        }
    }
}
