using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerManager.Models
{
    public class Customer
    {
        [Display(Name = "Kundennummer")]
        public int Id { get; set; }

        [Display(Name= "Vorname")]
        [Required(ErrorMessage = "Bitte geben Sie Ihren Vornamen an.")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Display(Name = "Nachname")]
        [Required(ErrorMessage = "Bitte geben Sie Ihren Nachnamen an.")]
        [StringLength(200)]
        public string LastName { get; set; }

        [Display(Name = "Mail")]
        public string Mail { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}