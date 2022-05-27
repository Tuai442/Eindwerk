using Fitness.Domain.Models.Gebruikers;
using FitnessCentra.Domain.Interfaces;
using System;

namespace Fitness.Domain.Interfaces
{
    public interface ISessionRepository :IToestelRepository, IReserveerRepository, IGebruikerRepository
    {
        public List<Gebruiker> GeefAlleGebruikers();
        public Gebruiker GeefGebruikerOpEmail(string email);

    }
}

