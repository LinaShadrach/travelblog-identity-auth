using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PeopleController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        public IActionResult Index()
        {
            return View(db.People.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Experience = new SelectList(db.Experiences, "ExperienceId", "ExperienceName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person, int Experience = 0)
        {
            db.People.Add(person);
            if(Experience == 0)
            {
                Encounter newEncounter = new Encounter(Experience, person.PersonId);
                db.Encounters.Add(newEncounter);

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisPerson = db.People
                .Include(people => people.Encounters)
                .ThenInclude(e => e.Experience)
                .ThenInclude(e => e.Location)
                .FirstOrDefault(people => people.PersonId == id);
            return View(thisPerson);
        }

        public IActionResult Edit(int id)
        {
            var thisPerson = db.People.FirstOrDefault(person => person.PersonId == id) ;
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "ExperienceName");
            return View(thisPerson);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPerson = db.People.FirstOrDefault(person => person.PersonId == id);
            return View(thisPerson);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPerson = db.People.FirstOrDefault(person => person.PersonId == id);
            db.People.Remove(thisPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
