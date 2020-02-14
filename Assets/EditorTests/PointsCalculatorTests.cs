using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PointsCalculatorTests
    {
        // A Test behaves as an ordinary method
        [Test]
        [TestCase(3, 0, 1, 300)]
        [TestCase(5, 0, 1, 500)]
        [TestCase(5, 0, 2, 1000)]
        [TestCase(5, 1, 2, 800)]
        [TestCase(10, 0, 1, 1500)]
        [TestCase(21, 0, 2, 6200)]
        [TestCase(11, 3, 1, 1300)]
        [TestCase(10, 10, 5, 500)]
        [TestCase(0, 4, 1, 0)]
        public void CalculatePoints_Test(int killedEnemies, int killedAllies, int multiplicator, int expectedPoints)
        {        
            var pointsCalculator = new PointsCalculator();

            var points = pointsCalculator.CalculatePoints(killedEnemies, killedAllies, multiplicator);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [Test]
        public void CalculatePoints_NegativeKilledEnemies_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PointsCalculator().CalculatePoints(-1, 0, 1));
        }
    
    }
}
