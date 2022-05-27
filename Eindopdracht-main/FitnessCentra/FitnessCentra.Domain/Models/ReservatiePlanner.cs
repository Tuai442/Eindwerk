
using Fitness.Domain.Interfaces;
using Fitness.Domain.Models.Gebruikers;
using FitnessCentra.Domain.Interfaces;
using FitnessCentra.Domain.Models;
using FitnessCentra.Domain.Models.Reservaties;

namespace Fitness.Domain.Models
{
    public class ReservatiePlanner
    {
        private List<Toestel> _toestellen;
        IToestelRepository _toestelRepository;
        IReserveerRepository _reservatieRepository;

        private const int OPENINGS_UUR = 8;
        private const int SLUITINGS_UUR = 22;
        private const int MAX_REZERVERINGEN_PER_DAG = 4;
        private const int MAX_REZERVERING_ACHTER_ELKAAR = 2;
        private const int TIJD_VOORWAARDEN = 7;


        public ReservatiePlanner(IToestelRepository toestelRepository, IReserveerRepository reservatieRepository)
        {
            _toestelRepository = toestelRepository;
            _reservatieRepository = reservatieRepository;
        }


        // Maak Reservatie
        public string MaakReservatie(Gebruiker gebruiker, Toestel toestel, DateTime datum, int toestelId,List<int> aantalUur)
        {

            List<(int, int)> gesorteerdeUren = SorteerUrenInLijst(datum, aantalUur);
            foreach ((int, int) tupleUur in gesorteerdeUren)
            {
                int totaalAantalUur = tupleUur.Item2 - tupleUur.Item1;
                DateTime beginDatum = new DateTime(datum.Year, datum.Month, datum.Day, tupleUur.Item1, 0, 0);
                DateTime eindDatum = beginDatum.AddHours(totaalAantalUur);
                Reservatie reservatie = new Reservatie(gebruiker, toestel, beginDatum, eindDatum);
                VoegReservatieToe(reservatie);
            }
            return null;
        }

        private List<(int, int)> SorteerUrenInLijst(DateTime datum, List<int> aantalUur)
        {
            List<(int, int)> uren = new List<(int StartUur, int EindUur)>();

            aantalUur.Sort();
            bool isOpeenVolgend = !aantalUur.Select((i, j) => i - j).Distinct().Skip(1).Any();
            if (!isOpeenVolgend)
            {
                List<int> getallenTemp1 = new List<int>(aantalUur);
                List<int> getallenTemp2 = new List<int>(aantalUur);
                do
                {
                    List<int> temp = new List<int>();
                    foreach (int getal in getallenTemp1)
                    {
                        temp.Add(getal);
                        bool isOpVolgorde = !temp.Select((i, j) => i - j).Distinct().Skip(1).Any();
                        if (!isOpVolgorde)
                        {
                            temp.RemoveAt(temp.Count - 1);
                            break;
                        }
                        getallenTemp2.Remove(getal);
                    }

                    uren.Add((temp.First(), temp.Last()));
                    getallenTemp1 = new List<int>(getallenTemp2);

                } while (getallenTemp1.Count != 0);

                return uren;
            }

            uren.Add((aantalUur.First(), aantalUur.Last()));
            return uren;
        }

