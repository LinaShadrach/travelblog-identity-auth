using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class CommentsController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();

        // GET: /<controller>/
        public IActionResult Create(int loc)
        {
            Debug.WriteLine(loc + "Get******************************");
            ViewBag.LocationId = loc;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment, string UserEmail, int locationId)
        {
            ApplicationUser author = db.Users.FirstOrDefault(u => u.Email == UserEmail);
            comment.User = author;
            Debug.WriteLine(comment.User.Email + "Post******************************");
            Location thisLocation = db.Locations.FirstOrDefault(l => l.LocationId == locationId);

            comment.Location = thisLocation;
            db.Comments.Add(comment);
            db.SaveChanges();
            return Json(comment);
        }
    }
}
