using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace day_01_calorie_counting
{
    public class FirstTaskTests
    {
        private static readonly string WorkingDirectory = 
            Environment.CurrentDirectory[..Environment.CurrentDirectory.IndexOf("bin")];
        
        [TestCase("example.txt",24000)]
        public void WhenUsedTestData_ThenSolveShouldBeExpected(string path, int expected)
        {
            // arrange
            var exampleFilePath = Path.Combine(WorkingDirectory, path);
            var firstTask = new FirstTask(new InventoryDatabase(new Text(exampleFilePath)));
            
            // act

            // answer
            firstTask.Solve().Should().Be(expected);
        }
    }
}