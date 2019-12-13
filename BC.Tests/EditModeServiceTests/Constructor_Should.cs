using BC.Data;
using BC.Services;
using BC.Services.CustomExeptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BC.Tests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void MakeInstance_OfTypeEditModeService_IfValidValuePassed()
        {
            var options = TestUtils.GetOptions(nameof(MakeInstance_OfTypeEditModeService_IfValidValuePassed));

            var sut = new EditModeService(new BettingContext(options));

            Assert.IsInstanceOfType(sut, typeof(EditModeService));
        }

        [TestMethod]
        public void ThrowBetException_IfNullValueBettingContext_Passed()
        {
            Assert.ThrowsException<BetException>(
                ()=> new EditModeService(null));
        }
        [TestMethod]
        public void ThrowCorrect_BetException_IfNullValueBettingContext_Passed()
        {
            var ex = Assert.ThrowsException<BetException>(
                () => new EditModeService(null));

            Assert.AreEqual(ex.Message, "BettingContext cannot be null!");
        }
    }
}
