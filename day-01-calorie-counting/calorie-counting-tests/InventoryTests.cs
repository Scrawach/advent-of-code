using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace day_01_calorie_counting
{
    public class InventoryTests
    {
        [Test]
        public void WhenInventoryCreated_ThenItShouldBeEmpty()
        {
            // arrange
            var inventory = new Inventory();

            // act

            // answer
            inventory.TotalCalories.Should().Be(0);
        }

        [TestCase(10, 10)]
        [TestCase(2718, 2718)]
        [TestCase(int.MaxValue, int.MaxValue)]
        public void WhenAddCalories_ThenTotalCaloriesShouldIncreased(int calories, int expected)
        {
            // arrange
            var inventory = new Inventory();

            // act
            inventory.Add(calories);

            // answer
            inventory.TotalCalories.Should().Be(expected);
        }

        [TestCase(new[] {1, 1, 1, 1}, 4)]
        [TestCase(new[] {20, 30, 40, 10}, 100)]
        public void WhenAddSeveralCalories_ThenTotalCaloriesShouldReturnTheirSum(IEnumerable<int> input, int expected)
        {
            // arrange
            var inventory = new Inventory();

            // act
            foreach (var item in input)
                inventory.Add(item);
            
            // answer
            inventory.TotalCalories.Should().Be(expected);
        }

        [Test]
        public void WhenAddGiantValues_ThenShouldThrowOverflowException()
        {
            // arrange
            var inventory = new Inventory();

            // act
            Action act = () =>
            {
                inventory.Add(int.MaxValue);
                inventory.Add(int.MaxValue);
            };

            // answer
            act.Should().Throw<OverflowException>();
        }
    }
}