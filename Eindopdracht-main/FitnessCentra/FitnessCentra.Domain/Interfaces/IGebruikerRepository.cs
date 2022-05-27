using Fitness.Domain.Interfaces;
using Fitness.Domain.Models.Gebruikers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCentra.Domain.Interfaces
{
    public interface IGebruikerRepository
    {
        Gebruiker GeefGebruikerOpEmail(string email);

        Gebruiker GeefGebruikerOpKlantNr(int klantNr);
    }
}
