using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Models
{
    public class EFLocationRepository : ILocationRepository
    {
        TravelBlogContext db = new TravelBlogContext();
        public EFLocationRepository(TravelBlogContext connection = null)
        {
            if(connection == null)
            {
                this.db = new TravelBlogContext();
            }
            else
            {
                this.db = connection;
            }
        }
        public IQueryable<Location> Locations
        { get { return db.Locations; } }

        public Location Save(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return location;
        }

        public Location Edit(Location location)
        {
            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return location;
        }

        public void Remove(Location location)
        {
            db.Locations.Remove(location);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.RemoveRange(db.Locations);
            db.SaveChanges();
        }
    }
}
