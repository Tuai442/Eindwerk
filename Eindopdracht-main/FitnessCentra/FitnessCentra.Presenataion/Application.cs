using Fitness.Domain;
using Fitness.Domain.Interfaces;
using System;


namespace Fitness.Presentation
{
	public class Application
	{
		private DomainController _domainController;
		private bool _isDeGebruikerIngelogd = false;
		public List<string> _inlogMenu = new List<string>() { "Inloggen", "Registreren"};


		public Application(DomainController controller)//DomainController domainController
		{
			_domainController = controller;
			StartProgramma();
		}

		public void StartProgramma()
		{
			bool isRunning = true;
			while (isRunning)
            {
				int optie = KiesOptie(_inlogMenu, "Kies een optie");
                switch (optie)
                {
					case 0:
						isRunning = false;
						break;
					case 1:
						Inloggen();
						break;
					case 2:
						Registreren(true);
						break;
                }

				//if (_domainController.GebruikerIsIngelogd)
				//{
				//	ReservatieMenu();
				//}

			}
		}

        private void BeheerderMenu()
        {
			bool ingelogd = true;
			while (ingelogd)
            {
				int optie = KiesOptie(new List<string> { "Onderhoud toestel", "Koop Nieuw toestel", "Stel toestel in dienst", "Verwijder toestel" }
				, "Welk toestel wil je onderhouden ?");

				////List<string> toestellen = _domainController.GeefAlleToestellen();
				//int id = 0;
				//switch (optie)
				//{
				//	case 1:
				//		id = KiesOptie(toestellen, "Welk toestel wil je onderhouden ?");
				//		_domainController.OnderhoudToestel(id);
				//		break;

				//	case 2:
				//		List<string> toestellTypes = _domainController.GeefAlleToestelTypes();
				//		int type = KiesOptie(toestellTypes, "Welk type toestel wil je kopen?");
				//		_domainController.KoopToestel(toestellTypes[type]);
				//		break;

				//	case 3:
				//		id = KiesOptie(toestellen, "Welk toestel wil je terug in dienst nemen ?");
				//		_domainController.StelToestelInDienst(id);
				//		break;

				//	case 4:
				//		id = KiesOptie(toestellen, "welk toestel wil je verwijderen?");
				//		_domainController.VerwijderToestel(id);
				//		break;

				//	case 0:
				//		ingelogd = false;
				//		_domainController.LogUit();
				//		break;
				//}
			}
			

        }

        private void ReservatieMenu()
        {
			List<string> beschikbareDatums = _domainController.GeefBeschibareDatums();
			int optie = KiesOptie(new List<string>() { "Maak reservering", "Bekijk en selecteer vrije plaats" }, "Reserveer nu");
            switch (optie)
            {
				case 0:
					break;
				case 2:
					int optieDatum = KiesOptie(beschikbareDatums, "Kies een datum");
					break;

                default:
                    break;
            }
        }

        private void Registreren(bool autoLogin = false)
        {
			string email = VraagInput("Geen een email adress in.");
			if (!_domainController.ValideerEmail(email))
            {
                Console.WriteLine("Fout email formaat");
				Registreren();
            };
			string pass1 = VraagInput("Geef een Wachtwoord in.");
			string pass2 = VraagInput("Geef het wachtwoord nog eens in.");
			if (!DomainController.ValideerWachtwoord(pass1, pass2))
            {
				Console.WriteLine("Fout wachtwoord formaat");
				Registreren();
            }
			if (autoLogin)
            {
			}

        }

        private void Inloggen()
        {
			int optie = KiesOptie(new List<string> { "Inloggen met email", "Inloggen met klantenNr." }, "Hoe wil je inloggen?");
			string pass = "";
			bool bericht = false;
			switch (optie)
            {
				case 0:
					break;
				case 1:
					string email = VraagInput("Geef email");
					break;
				case 2:
					string klantNr = VraagInput("Geef Klantnr.");
					int klantNrInt = ParseInt(klantNr);
					break;

            }
            Console.WriteLine(bericht);
            Console.WriteLine("----------");
        }

        private int ParseInt(string klantNr)
        {
            try
            {
				return int.Parse(klantNr);
            }
			catch (FormatException)
            {
				return 0;
            }
        }

        private int KiesOptie(List<string> menu, string vraag)
        {
			int index = 1;
			foreach (var text in menu) 
            {
                Console.WriteLine($"{index} - {text}");
				index++;
            }
            Console.WriteLine($"0 - Stoppen");

			string input = VraagInput(vraag);
			int parsedInput = 0;
			try
            {
				parsedInput = int.Parse(input);
            }
            catch (Exception)
            {

                throw;
            }
			if (parsedInput <= 0 && parsedInput >= menu.Count)
            {
				throw new Exception("Buiten bereik");
            }
			return parsedInput;

		}

        private string VraagInput(string v)
        {
            Console.WriteLine(v);
            return Console.ReadLine();
        }



    }
}

