using System.ComponentModel.DataAnnotations;

namespace CustomerManager.Models
{
    public class Customer
    {
        [Display(Name = "Kundennummer")]
        public int Id { get; set; }

        [Display(Name = "Vorname")]
        [Required(ErrorMessage = "Vorname muss angegeben werden")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Display(Name = "Nachname")]
        [Required(ErrorMessage = "Nachname muss angegeben werden")]
        [StringLength(200)]
        public string LastName { get; set; }

        [Display(Name = "E-Mail Adresse")]
        public string Mail { get; set; } 
    }
}