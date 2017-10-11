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

namespace LogReaderService.Controllers
{
    public class LogController : ApiController
    {
        public LogRepository logRep = new LogRepository();

        [HttpGet]
        [ActionName("GetLog")]
        public List<Incident> GetAllFromLog ()
        {
            return logRep.GetDataFromLogFile();
        }

        [HttpGet]
        [ActionName("GetIncidentsByName")]
        public List<Incident> GetNames (string name)
        {
            return logRep.SearchLogByName(name);
        }

        [HttpPut]
        [ActionName("PlaceholderName")]
        public void Put()
        {
            //Skal kunne opdatere
        }

        [HttpPost]
        [ActionName("PlaceholderName2")]
        public void Post()
        {
            //Oprette en ny log
        }

        [HttpDelete]
        [ActionName("PlaceholderName3")]
        public void Delete()
        {
            //Slet en log/slet en linje fra loggen
        }
    }
}

