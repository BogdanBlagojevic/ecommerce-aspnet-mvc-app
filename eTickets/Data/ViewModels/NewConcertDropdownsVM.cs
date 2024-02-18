using eTickets.Controllers;
using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.ViewModels
{
    public class NewConcertDropdownsVM
    {
        public NewConcertDropdownsVM()
        {
            Persons = new List<Person>();
            Venues= new List<Venue>();
            Performers = new List<Performer>();
        }

        public List<Person> Persons { get; set; }
        public List<Venue> Venues { get; set; }
        public List<Performer> Performers { get; set; }
    }
}
