using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Venue:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo mesta")]
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }
        [Display(Name = "Naziv Mesta")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = " Name must be between 3 and 50 chars")]
        public string Name { get; set; }
        [Display(Name = "Adresa mesta")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        //Relationships
        public List<Concert> Concerts { get; set; }
    }
}
