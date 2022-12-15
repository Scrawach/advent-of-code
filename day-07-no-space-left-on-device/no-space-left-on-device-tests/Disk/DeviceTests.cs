using FluentAssertions;
using Moq;
using no_space_left_on_device_src.Disk;
using no_space_left_on_device_src.Disk.Abstract;
using NUnit.Framework;

namespace no_space_left_on_device_tests.Disk
{
    public class DeviceTests
    {
        [TestCase("a")]
        [TestCase("ab")]
        [TestCase("bdwe")]
        [TestCase("42")]
        public void WhenCreateDirectory_ThenShouldAddChildInRoot(string directoryName)
        {
            // arrange
            var mockedRoot = new Mock<ITree<IDirectory>>();
            var device = new Device(mockedRoot.Object);

            // act
            device.CreateDirectory(directoryName);

            // answer
            mockedRoot.Verify(mock => mock.AddChild(It.Is<IDirectory>(dir => dir.Name == directoryName)));
            mockedRoot.VerifyNoOtherCalls();
        }

        [TestCase(10)]
        [TestCase(205)]
        [TestCase(584)]
        [TestCase(42)]
        public void WhenCreateFile_ThenShouldRecalculateSize_InParentDirectory(int expectedRootSize)
        {
            // arrange
            var root = new Tree<IDirectory>(new Directory("/"));
            var device = new Device(root);

            // act
            device.CreateFile(expectedRootSize);
            
            // answer
            root.Value.Size.Should().Be(expectedRootSize);
        }

        [TestCase(10)]
        [TestCase(205)]
        [TestCase(584)]
        [TestCase(42)]
        public void WhenCreateFile_ThenShouldRecalculate_AllParentsDirectoriesSize(int expectedRootSize)
        {
            // arrange
            var root = new Tree<IDirectory>(new Directory("/"));
            var folder = root.AddChild(new Directory("a"));
            var nextFolder = folder.AddChild(new Directory("b"));
            var device = new Device(nextFolder);

            // act
            device.CreateFile(expectedRootSize);
            
            // answer
            root.Value.Size.Should().Be(expectedRootSize);
        }
    }
}