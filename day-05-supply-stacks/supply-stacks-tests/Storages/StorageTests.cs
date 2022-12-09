using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using supply_stacks_src.Storages;

namespace supply_stacks_tests.Storages
{
    public class StorageTests
    {
        [TestCaseSource(typeof(InitialTestCases))]
        public void WhenInitial_ThenShouldReturnTopLineFromStacks(Stack<char>[] initial, string expected)
        {
            // arrange
            var storage = new Storage(initial);

            // act
            var line = storage.Top();

            // answer
            line.Should().Be(line);
        }

        [TestCaseSource(typeof(TakeDataSource))]
        public void WhenTake_ThenShouldReturnSymbolFromStack(Stack<char>[] initial, int takeFrom, char expected)
        {
            // arrange
            var storage = new Storage(initial);

            // act
            var box = storage.Take(takeFrom);

            // answer
            box.Should().Be(expected);
        }
        
        [TestCaseSource(typeof(PutDataSource))]
        public void WhenPut_ThenShouldChangeTop(Stack<char>[] initial, char symbol, int target, string expected)
        {
            // arrange
            var storage = new Storage(initial);

            // act
            storage.Put(symbol, to: target);
            var line = storage.Top();

            // answer
            line.Should().Be(expected);
        }

        [TestCaseSource(typeof(ComplexDataSource))]
        public void WhenTakeFromOneStack_AndPutInAnother_ThenShouldChangeTopLine(Stack<char>[] initial, int from, int target, string expected)
        {
            // arrange
            var storage = new Storage(initial);

            // act
            var box = storage.Take(from);
            storage.Put(box, to: target);
            var line = storage.Top();

            // answer
            line.Should().Be(expected);
        }

        private class InitialTestCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {InitialState(), "NDP"};
            }
        }
        
        private class TakeDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {InitialState(), 1, 'N'};
                yield return new object[] {InitialState(), 2, 'D'};
                yield return new object[] {InitialState(), 3, 'P'};
            }
        }
        
        private class PutDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {InitialState(), 'J', 1, "JDP"};
                yield return new object[] {InitialState(), 'J', 2, "NJP"};
                yield return new object[] {InitialState(), 'J', 3, "NDJ"};
            }
        }

        private class ComplexDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {InitialState(), 1, 1, "NDP"};
                yield return new object[] {InitialState(), 2, 2, "NDP"};
                yield return new object[] {InitialState(), 3, 3, "NDP"};
                yield return new object[] {InitialState(), 2, 3, "NCD"};
                yield return new object[] {InitialState(), 2, 1, "DCP"};
                yield return new object[] {InitialState(), 3, 1, "PD" };
            }
        }
        
        internal static Stack<char>[] InitialState() =>
            new[]
            {
                CreateStack('Z', 'N'),
                CreateStack('M', 'C', 'D'),
                CreateStack('P')
            };
        
                    
        private static Stack<char> CreateStack(params char[] chars) =>
            new Stack<char>(chars);

    }
}