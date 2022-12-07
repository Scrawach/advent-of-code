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
    }
}