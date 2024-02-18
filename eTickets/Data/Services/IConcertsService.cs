using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.services
{
    public interface IConcertsServices : IEntityBaseRepository<Concert>
    {
        Task<Concert> GetConcertByIdAsync(int id);
        Task<NewConcertDropdownsVM> GetNewConcertDropdownsValues();
        Task AddNewConcertAsync(NewConcertVM data);
        Task UpdateConcertAsync(NewConcertVM data);
    }
}
