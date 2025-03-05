using System.Diagnostics;
using System.Linq;
using C__Assignment_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

//CONVERT TO PRG PATTERRN????????

namespace C__Assignment_2.Controllers
{
    public class HomeController : Controller
    {
        //get dbcontext
        private TripContext context {  get; set; }

        //constructor
        public HomeController(TripContext context)
        {
            this.context = context;
        }

        //action method
        public IActionResult Index()
        {
            //Clears possible existing tempdata
            TempData.Clear();

            //linq query organizes by trip id
            var trips = context.Trips.OrderBy(m => m.TripId).ToList();
            return View(trips);
        }

        //Next button Add1
        [HttpPost]
        public IActionResult Add(Trip trip)
        {
            //Store user inputs in TempData
            TempData["Destination"] = trip.Destination;
            TempData["Accommodation"] = trip.Accommodation;
            TempData["StartDate"] = trip.StartDate;//.ToString("yyyy-MM-dd");
            TempData["EndDate"] = trip.EndDate;//.ToString("yyyy-MM-dd");

            //Set subheading
            ViewData["Subhead"] = "Add Info for " + trip.Accommodation;
             
            if (ModelState.IsValid && !string.IsNullOrEmpty(trip.Accommodation))
            {
                //retain for next request
                TempData.Keep();

                //proceed to next page
                return View("Add2", trip);
            }
            else if (ModelState.IsValid)
            {


                //retain for next request
                TempData.Keep();

                ViewData["Subhead"] = "Add Things to do in " + trip.Destination;

                return View("Add3", trip);
            }
            else
            {
                //clear subheading
                ViewData["Subhead"] = "";

                //remain on first add page
                return View(trip);
            }
        }

        //Next button Add2
        [HttpPost]
        public IActionResult Add2(Trip trip)
        {
            TempData["AccommodationPhone"] = trip.AccomodationPhone;
            TempData["AccommodationEmail"] = trip.AccommodationEmail;


            if (ModelState.IsValid)
            {
                //retain for next request
                TempData.Keep();

                ViewData["Subhead"] = "Add Things to do in " + trip.Destination;

                return View("Add3", trip);
               
            }
            else
            {
                return View();
            }
        }

        //Save button Add3
        [HttpPost]
        public IActionResult SaveTrip(Trip trip)
        {
            TempData["ThingToDo1"] = trip.ThingToDo1;
            TempData["ThingToDo2"] = trip.ThingToDo2;
            TempData["ThingToDo3"] = trip.ThingToDo3;

            //Set subheading
            ViewData["Subhead"] = "Trip to " + trip.Destination + " added.";

            if (ModelState.IsValid)
            {
                context.Trips.Add(trip);
                //save to db
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Add3", trip);
            }
            
        }

        //Add trip
        [HttpGet]
        public IActionResult Add()
        {
            

            ViewData["Subhead"] = "Add Trip Destination and Dates";

            return View("Add", new Trip());
        }
    }
}
