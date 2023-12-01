using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using supply_stacks_src.Storages;
using supply_stacks_src.Vehicles;

namespace supply_stacks_tests.Vehicles
{
    public class CrateMover9001Tests
    {
        [TestCaseSource(typeof(CrateMoverDataSource))]
        public void WhenMovedCrateMover_ThenShouldChangeStorageTopLine(Stack<char>[] initial, int count, int fromIndex, int toIndex, string expected)
        {
            // arrange
            var storage = new Storage(initial);
            var crateMover = new CrateMover9001(storage);

            // act
            crateMover.Move(count, fromIndex, toIndex);
            var topLine = storage.Top();
            
            // answer
            topLine.Should().Be(expected);
        }
        
        private class CrateMoverDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {Storages.StorageTests.InitialState(), 1, 3, 2, "NP"};
                yield return new object[] {Storages.StorageTests.InitialState(), 1, 1, 2, "ZNP"};
                yield return new object[] {Storages.StorageTests.InitialState(), 1, 2, 2, "NDP"};
                yield return new object[] {Storages.StorageTests.InitialState(), 2, 2, 3, "NMD"};
            }
        }
    }
}