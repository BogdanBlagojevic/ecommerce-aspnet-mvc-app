using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Person:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profilna Slika")]
        [Required(ErrorMessage="Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Ime i Prezime")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Biografija")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Concert> Concerts { get; set; }
    }
}
