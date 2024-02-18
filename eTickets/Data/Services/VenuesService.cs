using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.services
{
    public class VenuesService:EntityBaseRepository<Venue>,IVenuesService
    {
        public VenuesService(AppDbContext context): base(context)
        {
            
        }
    }
}
