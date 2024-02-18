using System.ComponentModel.DataAnnotations;
using System;
using eTickets.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using eTickets.Data.Base;

namespace eTickets.Models
{
    public class Concert : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ConcertCategory ConcertCategory { get; set; }

        //Relationships

        public List<Performer_Concert> Performers_Concerts { get; set; }

        //Venue
        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public Venue Venue { get; set; }

        //Person
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
