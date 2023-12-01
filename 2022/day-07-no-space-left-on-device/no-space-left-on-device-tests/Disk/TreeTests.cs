using FluentAssertions;
using no_space_left_on_device_src.Disk;
using NUnit.Framework;

namespace no_space_left_on_device_tests.Disk
{
    public class TreeTests
    {
        [TestCase(10)]
        public void WhenAddChild_ThenItShouldBeInChildrenArray(int value)
        {
            // arrange
            var tree = new Tree<int>(0);

            // act
            tree.AddChild(value);

            // answer
            tree.Children[0]
                .Value.Should().Be(value);
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        public void WhenAddChildToChild_ThenItShouldBeInChildChildrenArray(int value)
        {
            // arrange
            var tree = new Tree<int>(0);

            // act
            tree.AddChild(0).AddChild(value);

            // answer
            tree.Children[0]
                .Children[0]
                .Value.Should().Be(value);
        }
    }
}