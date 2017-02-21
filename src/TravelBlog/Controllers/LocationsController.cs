using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


namespace TravelBlog.Controllers
{
    public class LocationsController : Controller
    {
        private ILocationRepository locationRepo;
        public LocationsController(ILocationRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.locationRepo = new EFLocationRepository();
            }
            else
            {
                this.locationRepo = thisRepo;
            }
        }
        public ViewResult Index()
        {
            return View(locationRepo.Locations.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            locationRepo.Save(location);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisLocation = locationRepo.Locations
                .Include(locations => locations.Experiences)
                .Include(locations => locations.Comments)
                .ThenInclude(comments => comments.User)
                .FirstOrDefault(locations => locations.LocationId == id);
            var happenings = thisLocation.Experiences.ToList();
       
            ViewBag.MyList =  happenings;
            return View(thisLocation);
        }

        public IActionResult Edit(int id)
        {
            Location thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            locationRepo.Edit(location);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            locationRepo.Remove(thisLocation);
            return RedirectToAction("Index");
        }
    }
}
