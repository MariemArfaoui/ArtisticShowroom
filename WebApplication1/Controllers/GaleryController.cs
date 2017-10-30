using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    public class GaleryController : ApiController
    {
        GalleryService GS = new GalleryService();

        //GET: api/Galery
        public IEnumerable<Gallery> GetGalleries()
        {
            return GS.GetAll();
        }

        // GET: api/Gallery/5
        [ResponseType(typeof(Gallery))]
        public IHttpActionResult GetGallery(int id)
        {
            Gallery gal = GS.GetById(id);
            if (gal == null)
            {
                return NotFound();
            }

            return Ok(gal);
        }

        // POST: api/Gallery
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Gallery/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gallery/5
        public void Delete(int id)
        {
        }
    }
}
