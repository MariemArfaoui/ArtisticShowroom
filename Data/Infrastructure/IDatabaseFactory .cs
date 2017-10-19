
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstGallery.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        FirstGalleryContext DataContext { get; }
    }

}
