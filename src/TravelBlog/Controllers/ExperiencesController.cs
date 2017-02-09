using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        public IActionResult Index()
        {
            return View(db.Experiences.Include(experiences => experiences.Location).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName");
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience experience )
        {
         
            db.Experiences.Add(experience);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisExperience = db.Experiences
                .Include(experiences => experiences.Location)
                .FirstOrDefault(experience => experience.ExperienceId == id);
            return View(thisExperience);
        }

        public IActionResult Edit(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experience => experience.ExperienceId == id);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName");
            return View(thisExperience);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            db.Entry(experience).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experience => experience.ExperienceId == id);
            return View(thisExperience);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(experience => experience.ExperienceId == id);
            db.Experiences.Remove(thisExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
