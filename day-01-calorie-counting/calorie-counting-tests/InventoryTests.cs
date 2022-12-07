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
    }
}