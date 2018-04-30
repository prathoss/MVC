using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required()]
        public Room Room { get; set; }
        public DateTime Date { get; set; }
        [StringLength(50), Required()]
        public string CustomersName { get; set; }
        [StringLength(50), Required()]
        public string CustomersLastName { get; set; }
        [Required()]
        public string CustomersEmail { get; set; }
        [Required()]
        public string CustomersPhone { get; set; }
        [StringLength(500)]
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