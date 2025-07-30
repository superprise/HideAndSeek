using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HideAndSeekTests
{
    using HideAndSeek;
    using System.Collections.Generic;
    using System.Linq;
    [TestClass]
    public class LocationTests
    {
        private Location center;
        /// <summary>
        /// Initializes each unit test by setting creating a new the center location
        /// and adding a room in each direction before the test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            center = new Location("Center Room");
            Assert.AreSame("Center Room", center.ToString());
            Assert.AreEqual(0, center.ExitList.Count());
            center.AddExit(Direction.North, new Location("North Room"));
            center.AddExit(Direction.South, new Location("South Room"));
            center.AddExit(Direction.West, new Location("West Room"));
            center.AddExit(Direction.East, new Location("East Room"));
            center.AddExit(Direction.Northeast, new Location("NorthWest Room"));
            center.AddExit(Direction.Northwest, new Location("NorthEast Room"));
            center.AddExit(Direction.Southwest, new Location("SouthWest Room"));
            center.AddExit(Direction.Southeast, new Location("SouthEast Room"));
            center.AddExit(Direction.Up, new Location("Upper Room"));
            center.AddExit(Direction.Down, new Location("Downer Room"));
            //center.AddExit(Direction.In, new Location("inside Room"));
            //center.AddExit(Direction.Out, new Location("Outside Room"));
            // You'll use this to create a bunch of locations before each test

            Assert.AreEqual(10, center.ExitList.Count());
        }
        /// <summary>
        /// Make sure GetExit returns the location in a direction only if it exists
        /// </summary>
        [TestMethod]
        public void TestGetExit()
        {
            var eastRoom = center.GetExit(Direction.East);
            Assert.AreEqual("East Room", eastRoom.Name);
            Assert.AreSame(center, eastRoom.GetExit(Direction.West));
            Assert.AreSame(eastRoom, eastRoom.GetExit(Direction.Up));
            // This test will make sure the GetExit method works
        }
        /// <summary>
        /// Validates that the exit lists are working
        /// </summary>
        [TestMethod]
        public void TestExitList()
        {
            // This test will make sure the ExitList property works
        }
        /// <summary>
        /// Validates that each room’s name and return exit is created correctly
        /// </summary>
        [TestMethod]
        public void TestReturnExits()
        {
            // This test will test navigating through the center Location
        }
        /// <summary>
        /// Add a hall to one of the rooms and make sure the hall room’s names
        /// and return exits are created correctly
        /// </summary>
        [TestMethod]
        public void TestAddHall()
        {
            // This test will add a hallway with two locations and make sure they work
        }
    }
}