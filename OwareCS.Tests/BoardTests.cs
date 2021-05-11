/* This is an almost-complete translation of https://github.com/haarismemon/oware/ from Java to C#
*/
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

namespace Oware.Tests
{
    public class BoardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCapturingOwnSeedsAllHousesShouldBeEmpty()
        {
            // ARRANGE:
            Player p1 = new Player("alice");
            Player p2 = new Player("bob");
            IHouse[][] houses = new IHouse[2][];
            houses[0] = new IHouse[6];
            houses[1] = new IHouse[6];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    IHouse h = Substitute.For<IHouse>();
                    h.GetCount().Returns(0);
                    List<Seed> seeds =
                        new List<Seed>() { new Seed(), new Seed(), new Seed(), new Seed() };
                    h.GetSeedsAndEmptyHouse().Returns(seeds);
                    houses[i][j] = h;
                }
            }
            Board b = new Board(p1, p2, houses);
            // ACT:
            b.CaptureOwnSeeds();
            // ASSERT:
            Assert.AreEqual(0, b.GetNumSeedsOnRow(0), "There should be no seeds on top row");
            Assert.AreEqual(0, b.GetNumSeedsOnRow(1), "There should be no seeds on bottom row");
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 6; j++) {
                    houses[i][j].Received().GetSeedsAndEmptyHouse();
                    houses[i][j].Received().GetCount();
                }
            }
        }
    }
}