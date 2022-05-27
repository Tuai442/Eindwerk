using Xunit;
using Fitness.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessCentra.Domain.Interfaces;
using Fitness.Domain.Interfaces;
using FitnessCentra.Persictance.Mappers;

namespace Fitness.Domain.Tests
{
    public class DomainControllerTests
    {
        private IGebruikerRepository _gebruikerRepository = new GebruikerMapper();
        private IToestelRepository _toestelRepository = new ToestelMapper();
        private IReserveerRepository _reserveerRepository = new ReserveringMapper();
        public static readonly object[][] TestData =
        {
            new object[] { new DateTime(2017,3,1), 1, new List<int>() { 1, 2 } },
        };


        [Theory, MemberData(nameof(TestData))]
        public void MaakReservatieTest(DateTime datum, int id, List<int> uren)
        {
            DomainController controller = new DomainController(_gebruikerRepository, _toestelRepository, _reserveerRepository);

            var result = controller.MaakReservatie(datum, id, uren);

            Assert.Null(result);
        }

        [InlineData("Goedele.Jackson@telenet.com")]
        [InlineData("1")]
        public void LogGebruikerInMetInlogGegevensTest(string inlogGegevens)
        {
            DomainController controller = new DomainController(_gebruikerRepository, _toestelRepository, _reserveerRepository);

            bool inloggenGelukt = controller.LogGebruikerInMetInlogGegevens(inlogGegevens, true);


            Assert.True(inloggenGelukt);
        }

        [InlineData("foute info")]
        [InlineData("-100")]
        public void LogGebruikerInMetFouteInlogGegevensTest(string inlogGegevens)
        {
            DomainController controller = new DomainController(_gebruikerRepository, _toestelRepository, _reserveerRepository);

            bool inloggenGelukt = controller.LogGebruikerInMetInlogGegevens(inlogGegevens, true);


            Assert.False(inloggenGelukt);
        }
    }
}