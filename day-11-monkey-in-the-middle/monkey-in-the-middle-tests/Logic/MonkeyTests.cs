using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using monkey_in_the_middle_src.Logic;
using monkey_in_the_middle_src.Logic.Abstract;
using monkey_in_the_middle_src.Logic.Data;
using Moq;
using NUnit.Framework;

namespace monkey_in_the_middle_tests.Logic
{
    public class MonkeyTests
    {
        [Test]
        public void WhenInventoryIsNotEmpty_ThenHasItems_ShouldReturnTrue()
        {
            // arrange
            var monkey = CreateMonkey(10, 20, 30);

            // act
            var result = monkey.HasItem;

            // answer
            result.Should().Be(true);
        }

        [Test]
        public void WhenInventoryIsEmpty_ThenHasItems_ShouldReturnFalse()
        {
            // arrange
            var monkey = CreateMonkey();

            // act
            var result = monkey.HasItem;

            // answer
            result.Should().Be(false);
        }

        [Test]
        public void WhenThrowItems_ThenShouldHasEmptyInventory()
        {
            // arrange
            var monkey = CreateMonkey(1, 2, 3);

            // act
            monkey.ThrowItems();
            var result = monkey.HasItem;

            // answer
            result.Should().Be(false);
        }

        [Test]
        public void WhenThrowItems_ThenShouldIncrementInspectionCount_ForEachItem()
        {
            // arrange
            var monkey = CreateMonkey(1, 2, 3, 4, 5);

            // act
            monkey.ThrowItems();
            var count = monkey.InspectionCount;

            // answer
            count.Should().Be(5);
        }
        
        [Test]
        public void WhenThrowItem_ThenShouldReturnThrowingItems_ForEachItem()
        {
            // arrange
            var monkey = CreateMonkey(10, 20, 30);

            // act
            var items = monkey.ThrowItems();

            // answer
            items.Select(x => x.Item.WorryLevel).Should().Equal(10, 20, 30);
        }

        [Test]
        public void WhenCatchItems_AndHasEmptyInventory_ThenShouldContainsItems()
        {
            // arrange
            var monkey = CreateMonkey();

            // act
            monkey.Catch(new Item(1));

            // answer
            monkey.HasItem.Should().Be(true);
        }

        private static Monkey CreateMonkey(params int[] worries)
        {
            var mockedBrain = Mock.Of<IBrain>();
            var items = worries.Select(worry => new Item(worry)).ToList();
            return new Monkey(mockedBrain, items);
        }
    }
}