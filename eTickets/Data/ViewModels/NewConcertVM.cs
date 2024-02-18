using System.ComponentModel.DataAnnotations;
using System;
using eTickets.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using eTickets.Data.Base;
using System.Xml.Linq;

namespace eTickets.Models
{
    public class NewConcertVM
    {
        public int Id { get; set; }

        [Display(Name = "Naziv koncerta")]
        [Required(ErrorMessage = "Molimo unesite naziv koncerta")]
        public string Name { get; set; }

        [Display(Name = "Opis koncerta")]
        [Required(ErrorMessage = "Molimo unesite opis koncerta")]
        public string Description { get; set; }

        [Display(Name = "Cena karte za koncert $")]
        [Required(ErrorMessage = "Molimo unesite cenu karte")]
        public double Price { get; set; }

        [Display(Name = "Poster koncerta URL")]
        [Required(ErrorMessage = "Molimo unesite URL postera")]
        public string ImageURL { get; set; }

        [Display(Name = "Karte su u prodaji od")]
        [Required(ErrorMessage = "Molimo unesite datum")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Karte su u prodaji do")]
        [Required(ErrorMessage = "Molimo unesite datum")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Kategorija koncerta")]
        [Required(ErrorMessage = "Molimo unesite kategoriju")]
        public ConcertCategory ConcertCategory { get; set; }

        [Display(Name = "Odaberi izvodjače")]
        [Required(ErrorMessage = "Molimo odaberite izvođače")]
        public List<int> PerformersIds { get; set; }

        [Display(Name = "Odaberi mesto održavanja")]
        [Required(ErrorMessage = "Molimo odaberite mesto održavanja")]
        public int VenueId { get; set; }

        [Display(Name = "Odaberi Osobu")]
        [Required(ErrorMessage = "Molimo odaberite osobu")]
        public int PersonId { get; set; }
    }
}
