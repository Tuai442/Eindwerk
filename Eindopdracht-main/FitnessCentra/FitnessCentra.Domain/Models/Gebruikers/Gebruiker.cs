
using System;


namespace Fitness.Domain.Models.Gebruikers { 

	public class Gebruiker {

        public int Id { get; set; }
        public string Intresse { get; set; }
        public string KlantType { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }

        public  DateTime GeboorteDatum;

		public Gebruiker(string naam, string achternaam, string email, int id, string adres, DateTime geboorteDatum, string intresse, string klantType) {

            Id = id;
            Voornaam = naam;
			Achternaam = achternaam;
			Email = email;
            Adres = adres;
            GeboorteDatum = geboorteDatum;
            Intresse = intresse;
            KlantType = klantType;

        }

        public string VolledigeNaam()
        {
            return $"{Voornaam} {Achternaam}";
        }
        public override string? ToString()
        {
            return $"{Voornaam} {Achternaam}";
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Gebruiker g = (Gebruiker)obj;
                return (Id == g.Id);
            }
        }
    }
}