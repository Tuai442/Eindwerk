using Fitness.Domain.Interfaces;
using Fitness.Domain.Models;
using Fitness.Domain.Models.Gebruikers;
using FitnessCentra.Domain.Interfaces;
using FitnessCentra.Domain.Models;
using FitnessCentra.Domain.Models.Reservaties;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Fitness.Domain
{
	public class DomainController
	{
        private IGebruikerRepository _gebruikerRepository;
        private IToestelRepository _toestelRepository;
        private IReserveerRepository _reserveerRepository;

		private ReservatiePlanner _reservatiePlanner;
		private Autorisatie _auorisatie;

		public DomainController(IGebruikerRepository gebruikerRepository, IToestelRepository toestelRepository,
			IReserveerRepository reserveerRepository)
		{
			_gebruikerRepository = gebruikerRepository;
			_toestelRepository = toestelRepository;
			_reserveerRepository = reserveerRepository;
			List<Reservatie> reserveringen = _reserveerRepository.GeefAlleRezerveringen();
			List<Toestel> toestellen = _toestelRepository.GeefAlleToestellen();
			
			_reservatiePlanner = new ReservatiePlanner(_toestelRepository, _reserveerRepository);
			_auorisatie = new Autorisatie();

		}


        // ----------------------- Log in/uit -----------------------

        public bool LogGebruikerInMetInlogGegevens(string inlogGegevens, bool isBevoegd)
		{
			Gebruiker gebruiker = _gebruikerRepository.GeefGebruikerOpEmail(inlogGegevens);
			if(gebruiker == null)
            {
				int id;
				int.TryParse(inlogGegevens, out id);
				gebruiker = _gebruikerRepository.GeefGebruikerOpKlantNr(id);
            }
			if(gebruiker != null)
            {
				_auorisatie.LogIn(gebruiker, isBevoegd);
				return true;
			}
			return false;
		}

        public bool IsGebruikerVolledigBevoegd()
        {
			return _auorisatie.VolledigeBevoegdheid;
        }

        public bool IsGebruikerIngelogd()
		{
			return _auorisatie.IsIngelogd;
		}

		public void LogUit()
		{
			_auorisatie.LogUit();
		}


		// ----------------------- Toestellen -----------------------
		public string OnderhoudToestelBijVolgendeVrijstelling(int id)
		{
			if (_auorisatie.VolledigeBevoegdheid)
            {
				Toestel toestel = _toestelRepository.GeefToestelOpId(id);
				if (toestel != null)
				{
					toestel.OnderhoudBijVolgendeVrijStelling = true;
					List<Reservatie> rezerveringen = _reservatiePlanner.GeefAlleReservatieVanToestelId(id);
					
					if(rezerveringen.Count() > 0 )
                    {
						DateTime datum = rezerveringen.First().EindDatum.AddHours(1);
						toestel.OnderhoudsDatum = datum;
						_toestelRepository.UpdateToestel(toestel);
						return datum.ToString();
					}
                    else
                    {
						toestel.OnderhoudsDatum = DateTime.Now;
						_toestelRepository.UpdateToestel(toestel);

					}


				}
			}
			return null;
			
		}

		public string VerwijderToestel(int id)
		{
			if (_auorisatie.VolledigeBevoegdheid)
			{
				List<Toestel> toestels = _toestelRepository.GeefAlleToestellen();
				Toestel toestel = toestels.Find(x => x.Id == id);
				if (toestel != null)
				{
					toestel.VerwijderBijVolgendeVrijStelling = true;
					List<Reservatie> rezerveringen = _reservatiePlanner.GeefAlleReservatieVanToestelId(id);

					// Als er nog rezerveringen zijn worden die eerst uit gedaan.
					if (rezerveringen.Count() > 0)
					{
						DateTime datum = rezerveringen.First().EindDatum.AddHours(1);
						toestel.OnderhoudsDatum = datum;
						_toestelRepository.UpdateToestel(toestel);
						return datum.ToString();
					}
                    else
                    {
						toestel.OnderhoudsDatum = DateTime.Now;
						_toestelRepository.VerwijderToestel(id);
                    }

					
				}
			}
			return null;
		}

        public bool GeefBevoegdheidGebruiker()
        {
			return _auorisatie.VolledigeBevoegdheid;
        }

        public List<Toestel> GeefAlleToestellen()
		{
			List<Toestel> toestellen = _toestelRepository.GeefAlleToestellen();
			List<string> alleToestellen = new List<string>();
			foreach (Toestel toestel in toestellen)
            {
				alleToestellen.Add(toestel.ToString());
            }
			return toestellen;

		}

        public List<string> GeefAlleToestelTypes()
		{
			return  _toestelRepository.GeefAlleToestelTypes();
		}

		public Toestel GeefToeselOpId(int id)
		{
			Toestel toestel = _toestelRepository.GeefToestelOpId(id);
			if (toestel != null)
			{
				return toestel;
			}
			return null;
		}

        public Dictionary<string, List<Toestel>> GeefAlleToestellenPerType()
        {
            List<Toestel> toestellen = _toestelRepository.GeefAlleToestellen();
            Dictionary<string, List<Toestel>> result = new Dictionary<string, List<Toestel>>();
			List<string> alleToestellenTypes = GeefAlleToestelTypes();

			foreach (string type in alleToestellenTypes)
            {
                result[type] = new List<Toestel>();
            }

            foreach (Toestel toestel in toestellen)
            {
                result[toestel.Type].Add(toestel);
            }
            return result;
        }

        public void VoegToestelToe(string toestelType)
		{
			_toestelRepository.VoegToestelToe(toestelType);
		}

		// ----------------------- Reserveringen -----------------------
		public int GeefAantalSlotenPerDag()
		{
			return _reservatiePlanner.GeefAantalSlotenPerDag();
		}
		public List<Reservatie> GeefDag(DateTime datum)
		{
			List<Reservatie> reservaties = _reserveerRepository.GeefAlleRezerveringen();
			List<Reservatie> result = new List<Reservatie>();
			
			foreach(Reservatie res in reservaties)
            {
				if (res.BeginDatum.Month == datum.Month && res.BeginDatum.Day == datum.Day)
                {
					result.Add(res);
                }
            }
			return result;
		}

        public Dictionary<int, Dictionary<int, Reservatie>> GeefRezervatiesOpDatum(DateTime datum)
		{
			return _reservatiePlanner.GeefDagPlanning(datum);
		}

        public string MaakReservatie(DateTime datum, int toestelId, List<int> aantalUur)
		{
			Gebruiker gebruiker = _auorisatie.Gebruiker;
			Toestel toestel = _toestelRepository.GeefToestelOpId(toestelId);

			List<int> aantalUurCopy = new List<int>(aantalUur);
			string controleBericht = _reservatiePlanner.ControleVoorRezervering(datum, gebruiker, toestel, aantalUurCopy);
			if(controleBericht != null)
            {
				return controleBericht;
            }

			string bericht = _reservatiePlanner.MaakReservatie(gebruiker, toestel, datum, toestelId, aantalUur);
			return bericht;
			
		}

		public bool IsErEenReservatieOpDatum(DateTime datum)
        {
			List<Reservatie> reservaties = _reservatiePlanner.GeefRezerveringenOpDag(datum);
			if(reservaties.Count() > 0)
            {
				return true;
            }
			return false;
        }
        public bool IsDitDeGebruiker(int id)
        {
            if(_auorisatie.Gebruiker.Id == id)
            {
				return true;
            }
			return false;
        }

        public int GeefTijdVoorwaarden()
        {
			return _reservatiePlanner.GeefTijdVoorwaarden();
        }

		

	}

}
