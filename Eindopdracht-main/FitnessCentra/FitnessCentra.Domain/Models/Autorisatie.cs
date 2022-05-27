using Fitness.Domain.Interfaces;
using Fitness.Domain.Models.Gebruikers;
using FitnessCentra.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCentra.Domain.Models
{
    public class Autorisatie
    { 
        public Gebruiker Gebruiker { get; private set; }
        public bool IsIngelogd { get; set; }

        public bool VolledigeBevoegdheid { get; set; }
        private ISessionRepository _sessionRepository;

        public Autorisatie()
        {
            IsIngelogd = false;
        }

        public void LogIn(Gebruiker gebruiker, bool isBevoegd)
        {
            Gebruiker = gebruiker;
            VolledigeBevoegdheid = isBevoegd;
            IsIngelogd = true;
           
        }
        public void LogUit()
        {
            Gebruiker = null;
            IsIngelogd = false;
            VolledigeBevoegdheid = false;
        }
    }
}
