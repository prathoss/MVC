using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50), Required(ErrorMessage = "The column Name has too many characters.")]
        public string Name { get; set; }
        [StringLength(500), Required(ErrorMessage = "The column Description has too many characters.")]
        public string Description { get; set; }
        [Required()]
        public int OpeningAt { get; set; }
        [Required()]
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
