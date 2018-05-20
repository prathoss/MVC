using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Room Room { get; set; }
        public DateTime Date { get; set; }
        [StringLength(50, ErrorMessage = "Wrong number of characters. Minimum: 1, Maximum: 50", MinimumLength = 1), Required(), Display(Name = "Name")]
        public string CustomersName { get; set; }
        [StringLength(50, ErrorMessage = "Wrong number of characters. Minimum: 1, Maximum: 50", MinimumLength = 1), Required(), Display(Name = "Last name")]
        public string CustomersLastName { get; set; }
        [Required(), EmailAddress, Display(Name = "Email address")]
        public string CustomersEmail { get; set; }
        [Required(), RegularExpression(@"^\+([0-9]{3} ){3}[0-9]{3}$", ErrorMessage = "Telephone number must be in format: +XXX XXX XXX XXX"), Display(Name = "Phone number")]
        public string CustomersPhone { get; set; }
        [StringLength(500, ErrorMessage = "Wrong number of characters. Maximum: 500", MinimumLength = 0), Display(Name = "Note")]
        public string CustomersNote { get; set; }
    }
}

/*
    Místnost (která je rezervována)
    Datum a čas rezervace
    Jméno zákazníka (1..50 znaků)
    Příjmení zákazníka (1..50 znaků)
    Email zákazníka
    Telefonní číslo ve formátu +XXX XXX XXX XXX
    Poznámka (nepovinná, 0..500 znaků)
*/