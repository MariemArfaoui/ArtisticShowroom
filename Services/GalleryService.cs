using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Services;

namespace Services
{
    public class GalleryService : Service<Gallery>, IGalleryService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public GalleryService() : base(utwk)
        {
        }
    }
}
