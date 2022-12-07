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

        [TestCase(new[] {"1000", "", "1000", "2000", "", "5000"}, new[] { 1000, 3000, 5000 })]
        [TestCase(new[] {"100", "200", "300", "400"}, new[] { 1000 })]
        public void WhenGetAllInventories_ThenItShouldCreateInventoriesFromText_AndUseEmptyStringAsDelimiters(string[] text, int[] expected)
        {
            // arrange
            var textMock = new Mock<IText>();
            textMock.Setup(mock => mock.Lines()).Returns(text);
            var database = new InventoryDatabase(textMock.Object);
            
            // act

            // answer
            database.Inventories().Select(inventory => inventory.TotalCalories)
                .Should().Equal(expected);
        }
    }
}