using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using LogReaderService.DAL;
using LogReaderService.Models;
using System.Web;

namespace LogReaderService.DAL
{
    public class LogRepository
    {
        public List<Incident> incidents = new List<Incident>();

        public List<Incident> GetDataFromLogFile()
        {
            UpdateList();

            return incidents;
        }

        private void UpdateList()
        {
            //Live
            //string[] data = File.ReadAllLines(HttpRuntime.AppDomainAppPath + @"\bin\data\logfil.txt");
            //Testing
            string[] data = File.ReadAllLines(Environment.CurrentDirectory + @"\data\logfil.txt");

            foreach (string item in data)
            {
                string[] seperatedItem = SeperateString(item);
                Incident incident = new Incident(seperatedItem[0], seperatedItem[1], seperatedItem[2], seperatedItem[3], seperatedItem[4], seperatedItem[5], seperatedItem[6], seperatedItem[7], seperatedItem[8], seperatedItem[9], seperatedItem[10]);
                incidents.Add(incident);
            }
        }

        public string[] SeperateString(string input)
        {
            return input.Split('\t');
        }

        public List<Incident> SearchLogByName(string name)
        {
            UpdateList();
            List<Incident> SortedList = new List<Incident>();

            foreach(Incident incident in incidents)
            {
                if(incident.name == name)
                {
                    SortedList.Add(incident);
                }
            }
            return SortedList;
        }

        public List<Incident> SearchLogByID(string ID)
        {
            UpdateList();
            List<Incident> SortedList = new List<Incident>();

            foreach (Incident incident in incidents)
            {
                if (incident.ID == ID)
                {
                    SortedList.Add(incident);
                }
            }
            return SortedList;
        }
    }
}