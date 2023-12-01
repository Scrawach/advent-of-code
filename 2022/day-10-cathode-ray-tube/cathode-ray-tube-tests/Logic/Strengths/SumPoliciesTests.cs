using System.Collections;
using System.Collections.Generic;
using System.Linq;
using cathode_ray_tube_src.Logic.Strengths;
using cathode_ray_tube_src.Logic.Strengths.Abstract;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace cathode_ray_tube_tests.Logic.Strengths
{
    public class SumPoliciesTests
    {
        [TestCaseSource(nameof(SumPoliciesDataSource))]
        public void WhenCalculateScore_ThenShouldReturnSumOfAllPolicies(IEnumerable<int> calculatedResults, int expected)
        {
            // arrange
            var mocks = calculatedResults
                .Select(result => 
                    Mock.Of<IStrengthCalculatePolicy>(m => 
                        m.Calculate(It.IsAny<int>(), It.IsAny<int>()) == result))
                .ToArray();

            var sum = new SumCalculatePolicies(mocks);

            // act
            var score = sum.Calculate(0, 0);

            // answer
            score.Should().Be(expected);
        }

        private static IEnumerable SumPoliciesDataSource()
        {
            yield return new object[] {new[] {1}, 1};
            yield return new object[] {new[] {1, 2}, 3};
            yield return new object[] {new[] {1, 2, 3}, 6};
        }
    }
}