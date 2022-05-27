using System;
using System.Collections.Generic;
using System.Globalization;
using Fitness.Domain.Interfaces;
using Fitness.Domain.Models;
using Fitness.Domain.Models.Gebruikers;
using FitnessCentra.Domain.Interfaces;
using FitnessCentra.Domain.Models.Reservaties;

namespace Fitness.Percistence
{
	public class Percistence : ISessionRepository
	{
		private string _toestellenFile = @"FitnessToestellen.txt";
		private string _klantenFile = @"Klanten.txt";
		private string _reseravatieFile = @"Reservaties.txt";


		private List<Toestel> _toestellen;
		private List<Gebruiker> _gebruikers;
		private List<FitnessCentra.Domain.Models.Reservaties.Reservatie> _reseravaties;
        private List<string> verwerkteData;
       
		public Percistence()
		{
			_toestellen = new List<Toestel>();
			_gebruikers = new List<Gebruiker>();
            _reseravaties = new List<FitnessCentra.Domain.Models.Reservaties.Reservatie>();
			LaadDataVanTxtBestand();
		}


		public void LaadDataVanTxtBestand()
		{

            using (StreamReader reader = new StreamReader(_toestellenFile))
            {
                while (!reader.EndOfStream)
                {
					string[] data = reader.ReadLine().Split(',');
                    List<string> verwerkteData = VerwijderQuotes(data);
					int id = int.Parse(verwerkteData[0]);
					string type = (string)verwerkteData[1];
					Toestel toestel = new Toestel(id, type);
					_toestellen.Add(toestel);
                }
            }

			using (StreamReader reader = new StreamReader(_klantenFile))
			{
				while (!reader.EndOfStream)
				{
					string[] data = reader.ReadLine().Split(',');
					List<string> verwerkteData = VerwijderQuotes(data);

					DateTime dt = DateTime.ParseExact(verwerkteData[4], "yyyy-MM-dd HH:mm:ss", null);

					string intresse = verwerkteData[5];
					                    
					Gebruiker gebruiker = new Gebruiker(verwerkteData[0], verwerkteData[1], verwerkteData[2], 0,
						verwerkteData[3], dt, intresse, verwerkteData[5]);
					_gebruikers.Add(gebruiker);
				}
			}

            using (StreamReader reader = new StreamReader(_reseravatieFile))
            {
                while (!reader.EndOfStream)
                {
					string[] data = reader.ReadLine().Split(',');

					int id = int.Parse(data[0]);
					Toestel toestel = GeefToestelOpId(id);

					int aantalUur = int.Parse(data[2]);
					Gebruiker klant = GeefGebruikerOpVolledigeNaam(data[3]);

					DateTime beginDatum = DateTime.ParseExact(data[1], "yyyy-MM-dd HH:mm:ss", null);
					DateTime eindDatum = beginDatum.AddHours(aantalUur);

					Reservatie reservatie = new Reservatie(klant, toestel, beginDatum, eindDatum);
					_reseravaties.Add(reservatie);
				}

			}
		}

		public List<string> VerwijderQuotes(string[] woorden) 
        {
			List<string> temp = new List<string>();
			foreach (string s in woorden)
            {
				temp.Add(s.Replace("\'", ""));
            }
			return temp;

        }
	
        public List<Reservatie> GeefAlleRezerveringen()
        {
			return _reseravaties;
        }


		// ----------------------- Klant -----------------------

		public Gebruiker GeefGebruikerOpKlantNr(int klantNr)
		{
			foreach (var gebruiker in _gebruikers)
			{
				if (gebruiker.Id == klantNr)
				{
					return gebruiker;
				}
			}
			return null;
		}

		public List<Gebruiker> GeefGebruikerOpVoornaam(string voornaam)
		{
			throw new NotImplementedException();
		}

		public List<Gebruiker> GeefAlleGebruikers()
		{
			throw new System.NotImplementedException("Not implemented");
		}

		public Gebruiker GeefGebruikerOpVolledigeNaam(string volledigeNaam)
        {
			foreach(var gebruiker in _gebruikers)
            {
				if (gebruiker.VolledigeNaam() == volledigeNaam)
                {
					return gebruiker;
                }
            }
			return null;
        }

		public Gebruiker GeefGebruikerOpEmail(string email)
		{
			foreach (var gebruiker in _gebruikers)
			{
				if (gebruiker.Email == email)
				{
					return gebruiker;
				}
			}
			
			return null;
		}


		// ----------------------- Toestellen -----------------------


		// ----------------------- Toestellen -----------------------

		public List<Toestel> GeefAlleToestellen()
        {
			return _toestellen;
        }

        public void VoegToestelToe(string toestelType)
        {
        }

        public void UpdateToestel(Toestel toestel)
        {
			List<Toestel> geUpdateLijst = new List<Toestel>();
			foreach(Toestel t in _toestellen)
            {
				if (t.Id == toestel.Id)
                {
					geUpdateLijst.Add(toestel);
                }
                else
                {
					geUpdateLijst.Add(t);

				}
            }
			

		}

		public List<Toestel> GeefToestellenOpType(string type)
		{
			throw new NotImplementedException();
		}

		public Toestel GeefToestelOpId(int id)
		{
			foreach (var toestel in _toestellen)
			{
				if (toestel.Id == id)
				{
					return toestel;
				}
			}
			return null;
		}

        public void VoegRezerveringToe(Reservatie reservatie)
        {
            throw new NotImplementedException();
        }

        public void VerwijderToestel(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GeefAlleToestelTypes()
        {
            throw new NotImplementedException();
        }
    }
}

