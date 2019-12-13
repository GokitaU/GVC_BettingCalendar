using BC.Data;
using BC.DTOs;
using BC.Services;
using BC.Services.CustomExeptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace BC.Tests.EditModeServiceTests
{
    [TestClass]
    public class AddEvent_Should
    {
        private string eventName = "Manchester City - Burnley";
        private string oddsForFirst = "1.35";
        private string oddsForDraw = "3.30";
        private string oddsForSecond = "6.50";
        private string date = "12/12/2019";

        [TestMethod]
        public async Task AddEvent_ToDb_IfValidValuesPassed()
        {
            var options = TestUtils.GetOptions(nameof(AddEvent_ToDb_IfValidValuesPassed));

            using (var assertContext = new BettingContext(options))
            {
                var sut = new EditModeService(assertContext);
                await sut.AddEvent(eventName, oddsForFirst, oddsForDraw, oddsForSecond, date);

                Assert.AreEqual(eventName, assertContext.Events.First().EventName);
                Assert.AreEqual(1.35, assertContext.Events.First().OddsForFirstTeam);
                Assert.AreEqual(3.30, assertContext.Events.First().OddsForDraw);
                Assert.AreEqual(6.50, assertContext.Events.First().OddsForSecondTeam);
            }
        }
        [TestMethod]
        public async Task ReturnEventDTO_WithValidParams_IfValidValuesPassed()
        {
            var options = TestUtils.GetOptions(nameof(ReturnEventDTO_WithValidParams_IfValidValuesPassed));

            using (var assertContext = new BettingContext(options))
            {
                var sut = new EditModeService(assertContext);
                var result = await sut.AddEvent(eventName, oddsForFirst, oddsForDraw, oddsForSecond, date);

                Assert.AreEqual(eventName, result.EventName);
                Assert.AreEqual(1.35, result.OddsForFirstTeam);
                Assert.AreEqual(3.30, result.OddsForDraw);
                Assert.AreEqual(6.50, result.OddsForSecondTeam);
                Assert.IsInstanceOfType(result,typeof(EventDTO));
            }
        }

        [TestMethod]
        public async Task ThrowBetException_IfInvalidOddValuesPassed()
        {
            var options = TestUtils.GetOptions(nameof(ThrowBetException_IfInvalidOddValuesPassed));

            using (var assertContext = new BettingContext(options))
            {
                var sut = new EditModeService(assertContext);

                var ex = await Assert.ThrowsExceptionAsync<BetException>(
                 async () => await sut.AddEvent(eventName, "dds", oddsForDraw, oddsForSecond, date));
            }
        }
    }
}
