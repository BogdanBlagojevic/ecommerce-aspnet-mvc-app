using eTickets.Data.services;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly IConcertsServices _service;

        public ConcertsController(IConcertsServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allConcerts = await _service.GetAllAsync(n => n.Venue);
            return View(allConcerts);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allConcerts = await _service.GetAllAsync(n => n.Venue);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allConcerts.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allConcerts);
        }


        // GET: Concerts/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var concertDetail = await _service.GetConcertByIdAsync(id);
            return View(concertDetail);
        }

        // GET: Concerts/Create
        public async Task<IActionResult> Create()
        {
            var concertDropdownsData = await _service.GetNewConcertDropdownsValues();

            ViewBag.Venues = new SelectList(concertDropdownsData.Venues, "Id", "Name");
            ViewBag.Persons = new SelectList(concertDropdownsData.Persons, "Id", "FullName");
            ViewBag.Performers = new SelectList(concertDropdownsData.Performers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewConcertVM concert)
        {
            if (!ModelState.IsValid)
            {
                var concertDropdownsData = await _service.GetNewConcertDropdownsValues();

                ViewBag.Venues = new SelectList(concertDropdownsData.Venues, "Id", "Name");
                ViewBag.Persons = new SelectList(concertDropdownsData.Persons, "Id", "FullName");
                ViewBag.Performers = new SelectList(concertDropdownsData.Performers, "Id", "FullName");

                return View(concert);
            }

            await _service.AddNewConcertAsync(concert);
            return RedirectToAction(nameof(Index));
        }


        // GET: Concerts/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var concertDetails = await _service.GetConcertByIdAsync(id);
            if (concertDetails == null) return View("NotFound");

            var response = new NewConcertVM()
            {
                Id = concertDetails.Id,
                Name = concertDetails.Name,
                Description = concertDetails.Description,
                Price = concertDetails.Price,
                StartDate = concertDetails.StartDate,
                EndDate = concertDetails.EndDate,
                ImageURL = concertDetails.ImageURL,
                ConcertCategory = concertDetails.ConcertCategory,
                VenueId = concertDetails.VenueId,
                PersonId = concertDetails.PersonId,
                PerformersIds = concertDetails.Performers_Concerts.Select(n => n.PerformerId).ToList(),
            };

            var concertDropdownsData = await _service.GetNewConcertDropdownsValues();
            ViewBag.Venues = new SelectList(concertDropdownsData.Venues, "Id", "Name");
            ViewBag.Persons = new SelectList(concertDropdownsData.Persons, "Id", "FullName");
            ViewBag.Performers = new SelectList(concertDropdownsData.Performers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewConcertVM concert)
        {
            if (id != concert.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var concertDropdownsData = await _service.GetNewConcertDropdownsValues();

                ViewBag.Venues = new SelectList(concertDropdownsData.Venues, "Id", "Name");
                ViewBag.Persons = new SelectList(concertDropdownsData.Persons, "Id", "FullName");
                ViewBag.Performers = new SelectList(concertDropdownsData.Performers, "Id", "FullName");

                return View(concert);
            }

            await _service.UpdateConcertAsync(concert);
            return RedirectToAction(nameof(Index));
        }
    }
}
