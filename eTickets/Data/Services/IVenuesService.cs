using eTickets.Data.Base;
using eTickets.Models;
using System;

namespace eTickets.Data.services
{
    public interface IVenuesService : IEntityBaseRepository<Venue> 
    {
    }
}