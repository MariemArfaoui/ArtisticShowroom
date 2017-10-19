
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstGallery.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private FirstGalleryContext dataContext;
        public FirstGalleryContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new FirstGalleryContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
