using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using rucksack_reorganization_src.Factory;
using rucksack_reorganization_src.Logic;
using rucksack_reorganization_src.Logic.Abstract;
using rucksack_reorganization_src.Storages.Abstract;

namespace rucksack_reorganization_tests.Logic
{
    public class RucksackReorganizationTests
    {
        [TestCaseSource(typeof(ReorganizationDataSource))]
        public void WhenGetTotalPriorityScore_ThenShouldReturnPrioritySumAllRepeatedSymbols(Rucksack[] rucksacks, Func<char, int> priority, int expected)
        {
            // arrange
            var storageMock = new Mock<IRucksackStorage>();
            var priorityMock = new Mock<IPriority>();

            storageMock.Setup(mock => mock.All()).Returns(rucksacks);
            priorityMock.Setup(mock => mock.Convert(It.IsAny<char>())).Returns(priority);
            
            var rucksackReorganization = new RucksackReorganization(storageMock.Object, priorityMock.Object);

            // act
            var totalScore = rucksackReorganization.TotalPriorityScore();

            // answer
            totalScore.Should().Be(expected);
        }

        [TestCase("example.txt", 157)]
        public void WhenReadRucksacksFromText_ThenShouldReturnExpectedPriorityScore_WithSingleStorage(string fileName, int expected)
        {
            // arrange
            var factory = new ReorganizationFactory(fileName);
            var reorganization = factory.Single();

            // act
            var totalScore = reorganization.TotalPriorityScore();

            // answer
            totalScore.Should().Be(expected);
        }

        [TestCase("example.txt", 70)]
        public void WhenReadRucksacksFromText_ThenShouldReturnExpectedPriorityScore_WithGroupStorage(string fileName, int expected)
        {
            // arrange
            var factory = new ReorganizationFactory(fileName);
            var reorganization = factory.Group();

            // act
            var totalScore = reorganization.TotalPriorityScore();

            // answer
            totalScore.Should().Be(expected);
        }

        private class ReorganizationDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {TestRucksacks('a', 'b', 'c').ToArray(), Always(0), 0};
                yield return new object[] {TestRucksacks('a', 'b', 'c').ToArray(), Always(1), 3};
                yield return new object[] {TestRucksacks('a', 'b', 'c').ToArray(), Always(5), 15};
            }

            private IEnumerable<Rucksack> TestRucksacks(params char[] repeated) =>
                repeated.Select(repeat => new Rucksack($"{repeated}{repeated}"));

            private Func<char, int> Always(int value) =>
                symbol => value;
        }
    }
}