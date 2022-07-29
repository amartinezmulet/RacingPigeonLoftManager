using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPLM.BL.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RPLM.BL.Tests
{
    [TestClass]
    public class PigeoDataHelperTests
    {
        public Fixture fixture = new Fixture();

        [TestMethod]
        public void GetPigeoByIdTest_Pass()
        {
            // Arrange
            IEnumerable<Pigeon> pigeons = this.fixture.CreateMany<Pigeon>(10);
            PigeonDataHelper.Pigeons = pigeons.ToDictionary(it => it.BandId);
            Pigeon expected = pigeons.First();
            string bandId = expected.BandId;

            // Act
            Pigeon actual = PigeonDataHelper.GetPigeonById(bandId);

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetPigeoByIdTestNotFound_Pass()
        {
            // Arrange
            IEnumerable<Pigeon> pigeons = this.fixture.CreateMany<Pigeon>(10);
            PigeonDataHelper.Pigeons = pigeons.ToDictionary(it => it.BandId);
            string bandId = this.fixture.Create<string>();

            // Act
            Pigeon actual = PigeonDataHelper.GetPigeonById(bandId);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ExistPigeonFound_Pass()
        {
            // Arrange
            IEnumerable<Pigeon> pigeons = this.fixture.CreateMany<Pigeon>(10);
            PigeonDataHelper.Pigeons = pigeons.ToDictionary(it => it.BandId);
            string bandId = pigeons.Last().BandId;

            // Act
            bool actual = PigeonDataHelper.ExistPigeon(bandId);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ExistPigeonNotFound_Pass()
        {
            // Arrange
            IEnumerable<Pigeon> pigeons = this.fixture.CreateMany<Pigeon>(10);
            PigeonDataHelper.Pigeons = pigeons.ToDictionary(it => it.BandId);
            string bandId = this.fixture.Create<string>();

            // Act
            bool actual = PigeonDataHelper.ExistPigeon(bandId);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
