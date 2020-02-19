using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutingsClassLibrary;

namespace OutingsTests
{
    [TestClass]
    public class OutingRepoTests
    {
        OutingRepository _outings = new OutingRepository();
        [TestInitialize]
        public void Arrange()
        {
            GolfOuting golfOuting1 = new GolfOuting();
            golfOuting1.TotalCost = 500m;
            _outings.AddOuting(golfOuting1);

            GolfOuting golfOuting2 = new GolfOuting();
            golfOuting2.TotalCost = 250m;
            _outings.AddOuting(golfOuting2);

            ConcertOuting concertOuting1 = new ConcertOuting();
            concertOuting1.TotalCost = 200m;
            _outings.AddOuting(concertOuting1); 
            
            ConcertOuting concertOuting2 = new ConcertOuting();
            concertOuting2.TotalCost = 400m;
            _outings.AddOuting(concertOuting2);

            AmusementParkOuting amusement1 = new AmusementParkOuting();
            amusement1.TotalCost = 1000m;
            _outings.AddOuting(amusement1);
            
            AmusementParkOuting amusement2 = new AmusementParkOuting();
            amusement2.TotalCost = 2000m;
            _outings.AddOuting(amusement2);

            BowlingOuting bowling1 = new BowlingOuting();
            bowling1.TotalCost = 100m;
            _outings.AddOuting(bowling1);
            
            BowlingOuting bowling2 = new BowlingOuting();
            bowling2.TotalCost = 300m;
            _outings.AddOuting(bowling2);


        }

        [TestMethod]
        public void AddOuting_ShouldReturnTrue()
        {
            //Arrange
            GolfOuting golfOuting = new GolfOuting();

            //Act
            bool actual = _outings.AddOuting(golfOuting);

            //Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void GetAllOutings_ShouldReturnCorrectCount()
        {
            //Arrange - TestInit

            //Act
            List<IOuting> outings = _outings.GetAllOutings();
            int actual = outings.Count;
            int expected = 8;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTotalCostOfGolfOutings_ShouldReturnCorrectTotal()
        {
            //Arrange - Test Init

            //Act
            decimal actual = _outings.GetTotalCostOfGolfOutings();
            decimal expected = 750m;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTotalCostOfConcertOutings_ShouldReturnCorrectTotal()
        {
            //Arrange - Test Init

            //Act
            decimal actual = _outings.GetTotalCostOfConcertOutings();
            decimal expected = 600m;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTotalCostOfAmusementParkOutings_ShouldReturnCorrectTotal()
        {
            //Arrange - Test Init

            //Act
            decimal actual = _outings.GetTotalCostOfAmusementParkOutings();
            decimal expected = 3000m;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTotalCostOfBowlingOutings_ShouldReturnCorrectTotal()
        {
            //Arrange - Test Init

            //Act
            decimal actual = _outings.GetTotalCostOfBowlingOutings();
            decimal expected = 400m;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTotalCostOfAllOutings_ShouldReturnCorrectTotal()
        {
            //Arrange - Test Init

            //Act
            decimal actual = _outings.GetTotalCostOfAllOutings();
            decimal expected = 4750;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
