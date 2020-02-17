using System;
using System.Collections.Generic;
using BadgeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTests
{
    [TestClass]
    public class BadgeTests
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();
        private void Arrange()
        {
            List<Door> doors1 = new List<Door>();
            doors1.Add(new Door("A1"));
            doors1.Add(new Door("A2"));
            doors1.Add(new Door("A3"));
            doors1.Add(new Door("A4"));


            List<Door> doors2 = new List<Door>();
            doors2.Add(new Door("B1"));
            doors2.Add(new Door("B2"));
            doors2.Add(new Door("B3"));
            doors2.Add(new Door("B4"));
            
            
            Badge badge1 = new Badge("1234", doors1);
            Badge badge2 = new Badge("5678", doors2);

            _badgeRepo.AddBadgeToDirectory(badge1);
            _badgeRepo.AddBadgeToDirectory(badge2);
        }

        [TestMethod]
        public void AddBadgeToDirectory_ShouldReturnTrue()
        {
            //Arrange
            List<Door> doors1 = new List<Door>();
            doors1.Add(new Door("A1"));
            doors1.Add(new Door("A2"));
            doors1.Add(new Door("A3"));
            doors1.Add(new Door("A4"));

            Badge badge1 = new Badge("1234", doors1);

            //Act 
            bool expected = _badgeRepo.AddBadgeToDirectory(badge1);

            //Assert
            Assert.IsTrue(expected);
        }
        [TestMethod]
        public void GetListOfDoorsByID_ShouldReturnCorrectList()
        {
            //Arrange
            Arrange();

            //Act
            List<Door> doors = _badgeRepo.GetListOfDoorsByID("1234");
            int expected = 4;
            int actual = doors.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddDoorToList_ShouldReturnTrue()
        {
            //Arrange
            Arrange();

            //Act
            Door door = new Door("B6");
            bool wasAdded = _badgeRepo.AddDoorToList("1234", door);

            //Assert
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void AddDoorToList_IDNotPresent_ShouldReturnFalse()
        {
            //Arrange
            Arrange();

            //Act
            Door door = new Door("B6");
            bool wasAdded = _badgeRepo.AddDoorToList("2020", door);

            //Assert
            Assert.IsFalse(wasAdded);
        }
        [TestMethod]
        public void RemoveDoorFromList_ShouldReturnTrue()
        {
            //Arrange
            Arrange();

            //Act
            Door door = new Door("A1");
            bool wasRemoved = _badgeRepo.RemoveDoorFromList("1234", door);

            //Assert
            Assert.IsTrue(wasRemoved);
        }
        [TestMethod]
        public void RemoveDoorFromList_IDNotPresent_ShouldReturnFalse()
        {
            //Arrange
            Arrange();

            //Act
            Door door = new Door("A1");
            bool wasRemoved = _badgeRepo.RemoveDoorFromList("2020", door);

            //Assert
            Assert.IsFalse(wasRemoved);
        }
    }
}
