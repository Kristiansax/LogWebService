using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogReaderService.Controllers;
using LogReaderService.DAL;
using LogReaderService.Models;
using System.Collections.Generic;

namespace LogReaderServiceTests
{
    [TestClass]
    public class LogReaderTests
    {
        LogController TestController = new LogController();
        LogRepository TestRepository = new LogRepository();

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
            string[] seperatedTestString = TestRepository.SeperateString(testString);

            Assert.AreEqual("Test1", seperatedTestString[0]);
            Assert.AreEqual("Test2", seperatedTestString[1]);
        }

        [TestMethod]
        public void CanGetDataFromFile()
        {
            List<Incident> TestList = new List<Incident>();
            TestList = TestRepository.GetDataFromLogFile();
            

            Assert.AreEqual("29-10-2015 11:45", TestList[1].time);
            Assert.AreEqual("32159", TestList[1].ID);
            Assert.AreEqual("D�r �bnet", TestList[1].alarm);
            Assert.AreEqual("Trappet�rn", TestList[1].name);
            Assert.AreEqual("Demovej 2", TestList[1].department);
            Assert.AreEqual("D�r C", TestList[1].residence);
            Assert.AreEqual("29-10-2015 11:45", TestList[1].resetTime);
        }

        [TestMethod]
        public void CanGetNamesFromLog()
        {
            List<Incident> TestList = new List<Incident>();
            TestList = TestRepository.SearchLogByName("Else");

            Assert.AreEqual("Else", TestList[1].name);
            Assert.AreEqual("Else", TestList[2].name);
        }

        [TestMethod]
        public void CanGetIDsFromLog()
        {
            List<Incident> TestList = new List<Incident>();
            TestList = TestRepository.SearchLogByID("32137");

            Assert.AreEqual("32137", TestList[1].ID);
            Assert.AreEqual("32137", TestList[2].ID);
        }
    }
}
