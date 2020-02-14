using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Tests
{
    public class DamageCalculatorTests
    {
       [Test]
       [TestCase(100, 50, 10, false, 60)]
       [TestCase(100, 200, 10, false, 0)]
       [TestCase(100, 20, 0, true, 60)]
       [TestCase(100, 40, 30, true, 20)]
       [TestCase(100, 40, 60, false, 100)]
       [TestCase(100, 160, 60, true, 0)]
       public void CalculateDamage_Test(float health, float damage, float defense, bool critical, float expectedHealth) {
           var damageCalculator = new DamageCalculator();
           var remainingHealth = damageCalculator.calculate(health, damage, defense, critical);

           Assert.That(remainingHealth, Is.EqualTo(expectedHealth));
       }

       [Test]
        public void CalculateDamage_NegativeHealth_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DamageCalculator().calculate(-1, 0, 1, false));
        }

        [Test]
        public void CalculateDamage_NegativeDamage_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DamageCalculator().calculate(0, -1, 1, false));
        }

        [Test]
        public void CalculateDamage_NegativeDefense_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DamageCalculator().calculate(1, 0, -1, false));
        }
    }
}
