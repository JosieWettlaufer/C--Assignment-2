using System.Diagnostics;
using System.Linq;
using C__Assignment_2.Models;
using Microsoft.AspNetCore.Mvc;

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
            //linq query organizes by trip id
            var trips = context.Trips.OrderBy(m => m.TripId).ToList();
            return View(trips);
        }

        
    }
}
