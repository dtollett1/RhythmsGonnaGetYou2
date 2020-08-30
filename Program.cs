using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou2
{
    class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
    }
    class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public string ReleaseDate { get; set; }

    }

    class RhythmsGonnaGetYou2Context : DbContext
    {

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RhythmsGonnaGetYou2");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYou2Context();
            var theBands = context.Bands;
            var theAlbums = context.Albums;

            // Console.WriteLine($"There is a band");

            // var bandCount = theBands.Count();
            // Console.WriteLine($"There are {bandCount} bands!");

            var hasQuitTheApplication = false;
            while (hasQuitTheApplication is false)
            {
                Console.WriteLine("What would you Like to do?");
                Console.WriteLine("ADD Band - Add a New Band");
                Console.WriteLine("VIEW - View all the Bands");
                Console.WriteLine("ADD ALBUM -  Add a new album");
                Console.WriteLine("LET A BAND GO - Release Band From Contract");
                Console.WriteLine("RESIGN - Resign Band");
                Console.WriteLine("SIGNED - View Signed Bands");
                Console.WriteLine("UNSIGNED - View Unsigned Bands");
                Console.WriteLine("QUIT - Quit the Program");
                Console.WriteLine();
                Console.WriteLine("CHOICE:");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "VIEW")
                {
                    foreach (var band in theBands)
                    {
                        Console.WriteLine($"There is a band named {band.Name}");
                    }
                }
                if (choice == "ADD BAND")
                {
                    Console.WriteLine("NAME: ");
                    var bandName = Console.ReadLine();
                    Console.WriteLine("COUNTRY: ");
                    var bandCountry = Console.ReadLine();
                    Console.WriteLine("NUMBER OF MEMBERS: ");
                    var bandMembers = int.Parse(Console.ReadLine());
                    Console.WriteLine("WEBSITE: ");
                    var bandWebsite = Console.ReadLine();
                    Console.WriteLine("STYLE: ");
                    var bandStyle = Console.ReadLine();
                    Console.WriteLine("SIGNED: ");
                    var bandSigned = bool.Parse(Console.ReadLine());
                    Console.WriteLine("CONTACT NAME: ");
                    var bandContactName = Console.ReadLine();
                    Console.WriteLine("CONTACT PHONE NUMBER: ");
                    var bandPhone = Console.ReadLine();

                    var newBand = new Band()
                    {
                        Name = bandName,
                        CountryOfOrigin = bandCountry,
                        NumberOfMembers = bandMembers,
                        Website = bandWebsite,
                        Style = bandStyle,
                        IsSigned = bandSigned,
                        ContactName = bandContactName,
                        ContactPhoneNumber = bandPhone,
                    };
                    theBands.Add(newBand);
                }
                if (choice == "ADD ALBUM")
                {
                    Console.WriteLine("TITLE: ");
                    var albumTitle = Console.ReadLine();
                    Console.WriteLine("EXPLICIT?: ");
                    var albumIsExplicit = bool.Parse(Console.ReadLine());
                    Console.WriteLine("RELEASE DATE: ");
                    var albumReleaseDate = Console.ReadLine();

                    var newAlbum = new Album()
                    {
                        Title = albumTitle,
                        IsExplicit = albumIsExplicit,
                        ReleaseDate = albumReleaseDate,

                    };
                    theAlbums.Add(newAlbum);



                }
                if (choice == "QUIT")
                {
                    hasQuitTheApplication = true;
                }

                Console.WriteLine("---GOODBYE---");
            }



        }
    }
}
