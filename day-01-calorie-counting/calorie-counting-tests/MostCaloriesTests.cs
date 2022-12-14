using System;
using System.IO;
using day_01_calorie_counting.Counting;
using FluentAssertions;
using NUnit.Framework;

namespace day_01_calorie_counting
{
    public class MostCaloriesTests
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)];
        
        [TestCase("example.txt",24000)]
        public void WhenReadFile_ThenShouldReturnMostCaloriesNumber(string fileName, int expected)
        {
            // arrange
            var path = Path.Combine(WorkingDirectory, fileName);
            var mostCalories = new MostCalories(new InventoryDatabase(new Text(path)));
            
            // act

            // answer
            mostCalories.Solve().Should().Be(expected);
        }

        [TestCase("example.txt", 3, 45000)]
        public void WhenReadFile_ThenShouldReturnMostCaloriesSum_ForSeveralLeaders(string fileName, int numberOfLeaders, int expected)
        {
            // arrange
            var path = Path.Combine(WorkingDirectory, fileName);    
            var mostCalories = new MostCalories(numberOfLeaders, new InventoryDatabase(new Text(path)));

            // act

            // answer
            mostCalories.Solve().Should().Be(expected);
        }
    }
}