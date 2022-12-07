using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace day_01_calorie_counting
{
    public class InventoryDatabaseTests
    {
        [TestCase("1000")]
        public void WhenGetAllInventories_ThenItShouldCreateInventoryFromText(string text)
        {
            // arrange
            var textMock = new Mock<IText>();
            textMock.Setup(mock => mock.Lines()).Returns(new[] { text });
            var database = new InventoryDatabase(textMock.Object);

            // act

            // answer
            database.Inventories().Select(inventory => inventory.TotalCalories)
                .Should().Equal(int.Parse(text));
        }
    }
}