using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Models
{
    public class TestDbContext : TravelBlogContext
    {
        public override DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)/mssqllocaldb;Database=TravelBlogTest;integrated security = True");
        }
        public TestDbContext()
        {
        }
    }
}
