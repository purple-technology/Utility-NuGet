using Microsoft.VisualStudio.TestTools.UnitTesting;
using PurpleTechnology.Common.Utils.IO;
using System;

namespace PurpleTechnology.Common.Utils.Tests.IO
{
    // TODO: Do a proper testing of FilePath class.
    public class FilePathTests
    {
        [TestClass]
        public class EqualsTests
        {
            [TestMethod]
            public void Equals1Test()
            {
                // Arrange
                var filePath = new FilePath(@"C:\Temp\Test.txt");
                object obj = null;

                // Act
                var result = filePath.Equals(
                    obj);

                // Assert
                Assert.Fail();
            }
        }

        [TestClass]
        public class Equals2Tests
        {
            [TestMethod]
            public void Equals3Test()
            {
                // Arrange
                var filePath = new FilePath(@"C:\Temp\Test.txt");
                FilePath other = null;

                // Act
                var result = filePath.Equals(
                    other);

                // Assert
                Assert.Fail();
            }
        }

        [TestClass]
        public class Equals4Tests
        {
            [TestMethod]
            public void Equals5Test()
            {
                // Arrange
                FilePath left = null;
                FilePath right = null;

                // Act
                var result = FilePath.Equals(
                    left,
                    right);

                // Assert
                Assert.Fail();
            }
        }

        [TestClass]
        public class GetHashCodeTests
        {
            [TestMethod]
            public void GetHashCode1Test()
            {
                // Arrange
                var filePath = new FilePath(@"C:\Temp\Test.txt");

                // Act
                var result = filePath.GetHashCode();

                // Assert
                Assert.Fail();
            }
        }
    }
}
