using eTickets.Data;
using eTickets.Data.services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonsService _service;

        public PersonsController(IPersonsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allPersons = await _service.GetAllAsync();
            return View(allPersons);
        }
      //GET: Persons/details/1
      public async Task<IActionResult>Details(int id)
        {
            var personDetails=await _service.GetByIdAsync(id);
            if (personDetails == null) return View("NotFound");
                return View(personDetails);
               
        }

     //GET: Persons/create

        public IActionResult Create()
        {
         return View(); 
        
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Person person)
        {
            if(!ModelState.IsValid) return View(person);
            await _service.AddAsync(person);
            return RedirectToAction(nameof(Index));

        }
        //Get: Prersons/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null) return View("NotFound");
            return View(personDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            if(id== person.Id)
            {
                await _service.UpdateAsync(id, person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        //Get: Persons/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null) return View("NotFound");
            return View(personDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
