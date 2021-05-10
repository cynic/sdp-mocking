/* This is an almost-complete translation of https://github.com/haarismemon/oware/ from Java to C#
*/
using NUnit.Framework;

namespace Oware.Tests
{
    public class HouseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreatingHouseSeedCountIs4()
        {
            // ARRANGE:
            //   (nothing to do)
            // ACT:
            House h = new House(0, 0);
            // ASSERT:
            Assert.AreEqual(4, h.GetCount(), "New houses must have 4 seeds in them.");
        }

        [Test]
        public void WhenAddingSeedToHouseCountIsCorrect() {
            // ARRANGE:
            House h = new House(0, 0);
            // ACT:
            for (int i = 0; i < 16; i++) {
                h.AddSeedInPot(new Seed()); // <-- THIS IS THE METHOD WE ARE TESTING
            }
            // ASSERT:
            Assert.AreEqual(20, h.GetCount(), "Adding seeds to a pot increases the number of seeds in the pot.");
        }
    }
}