using System.Diagnostics;
using System.Linq;
using C__Assignment_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace C__Assignment_2.Controllers
{
    public class HomeController : Controller
    {
        //get trip dbcontext
        private TripContext context {  get; set; }

        //controller constructor to receive dbcontext
        public HomeController(TripContext context)
        {
            this.context = context;
        }

        //Index Action Method (Home Page)
        public IActionResult Index()
        {
            //linq query organizes by trips by id
            var trips = context.Trips.OrderBy(m => m.TripId).ToList();

            //Displays trip destination subheading if just added new trip
            if (TempData["Destination"] != null)
            {
                //Set subheading
                ViewData["Subhead"] = "Trip to " + TempData["Destination"] + " added.";
            }

            //Clears pre-existing tempdata
            TempData.Clear();

            //Returns Index View with trip list
            return View(trips);
        }

        //Adds new trip (Form 1)
        [HttpGet]
        public IActionResult AddNewTrip()
        {
            //Populates Sub header for Add Page
            ViewData["Subhead"] = "Add Trip Destination and Dates";

            //Returns view
            return View("Form1", new Trip());
        }

        //Next button Add1
        [HttpPost]
        public IActionResult Form1Post(Trip trip)
        {
            if (ModelState.IsValid) {

                //Store user inputs in TempData
                TempData["Destination"] = trip.Destination;
                TempData["Accommodation"] = trip.Accommodation;
                TempData["StartDate"] = trip.StartDate;
                TempData["EndDate"] = trip.EndDate;
                //retain for next request
                TempData.Keep();

                if (!string.IsNullOrEmpty(trip.Accommodation))
                {
                    //Set subheading
                    ViewData["Subhead"] = "Add Info for " + trip.Accommodation;

                    //Calls Add2 action method
                    return RedirectToAction("ShowForm2");
                }

                //Sets appropriate subhead
                ViewData["Subhead"] = "Add Things to do in " + trip.Destination;

                //Calls Add3 action method
                return RedirectToAction("ShowForm3");
            }
            else
            {
                //remain on Form1 page
                return View("Form1", trip);
            }
        }

        // Show Add2 Form (GET) - Load Accommodation details
        [HttpGet]
        public IActionResult ShowForm2()
        {
            //pass tempdata to view through trip object
            var trip = new Trip
            {
                Destination = TempData["Destination"]?.ToString(),
                Accommodation = TempData["Accommodation"]?.ToString(),
                StartDate = DateTime.Parse(TempData["StartDate"]?.ToString()),
                EndDate = DateTime.Parse(TempData["EndDate"]?.ToString())
            };

            ViewData["Subhead"] = "Add Info for " + TempData["Accommodation"];

            // Keep TempData for the next action
            TempData.Keep();

            return View("Form2", trip);
        }

        //Next button Add2
        [HttpPost]
        public IActionResult Form2Post (Trip trip)
        {
            if (ModelState.IsValid)
            {
                TempData["AccommodationPhone"] = trip.AccomodationPhone;
                TempData["AccommodationEmail"] = trip.AccommodationEmail;
                //retain for next request
                TempData.Keep();

                ViewData["Subhead"] = "Add Things to do in " + trip.Destination;

                return RedirectToAction("ShowForm3");
            }

            return View("Form2", trip);
        }

        // Show Add3 Form (GET) - Load To-Do details
        [HttpGet]
        public IActionResult ShowForm3()
        {
            //pass tempdata to view through trip object
            var trip = new Trip
            {
                Destination = TempData["Destination"]?.ToString(),
                Accommodation = TempData["Accommodation"]?.ToString(),
                StartDate = DateTime.Parse(TempData["StartDate"]?.ToString()),
                EndDate = DateTime.Parse(TempData["EndDate"]?.ToString()),
                AccomodationPhone = TempData["AccommodationPhone"]?.ToString(),
                AccommodationEmail = TempData["AccommodationEmail"]?.ToString()
            };

            ViewData["Subhead"] = "Add Things to do in " + TempData["Destination"];

            // Keep TempData for the next action
            TempData.Keep();

            return View("Form3", trip);
        }

        //Save button Add3
        [HttpPost]
        public IActionResult Form3Post(Trip trip)
        {
            if (ModelState.IsValid)
            {
                context.Trips.Add(trip);
                //save to db
                context.SaveChanges();


                return RedirectToAction("Index");
            }

            return View("Form3", trip);
        }
    }
}
