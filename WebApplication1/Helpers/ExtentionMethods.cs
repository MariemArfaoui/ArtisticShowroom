using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<Gallery> Galleries)
        {
            return
                Galleries.OrderBy(gal => gal.Name)
                      .Select(gal =>
                          new SelectListItem
                          {
                              
                              Text = gal.Name + " " ,
                              Value = gal.GalleryId.ToString()
                          });
        }
    }
}