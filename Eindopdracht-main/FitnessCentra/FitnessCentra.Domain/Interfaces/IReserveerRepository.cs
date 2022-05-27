using Fitness.Domain.Models;
using FitnessCentra.Domain.Models.Reservaties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCentra.Domain.Interfaces
{
    public interface IReserveerRepository
    {
        List<Reservatie> GeefAlleRezerveringen();
        void VoegRezerveringToe(Reservatie reservatie);
    }
}
