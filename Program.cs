using System;
using System.Collections.Generic;
using System.Linq;

namespace VjezbaLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            List<Igrac> players = new List<Igrac>
            {
                new Igrac("Ivan", 1, 17, "CS:GO", 5),
                new Igrac("Marko", 2, 18, "LoL", 3),
                new Igrac("Ivana", 3, 19, "Dota2", 6),
                new Igrac("Petar", 4, 20, "CS:GO", 4),
                new Igrac("Mate", 5, 21, "LoL", 3),
                new Igrac("Maja", 6, 22, "Dota2", 7),
                new Igrac("Ivona", 7, 23, "CS:GO", 5),
                new Igrac("Ivica", 8, 24, "LoL", 5),
                new Igrac("Ivka", 9, 14, "Dota2", 4),
                new Igrac("Ivko", 10, 16, "CS:GO", 6)
            };


            var Adult = players.Where(player => player.Age >= 18);
            var morethan4 = players.Where(player => player.HoursPlayed > 4);

            Console.WriteLine("Punoljetni Igraci:");
            foreach (var player in Adult)
            {
                Console.WriteLine(player);
            }
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Igraci koji igraju vise od 4h dnevno:");
            foreach (var player in morethan4)
            {
                Console.WriteLine(player);
            }
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------------------------------");


            var sortGame = players.GroupBy(player => player.Igra)
                                   .Select(group => new
                                   {
                                       Game = group.Key,
                                       Players = group.OrderBy(player => player.HoursPlayed)
                                   });
                    

            foreach (var group in sortGame)
            {
                Console.WriteLine($"Game: {group.Game}, Sort Uzlazno");
                foreach (var player in group.Players)
                {
                    Console.WriteLine($"Player: {player.Name}, Hours Played: {player.HoursPlayed}");
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            }

            Console.WriteLine(
               "-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------------------------------");

            var sortGameUzlazno = players.GroupBy(player => player.Igra)
                                   .Select(group => new
                                   {
                                       Game = group.Key,
                                       Players = group.OrderByDescending(player => player.HoursPlayed).ThenBy(player => player.Name)
                                   });


            foreach (var group in sortGameUzlazno)
            {
                Console.WriteLine($"Game: {group.Game}, Sort Silazno");
                foreach (var player in group.Players)
                {
                    Console.WriteLine($"Player: {player.Name}, Hours Played: {player.HoursPlayed}");
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine(
               "-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------------------------------");

            List<Igra> igre = new List<Igra>
            {
                new Igra("CS:GO", 1, "FPS"),
                new Igra("LoL", 2, "MOBA"),
                new Igra("Dota2", 3, "MOBA"),
                new Igra("Fifa", 4, "Sport"),
                new Igra("NBA", 5, "Sport"),
                new Igra("PES", 6, "Sport"),
                new Igra("WOW", 7, "MMORPG"),
                new Igra("EVE", 8, "MMORPG"),
                new Igra("Rust", 9, "Survival"),
                new Igra("Ark", 10, "Survival")
            };

            
            var grupirano = igre.ToLookup(igra => igra.Vrsta);
            foreach (var group in grupirano)
                {
                Console.WriteLine($"Vrsta: {group.Key}");
                foreach (var igra in group)
                {
                    Console.WriteLine($"Igra: {igra.Ime}");
                }
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                "-----------------------------------------------------------------------------------------------------------------");




            var query = players.Join(igre, player => player.Igra, igra => igra.Ime, (player, igra) => new
            {
                player.Name,
                player.Age,
                player.HoursPlayed,
                igra.Ime,
                igra.Vrsta
            });
         
            var query2 = from player in players
                         join igra in igre on player.Igra equals igra.Ime
                         select new
                         {
                             player.Name,
                             player.Age,
                             player.HoursPlayed,
                             igra.Ime,
                             igra.Vrsta
                         };
           



            Console.ReadKey();

        }
    }
}
