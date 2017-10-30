using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;


namespace Services
{
    public class EventServices : Service<Event>, IEventService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public EventServices() : base(utwk)
        {
            
        }

        public virtual void EventParticipation(Booking b)
        {
            
            utwk.getRepository<Booking>().Add(b);

        }

        public IEnumerable<Gallery> GetAllGalleries()
        {
            return utwk.getRepository<Gallery>().GetAll();
        }

        //public int getUserInformations(int idEvent)
        //{
        //    return utwk.getRepository<Event>().GetById(id);
        //    var res = from req in utwk.getRepository<Booking>().GetAll()
        //              where (req.eventId == idEvent)
        //              select req.userId;
        //    return res;
        //}
        public IEnumerable<Booking> getEventParticipation(int id, int id1, int id2)
        {
            return utwk.getRepository<Booking>().GetAll();
        }

        public void changeStateEvent(Event e)
        {
                
                
                    e.statEvent = "Passed";              

                
                utwk.getRepository<Event>().Update(e);
                utwk.Commit();
            }

       
    }
    }

