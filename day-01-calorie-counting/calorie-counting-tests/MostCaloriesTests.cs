using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace day_01_calorie_counting
{
    public class MostCaloriesTests
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin")];
        
        [TestCase("example.txt",24000)]
        public void WhenReadFile_ThenShouldReturnMostCaloriesNumber(string path, int expected)
        {
            // arrange
            var exampleFilePath = Path.Combine(WorkingDirectory, path);
            var mostCalories = new MostCalories(new InventoryDatabase(new Text(exampleFilePath)));
            
            // act

            // answer
            mostCalories.Solve().Should().Be(expected);
        }

        [TestCase("example.txt", 45000, 3)]
        public void WhenReadFile_ThenShouldReturnMostCaloriesSum_ForSeveralLeaders(string filePath, int expected, int numberOfLeaders)
        {
            // arrange
            var path = Path.Combine(WorkingDirectory, filePath);    
            var mostCalories = new MostCalories(numberOfLeaders, new InventoryDatabase(new Text(path)));

            // act

            // answer
            mostCalories.Solve().Should().Be(expected);
        }
    }
}