using System.Collections;
using System.Collections.Generic;
using cathode_ray_tube_src.Factory;
using cathode_ray_tube_src.Logic;
using FluentAssertions;
using NUnit.Framework;

namespace cathode_ray_tube_tests
{
    public class SolvesTests
    {
        [TestCase("example.txt", 13140)]
        public void WhenExecuteProcessor_WithStrengthCounter_ThenCounterShouldCalculateTotalValue(string fileName, int expected)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var counter = factory.CreateCounter();
            var processor = factory.CreateProcessor(counter);

            // act
            processor.Execute();

            // answer
            counter.Total.Should().Be(expected);
        }

        [TestCaseSource(nameof(ScreenDataSource))]
        public void WhenExecuteProcessor_WithTube_ThenShouldReturnScreen(string fileName, IEnumerable<char> expectedScreen)
        {
            // arrange
            var factory = new SolvesFactory(fileName);
            var tube = factory.CreateTube();
            var processor = factory.CreateProcessor(tube);

            // act
            processor.Execute();

            // answer
            tube.Screen().Should().Equal(expectedScreen);
        }

        private static IEnumerable ScreenDataSource()
        {
            yield return new object[]
            {
                "example.txt", ConvertToCharArray(new[]
                {
                    "##..##..##..##..##..##..##..##..##..##..",
                    "###...###...###...###...###...###...###.",
                    "####....####....####....####....####....",
                    "#####.....#####.....#####.....#####.....",
                    "######......######......######......####",
                    "#######.......#######.......#######.....",
                })
            };

            static IEnumerable<char> ConvertToCharArray(IEnumerable<string> lines)
            {
                foreach (var line in lines)
                {
                    foreach (var symbol in line)
                        yield return symbol;

                    yield return '\n';
                }
            }
        }
    }
}