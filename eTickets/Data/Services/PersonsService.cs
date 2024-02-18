using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.services
{
    public class PersonsService : EntityBaseRepository<Person>, IPersonsService
    {
        public PersonsService(AppDbContext context) : base(context)
        {

        }
    }
}
