using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Room
    {
        public int Id { get; set; }
        [StringLength(50), Required()]
        public string Name { get; set; }
        [StringLength(500), Required()]
        public string Description { get; set; }
        public int OpeningAt { get; set; }
        public int ClosingAt { get; set; }

        List<Reservation> Reservations { get; set; }
    }
}


/*
    Název (povinný, řetězec o délce 1..50 znaků)
    Popis (povinný, řetězec o délce 50..500 znaků)
    Otevírací doba od (povinný, číslo vyjadřující hodinu od kdy je místnost otevřena a je možné vytvářet rezervace, tedy např. číslo 11 znamená, že místnost je otevřena od 11:00)
    Otevírací doba do (analogicky k otevírací době od, tedy např. 22 znamená, že místnost je možné rezervovat do 22:00)
    Vazba na rezervace uskutečněné na danou místnost (vizte dále)
*/
