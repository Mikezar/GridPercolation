using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GridTest
{
    [TestClass]
    public class PercolationTest
    {
        [TestMethod]
        public void IsPercolateNonRandom()
        {
            //Arrange
            bool[,] test =
            {
                {true, false, true, false},
                {false, true, true, false},
                {false, true, false, true},
                {true, true, false, false}
            };

            //Act
            bool _result = GridPercolation.Percolation.Percolate(test);

            //Assert
            Assert.AreEqual(true, _result);
        }

        [TestMethod]
        public void IsPercolateNonRandom2()
        {
            //Arrange
            bool[,] test =
            {
                {true, true, true, true},
                {false, false, false, false},
                {false, false, false, false},
                {true, true, true, true}
            };

            //Act
            bool _result = GridPercolation.Percolation.Percolate(test);

            //Assert
            Assert.AreEqual(false, _result);
        }

        [TestMethod]
        public void WalkTest()
        {
            //Arrange
            bool[,] _testOpen =
            {
                {true, false, true, false},
                {false, true, true, false},
                {false, true, false,false},
                {true, false, true, false}
            };

            bool[,] _testFull = new bool[_testOpen.GetLength(0), _testOpen.GetLength(1)];

            //Act
            for (int j = 0; j < _testOpen.GetLength(0); j++)
            {
                GridPercolation.Percolation.GoThrough(_testOpen, _testFull, 0, j);
            };


            //Assert
            Assert.AreEqual(_testOpen[0,0], _testFull[0, 0]);
            Assert.AreEqual(_testOpen[2, 1], _testFull[2, 1]);
            Assert.AreEqual(false, _testFull[0, 3]);
            Assert.IsFalse(_testFull[3, 2]);
            Assert.IsTrue(_testOpen[3, 2]);
        }
    }
}
