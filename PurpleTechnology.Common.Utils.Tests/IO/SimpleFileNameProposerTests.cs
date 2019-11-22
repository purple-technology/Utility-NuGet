using Microsoft.VisualStudio.TestTools.UnitTesting;
using PurpleTechnology.Common.Utils.IO;
using System;

namespace PurpleTechnology.Common.Utils.Tests.IO
{
    //TODO: Do a proper unit testing of SimpleFileNameProposer
    public class SimpleFileNameProposerTests
    {
        [TestClass]
        public class GenerateUniqueFileNameTests
        {
            [TestMethod]
            public void GenerateUniqueFileName1Test()
            {
                // Arrange

                // Act
                SimpleFileNameProposer.GenerateUniqueFileName(
                    absolutePath: null);

                // Assert
                Assert.Fail();
            }
        }

        [TestClass]
        public class GenerateUniqueFileName2Tests
        {
            [TestMethod]
            public void GenerateUniqueFileName3Test()
            {
                // Arrange

                // Act
                SimpleFileNameProposer.GenerateUniqueFileName(
                    filePath: null);

                // Assert
                Assert.Fail();
            }
        }

        [TestClass]
        public class GenerateUniqueAbsolutePathTests
        {
            [TestMethod]
            public void GenerateUniqueAbsolutePath1Test()
            {
                // Arrange

                // Act
                SimpleFileNameProposer.GenerateUniqueAbsolutePath(
                    absolutePath: null);

                // Assert
                Assert.Fail();
            }
        }

        [TestClass]
        public class GenerateUniqueAbsolutePath2Tests
        {
            [TestMethod]
            public void GenerateUniqueAbsolutePath3Test()
            {
                // Arrange

                // Act
                SimpleFileNameProposer.GenerateUniqueAbsolutePath(
                    filePath: null);

                // Assert
                Assert.Fail();
            }
        }
    }
}
