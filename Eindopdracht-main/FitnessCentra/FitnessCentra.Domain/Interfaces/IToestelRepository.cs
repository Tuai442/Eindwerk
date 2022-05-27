using System;
using System.Collections.Generic;

namespace Fitness.Domain.Interfaces
{
	public interface IToestelRepository
	{
		public List<Toestel> GeefAlleToestellen();
		public List<Toestel> GeefToestellenOpType(string type);
		public Toestel GeefToestelOpId(int id);
		public void VoegToestelToe(string toestelType);
		public void UpdateToestel(Toestel toestel);
		public void VerwijderToestel(int id);
        List<string> GeefAlleToestelTypes();
    }

}
