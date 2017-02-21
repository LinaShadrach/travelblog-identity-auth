using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBlog.Controllers;
using TravelBlog.Models;
using Xunit;

namespace TravelBlog.Tests.Controllers
{
    public class LocationsControllerTest : IDisposable
    {
        EFLocationRepository db = new EFLocationRepository(new TestDbContext());
        Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
        public void DBSetUp()
        {
            mock.Setup(m => m.Locations).Returns(new Location[] 
            {
                new Location {LocationId = 1, LocationName = "Peru",  LocationDescription = "pretty" },
                new Location {LocationId = 2, LocationName = "Belize",  LocationDescription = "big blue hole" },
                new Location {LocationId = 3, LocationName = "Brazil", LocationDescription = "Huge!" }
            }.AsQueryable());
        }
        [Fact]
        public void Post_MethodAddsItem_Test()
        {
            DBSetUp();
            LocationsController controller = new LocationsController(mock.Object);
            Location testLocation = new Location();
            testLocation.LocationName = "Lima, Peru";
            controller.Create(testLocation);
            ViewResult indexView = new LocationsController(mock.Object).Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Location>;
            Assert.Contains<Location>(testLocation, collection);
        }
        [Fact]
        public void Post_MethodEditsItem_Test()
        {
            DBSetUp();
            LocationsController controller = new LocationsController(mock.Object);
            Location testLocation = new Location();
            testLocation.LocationName = "Lima, Peru";
            controller.Create(testLocation);
            testLocation.LocationName = "Bejing, China";
            controller.Edit(testLocation);
            Location expectedLocation = new Location();
            expectedLocation.LocationName = "Bejing, China";
            ViewResult indexView = new LocationsController(mock.Object).Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Location>;
            Assert.Equal(expectedLocation.LocationName, (collection.FirstOrDefault(c => c.LocationId == testLocation.LocationId)).LocationName);
        }

        [Fact]
        public void Post_MethodDeletesItem_Test()
        {
            DBSetUp();
            LocationsController controller = new LocationsController(mock.Object);
            ViewResult indexView = new LocationsController(mock.Object).Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Location>;
            Location location = collection.FirstOrDefault(c => c.LocationId == 1);
            controller.Delete(1);
            var expectedCollection = indexView.ViewData.Model as IEnumerable<Location>;
            Assert.DoesNotContain<Location>(location, expectedCollection);
        }
        public void Dispose()
        {
            db.DeleteAll();
        }
    }
}
