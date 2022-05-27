using Fitness.Domain.Models.Gebruikers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCentra.Domain.Models.Reservaties
{
    public class Reservatie
    {
        public Gebruiker Gebruiker { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int AantalUur { get; set; }
        public Toestel Toestel { get; set; }
        public Reservatie(Gebruiker gebruiker, Toestel toestel, DateTime startDatum, DateTime eindDatum)
        {
            Gebruiker = gebruiker;
            Toestel = toestel;
            BeginDatum = startDatum;
            EindDatum = eindDatum;
            AantalUur = eindDatum.Hour - startDatum.Hour;

        }
        public bool IsDezelfdeDag(DateTime datum)
        {
            if (datum.Year == BeginDatum.Year && datum.Month == BeginDatum.Month && datum.Day == BeginDatum.Day)
            {
                return true;
            }
            return false;
        }
        public override string? ToString()
        {
            return $"";
        }

        internal bool IsHetZelfdeUur(int huidigeUur)
        {
            return BeginDatum.Hour == huidigeUur;
        }

        internal int TotaalAantalUur()
        {
            return EindDatum.Hour - BeginDatum.Hour;
        }

        public bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Reservatie p = (Reservatie)obj;
                return (BeginDatum == p.BeginDatum) && (Toestel == p.Toestel) && (EindDatum == p.EindDatum);
            }
        }
    }
}
