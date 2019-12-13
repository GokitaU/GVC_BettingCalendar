using BC.Data;
using BC.Data.Entities;
using BC.DTOs;
using BC.Services;
using BC.Services.CustomExeptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Tests.EditModeServiceTests
{
    [TestClass]
    public class UpdateEvent_Should
    {
        private int id = 1;
        private string eventName = "Manchester City - Burnley";
        private string oddsForFirst = "1.35";
        private string oddsForDraw = "3.30";
        private string oddsForSecond = "6.50";
        private string date = "12/12/2019";

        [TestMethod]
        public async Task UpdateEventProperties_WhenValidValuesPassed()
        {
            var options = TestUtils.GetOptions(nameof(UpdateEventProperties_WhenValidValuesPassed));

            using (var arrangeContext = new BettingContext(options))
            {
                var eventTest = new Event
                {
                    Id = 1,
                    EventName = "Arsenal - Liverpool",
                    OddsForFirstTeam = 3.2,
                    OddsForDraw = 2.9,
                    OddsForSecondTeam = 1.85,
                    EventStartDate = DateTime.Now
                };
                arrangeContext.Events.Add(eventTest);
                await arrangeContext.SaveChangesAsync();
                 

            }
            using (var assertContext = new BettingContext(options))
            {
                var sut = new EditModeService(assertContext);
                await sut.UpdateEvent(1, eventName, oddsForFirst, oddsForDraw, oddsForSecond, date);

                Assert.AreEqual(eventName, assertContext.Events.First().EventName);
                Assert.AreEqual(1.35, assertContext.Events.First().OddsForFirstTeam);
                Assert.AreEqual(3.30, assertContext.Events.First().OddsForDraw);
                Assert.AreEqual(6.50, assertContext.Events.First().OddsForSecondTeam);
            }
        }

        [TestMethod]
        public async Task Return_ValidEventDTO_WhenValidValuesPassed()
        {
            var options = TestUtils.GetOptions(nameof(Return_ValidEventDTO_WhenValidValuesPassed));

            using (var arrangeContext = new BettingContext(options))
            {
                var eventTest = new Event
                {
                    Id = 1,
                    EventName = "Arsenal - Liverpool",
                    OddsForFirstTeam = 3.2,
                    OddsForDraw = 2.9,
                    OddsForSecondTeam = 1.85,
                    EventStartDate = DateTime.Now
                };
                arrangeContext.Events.Add(eventTest);
                await arrangeContext.SaveChangesAsync();


            }
            using (var assertContext = new BettingContext(options))
            {
                var sut = new EditModeService(assertContext);
                var result = await sut.UpdateEvent(1, eventName, oddsForFirst, oddsForDraw, oddsForSecond, date);

                Assert.AreEqual(eventName, result.EventName);
                Assert.AreEqual(1.35, result.OddsForFirstTeam);
                Assert.AreEqual(3.30, result.OddsForDraw);
                Assert.AreEqual(6.50, result.OddsForSecondTeam);
                Assert.IsInstanceOfType(result,typeof(EventDTO));
            }
        }
        [TestMethod]
        public async Task ThrowBetException_IfInvalidFirstOddsValue_Passed()
        {
            var options = TestUtils.GetOptions(nameof(ThrowBetException_IfInvalidFirstOddsValue_Passed));

            using (var arrangeContext = new BettingContext(options))
            {
                var eventTest = new Event
                {
                    Id = 1,
                    EventName = "Arsenal - Liverpool",
                    OddsForFirstTeam = 3.2,
                    OddsForDraw = 2.9,
                    OddsForSecondTeam = 1.85,
                    EventStartDate = DateTime.Now
                };
                arrangeContext.Events.Add(eventTest);
                await arrangeContext.SaveChangesAsync();


            }
            using (var assertContext = new BettingContext(options))
            {
                var sut = new EditModeService(assertContext);

                var ex = await Assert.ThrowsExceptionAsync<BetException>(
                  async () => await sut.UpdateEvent(1, eventName, "d", oddsForDraw, oddsForSecond, date));
            }
        }

        [TestMethod]
        public async Task ThrowCorrect_BetException_IfInvalidOddsValue_Passed()
        {
            var options = TestUtils.GetOptions(nameof(ThrowCorrect_BetException_IfInvalidOddsValue_Passed));

            using (var arrangeContext = new BettingContext(options))
            {
                var eventTest = new Event
                {
                    Id = 1,
                    EventName = "Arsenal - Liverpool",
                    OddsForFirstTeam = 3.2,
                    OddsForDraw = 2.9,
                    OddsForSecondTeam = 1.85,
                    EventStartDate = DateTime.Now
                };
                arrangeContext.Events.Add(eventTest);
                await arrangeContext.SaveChangesAsync();


            }
            using (var assertContext = new BettingContext(options))
            {
                var sut = new EditModeService(assertContext);

                var ex = await Assert.ThrowsExceptionAsync<BetException>(
                  async () => await sut.UpdateEvent(1, eventName, "d", oddsForDraw, oddsForSecond, date));
                Assert.AreEqual("Invalid Model State!", ex.Message);
            }
        }

    }
}
