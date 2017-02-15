using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class CommentsController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();

        // GET: /<controller>/
        public IActionResult Create(int id)
        {
            ViewBag.LocationId = id;
            System.Diagnostics.Debug.WriteLine("in(***************************************************************"+ id);
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment, int locationId)
        {
            comment.LocationId = locationId;
            System.Diagnostics.Debug.WriteLine(locationId);
            System.Diagnostics.Debug.WriteLine(comment.LocationId);
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Locations", new { id = comment.LocationId });
        }
    }
}
