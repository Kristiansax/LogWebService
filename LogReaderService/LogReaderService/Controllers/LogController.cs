using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using LogReaderService.DAL;
using LogReaderService.Models;

namespace LogReaderService.Controllers
{

    public class LogController : ApiController
    {
        LogRepository logRep = new LogRepository();

        [HttpGet]
        [ActionName("something something darkside")]
        public void GetDataFromLogFile(string filepath)
        {
            filepath = Directory.GetCurrentDirectory();
            string[] data = File.ReadAllLines(filepath + @"\data\logfil.txt");
            

            foreach (string item in data)
            {
                string[] seperatedItem = SeperateString(item);
                Incident incident = new Incident(seperatedItem[0], seperatedItem[1], seperatedItem[2], seperatedItem[3], seperatedItem[4], seperatedItem[5], seperatedItem[6], seperatedItem[7], seperatedItem[8], seperatedItem[9], seperatedItem[10]);
                logRep.incidents.Add(incident);

            }
        }

        public string[] SeperateString(string input)
        {
            return input.Split('\t');
        }
    }
}

