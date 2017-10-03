using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogReaderService.Models
{
    public class Incident
    {
        public string time { get; set; }
        public string ID { get; set; }
        public string alarm { get; set; }
        public string name { get; set; }
        public string afdeling { get; set; }
        public string residence { get; set; }
        public string location { get; set; }
        public string resettime { get; set; }
        public string personnel { get; set; }
        public string callto { get; set; }
        public string groupcall { get; set; }
    }
}