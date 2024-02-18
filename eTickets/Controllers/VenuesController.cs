using eTickets.Data;
using eTickets.Data.services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class VenuesController : Controller
    {
        private readonly IVenuesService _service;

        public VenuesController(IVenuesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allVenues = await _service.GetAllAsync();
            return View(allVenues);
        }

        //Get: Venues/Create
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Venue venue)
        {
            if (!ModelState.IsValid) return View(venue);
            await _service.AddAsync(venue);
            return RedirectToAction(nameof(Index));

        }

        //GET: Venues/details/1
        public async Task<IActionResult> Details(int id)
        {
            var venueDetails = await _service.GetByIdAsync(id);
            if (venueDetails == null) return View("NotFound");
            return View(venueDetails);

        }
        //Get: Venues/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var venueDetails = await _service.GetByIdAsync(id);
            if (venueDetails == null) return View("NotFound");
            return View(venueDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return View(venue);
            }
            if (id == venue.Id)
            {
                await _service.UpdateAsync(id, venue);
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }
        //Get: Venues/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var venueDetails = await _service.GetByIdAsync(id);
            if (venueDetails == null) return View("NotFound");
            return View(venueDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venueDetails = await _service.GetByIdAsync(id);
            if (venueDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
