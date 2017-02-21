using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public interface ILocationRepository
    {
        IQueryable<Location> Locations { get; }
        Location Save(Location location);
        Location Edit(Location location);
        void DeleteAll();
        void Remove(Location location);
    }
}
