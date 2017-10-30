using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingService : Service<Booking>, IBookingService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public BookingService() : base(utwk)
        {

        }

        public int RenderBest()
        {
            IEnumerable<Booking> liste = utwk.getRepository<Booking>().GetMany();

            var besttr = from a in liste
                         group a by a.eventId into g
                         select new { id = g.Key, Count = g.Count() };
          //  orderby g.Count()
            int idb = 0;
            //int idbest = 0;
            //int idev = 0;
          //  idbest = besttr.First().id;

            foreach (var item in besttr)
            {
                // idb = item.ticketId;
                //if (idb == idbest)
                //{
                //    idev = item.eventId;
                //}
                idb = item.id;

            }
           
            return idb;

        }

        public List<int> getUsersParticipate(int id)
        {
            IEnumerable<Booking> liste = utwk.getRepository<Booking>().GetAll();
            List<int> idUsers = new List<int>();

            foreach (var item in liste)
            {
                if (item.eventId == id)
                {
                    idUsers.Add(item.userId);
                }
            }

            return idUsers;

        }
    }
}
