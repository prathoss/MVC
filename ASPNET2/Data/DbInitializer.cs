using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DBModel context)
        {
            context.Database.EnsureCreated();
            // Database is seeded
            if (context.Rooms.Any() || context.Reservations.Any())
            {
                return;
            }
            Room[] rooms = new Room[]
            {
                new Room{Name = "Deadmines", Description = "Deep beneath the mines of Moonbrook in southwestern Westfall lie the Deadmines. Despite the demise of the Defias Brotherhood's leader Edwin VanCleef at the hands of Alliance militiamen, the Deadmines is still the Brotherhood's most secure hideout since Cataclysm. Here the survivors of Edwin's crew toil alongside new recruits, so that the Defias juggernaut ship can be complete and the kingdom of Stormwind can be brought to its knees.", OpeningAt = 9, ClosingAt = 22},
                new Room{Name = "Scarlet Halls", Description = "The Scarlet Halls is located in Tirisfal Glades. Revamped in Mists of Pandaria to replace the Armory and Library wings of the Scarlet Monastery, the dungeon now includes a level 90 Heroic mode with three boss encounters. The monastery is one of the strongholds of the Scarlet Crusade, a group of maddened zealots so dedicated to the defeat of all undead that they frequently attack everyone - even the living.", OpeningAt = 14, ClosingAt = 23},
                new Room{Name = "Uldaman", Description = "Uldaman is an ancient Titan vault buried deep within the Khaz Mountains, accessible from the Badlands. Partially excavated, it has since fallen into the hands of the Dark Iron dwarves who seek to corrupt its riches for their master, Ragnaros. It is a great introduction to the Titans and its lore is expanded upon by Uldum and Ulduar, areas which further explain the Titan mythos and the origination of life on Azeroth.", OpeningAt = 8, ClosingAt = 18},
                new Room{Name = "Zul'farrak", Description = "Zul'Farrak is a troll city located in northwestern Tanaris. Due to its massive size, players can use mounts in the zone. While the bosses can be defeated in any order, the instance comes to a climax when players are able to rescue a band of mercenaries trapped in cages by the Sandfury trolls. This is particularly notable as it was one of World of Warcraft's first scripted events.", OpeningAt = 9, ClosingAt = 22}
            };
            foreach(Room room in rooms)
            {
                context.Rooms.Add(room);
            }
            context.SaveChanges();

            Reservation[] reservations = new Reservation[]
            {
                new Reservation{Room = rooms[0], Date = new DateTime(1974, 5, 12, 13, 0, 0), CustomersName = "Toby", CustomersLastName = "Kabbell", CustomersEmail = "tkabbell@mail.com", CustomersPhone = "+420777111888", CustomersNote = "Would not be easy but clan of Frostwolves never gives up..."},
                new Reservation{Room = rooms[0], Date = new DateTime(1989, 2, 9, 15, 0, 0), CustomersName = "Daniel", CustomersLastName = "Wu", CustomersEmail = "dwu@mail.com", CustomersPhone = "+420767333444", CustomersNote = "I will use the power of others."},
                new Reservation{Room = rooms[2], Date = new DateTime(1980, 11, 9, 9, 0, 0), CustomersName = "Travis", CustomersLastName = "Fimmel", CustomersEmail = "tfimmel@mail.com", CustomersPhone = "+420681245917", CustomersNote = "This titan does not stand a chance."},
                new Reservation{Room = rooms[2], Date = new DateTime(1993, 3, 12, 10, 0, 0), CustomersName = "Clancy", CustomersLastName = "Brown", CustomersEmail = "cbrown@mail.com", CustomersPhone = "+420721432771", CustomersNote = "I will not yeld."},
                new Reservation{Room = rooms[2], Date = new DateTime(1987, 9, 30, 12, 0, 0), CustomersName = "Ben", CustomersLastName = "Shnetzer", CustomersEmail = "bschnetzer@mail.com", CustomersPhone = "+420724838551", CustomersNote = "Even tho I failed once, my next quest will not be such a disapointment."},
                new Reservation{Room = rooms[3], Date = new DateTime(1971, 5, 19, 14, 0, 0), CustomersName = "Paula", CustomersLastName = "Patton", CustomersEmail = "ppatton@mail.com", CustomersPhone = "+420673193502", CustomersNote = "Will use every ace in my sleeve."}
            };
            foreach(Reservation reservation in reservations)
            {
                context.Reservations.Add(reservation);
            }
            context.SaveChanges();
        }
    }
}
