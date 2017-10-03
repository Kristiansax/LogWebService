using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogReaderService.Controllers;
using LogReaderService.DAL;
using LogReaderService.Models;

namespace LogReaderServiceTests
{
    [TestClass]
    public class LogReaderTests
    {
        LogController TestController = new LogController();

        [TestMethod]
        public void LogFileExists()
        {
            string startUpPath = Directory.GetCurrentDirectory();
            Assert.IsTrue(File.Exists(startUpPath + @"\Data\logfil.txt"));
        }

        [TestMethod]
        public void CanSeperateString()
        {
            string testString = "Test1\tTest2";
            string[] seperatedTestString = TestController.SeperateString(testString);

            Assert.AreEqual("Test1", seperatedTestString[0]);
            Assert.AreEqual("Test2", seperatedTestString[1]);
        }
    }
}
