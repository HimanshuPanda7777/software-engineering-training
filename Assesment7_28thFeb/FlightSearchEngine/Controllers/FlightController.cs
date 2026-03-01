using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlightSearchEngine.Models;
using FlightSearchEngine.Data;

namespace FlightSearchEngine.Controllers
{
    public class FlightController : Controller
    {
        private readonly DatabaseHelper _dbHelper;

        public FlightController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // GET: /Flight/
        public async Task<IActionResult> Index()
        {
            var model = new SearchViewModel();
            await PopulateDropdowns(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlights(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(model);
                return View("Index", model);
            }

            var results = await _dbHelper.SearchFlightsAsync(model.Source, model.Destination, model.NumberOfPersons);
            
            ViewBag.SearchType = "FlightOnly";
            return View("Results", results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(model);
                return View("Index", model);
            }

            var results = await _dbHelper.SearchFlightsWithHotelsAsync(model.Source, model.Destination, model.NumberOfPersons);
            
            ViewBag.SearchType = "FlightHotel";
            return View("Results", results);
        }

        private async Task PopulateDropdowns(SearchViewModel model)
        {
            var sources = await _dbHelper.GetSourcesAsync();
            var destinations = await _dbHelper.GetDestinationsAsync();

            model.SourceList = new SelectList(sources);
            model.DestinationList = new SelectList(destinations);
        }
    }
}
