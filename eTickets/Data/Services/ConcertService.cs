using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.services
{
    public class ConcertService : EntityBaseRepository<Concert>, IConcertsServices
    {
        private readonly AppDbContext _context;
        public ConcertService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewConcertAsync(NewConcertVM data)
        {
            var newConcert = new Concert()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                VenueId = data.VenueId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ConcertCategory = data.ConcertCategory,
                PersonId = data.PersonId,
            };
            await _context.Concerts.AddAsync(newConcert);
            await _context.SaveChangesAsync();

            //Add Concert Performers
            foreach (var performerId in data.PerformersIds)
            {
                var newPerformerConcert = new Performer_Concert()
                {
                    ConcertId = newConcert.Id,
                    PerformerId = performerId
                };
                await _context.Performers_Concerts.AddAsync(newPerformerConcert);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<Concert> GetConcertByIdAsync(int id)
        {
            var ConcertDetails = await _context.Concerts
                .Include(c => c.Venue)
                .Include(p => p.Person)
                .Include(am => am.Performers_Concerts).ThenInclude(a => a.Performer)
                .FirstOrDefaultAsync(n => n.Id == id);

            return ConcertDetails;
        }

        public async Task<NewConcertDropdownsVM> GetNewConcertDropdownsValues()
        {
            var response = new NewConcertDropdownsVM()
            {
                Performers = await _context.Performers.OrderBy(n => n.FullName).ToListAsync(),
                Venues = await _context.Venues.OrderBy(n => n.Name).ToListAsync(),
                Persons = await _context.Persons.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateConcertAsync(NewConcertVM data)
        {
            var dbConcert = await _context.Concerts.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbConcert != null)
            {

                dbConcert.Name = data.Name;
                dbConcert.Description = data.Description;
                dbConcert.Price = data.Price;
                dbConcert.ImageURL = data.ImageURL;
                dbConcert.VenueId = data.VenueId;
                dbConcert.StartDate = data.StartDate;
                dbConcert.EndDate = data.EndDate;
                dbConcert.ConcertCategory = data.ConcertCategory;
                dbConcert.PersonId = data.PersonId;

                await _context.SaveChangesAsync();
            }

            //Remove existing performer
            var existingPerformersDb = _context.Performers_Concerts.Where(n => n.ConcertId == data.Id).ToList();
            _context.Performers_Concerts.RemoveRange(existingPerformersDb);
            await _context.SaveChangesAsync();

            //Update Concert Performers
            foreach (var performerId in data.PerformersIds)
            {
                var newPerformerConcert = new Performer_Concert()
                {
                    ConcertId = data.Id,
                    PerformerId = performerId
                };
                await _context.Performers_Concerts.AddAsync(newPerformerConcert);

            }
            await _context.SaveChangesAsync();
        }
    }
}