        public void VoegReservatieToe(Reservatie reservatie)
        {
            _reservatieRepository.VoegRezerveringToe(reservatie);
        }

      
        // ------------------------------------------
        public string ControleVoorRezervering(DateTime datum, Gebruiker gebruiker, Toestel toestel, List<int> aantalUur)
        {
            List<int> aantalUurCopy = new List<int>(aantalUur);
            List<Reservatie> dagRezerveringen = GeefRezerveringenOpDag(datum);
            int totaalAantalUur = 0;
            foreach (Reservatie rezervering in dagRezerveringen)
            {
                //totaalAantalUur += rezervering.AantalUur;
                if (rezervering.Gebruiker.Equals(gebruiker) && rezervering.Toestel.Equals(toestel))
                {
                    totaalAantalUur += rezervering.AantalUur;
                    int aantalUurVanReservatie = rezervering.TotaalAantalUur();
                    int startUur = rezervering.BeginDatum.Hour;
                    for (int i = 0; i <= aantalUurVanReservatie; i++)
                    {
                        aantalUur.Add(startUur);
                        startUur++;
                    }
                }
                else if (rezervering.Gebruiker.Equals(gebruiker))
                {
                    totaalAantalUur += rezervering.AantalUur;
                    foreach (int uur in aantalUur)
                    {
                        if (rezervering.EindDatum.Hour == uur || rezervering.BeginDatum.Hour == uur)
                        {
                            return $"Je uren overlappen met rezervering van toestel: {rezervering.Toestel.ToString()}.";
                        }
                    }

                }
            }



            foreach(var uren in SorteerUrenInLijst(datum, aantalUurCopy))
            {
                totaalAantalUur += uren.Item2 - uren.Item1;
            }
            if (totaalAantalUur > MAX_REZERVERINGEN_PER_DAG)
            {
                return $"Je mag max {MAX_REZERVERINGEN_PER_DAG} sloten per dag rezerveren.";

            }



            List<(int, int)> gesorteerdeUren = SorteerUrenInLijst(datum, aantalUur);
            foreach (var uren in gesorteerdeUren)
            {
                int vershil = uren.Item2 - uren.Item1;
               
                if (vershil > MAX_REZERVERING_ACHTER_ELKAAR)
                {
                    return $"Je mag max {MAX_REZERVERING_ACHTER_ELKAAR} sloten achter elkaar gebruiken";
                }
                else if (vershil < 1)
                {
                    return "Voor te kunnen rezerveren moet je minimum twee sloten selecteren.";
                }
            }

            

            return null;
        }

        public List<Reservatie> GeefRezerveringenOpDag(DateTime datum)
        {
            List<Reservatie> result = new List<Reservatie>();
            List<Reservatie> reserveringen = _reservatieRepository.GeefAlleRezerveringen();
            foreach (Reservatie res in reserveringen)
            {
                if (res.IsDezelfdeDag(datum))
                {
                    result.Add(res);
                }
            }
            return result;
        }
        private void OrderLijstOpDatum(List<Reservatie> reserveringen)
        {
            reserveringen.Sort((x, y) => y.BeginDatum.CompareTo(x.BeginDatum));
        }
        public int GeefToegelatenAantalUurPerToestel()
        {
            return MAX_REZERVERINGEN_PER_DAG;
        }
        public Dictionary<int, Dictionary<int, Reservatie>> GeefDagPlanning(DateTime datum)
        {
            Dictionary<int, Dictionary<int, Reservatie>> result = GeefReservatiesOpDag(datum);

            result = result.OrderBy(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value);
            return result;
        }
        private Dictionary<int, Dictionary<int, Reservatie>> GenereerLeegeDag()
        {
            Dictionary<int, Dictionary<int, Reservatie>> result = new Dictionary<int, Dictionary<int, Reservatie>>();
            List<Toestel> toestellen = _toestelRepository.GeefAlleToestellen();
            int aantalSloten = GeefAantalSlotenPerDag();

            for (int i = OPENINGS_UUR; i <= OPENINGS_UUR + aantalSloten; i++)
            {
                result[i] = new Dictionary<int, Reservatie>();
                foreach (Toestel toestel in toestellen)
                {
                    result[i].Add(toestel.Id, null);
                }
            }
            return result;

        }
        private Dictionary<int, Dictionary<int, Reservatie>> GeefReservatiesOpDag(DateTime datum)
        {
            List<Reservatie> reserveringen = _reservatieRepository.GeefAlleRezerveringen();
            Dictionary<int, Dictionary<int, Reservatie>> result = GenereerLeegeDag();

            foreach (Reservatie reservatie in reserveringen)
            {
                if (reservatie.IsDezelfdeDag(datum))
                {
                    for (int i = 0; i <= reservatie.AantalUur; i++)
                    {
                        result[reservatie.BeginDatum.Hour + i][reservatie.Toestel.Id] = reservatie;
                    }
                }
            }



            return result;
        }
        internal List<Reservatie> GeefAlleReservatieVanToestelId(int id)
        {
            List<Reservatie> reserveringen = _reservatieRepository.GeefAlleRezerveringen();
            List<Reservatie> result = new List<Reservatie>();

            foreach (Reservatie reservatie in reserveringen)
            {
                if (reservatie.Toestel.Id == id)
                {
                    result.Add(reservatie);
                }
            }
            OrderLijstOpDatum(result);
            return result;
        }

        public int GeefAantalSlotenPerDag()
        {
            return SLUITINGS_UUR - OPENINGS_UUR;
        }
        public int GeefTijdVoorwaarden()
        {
            return TIJD_VOORWAARDEN;
        }


    }
}