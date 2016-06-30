using BurakWcfService.Air.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Air.Services
{
    public class AvailabilityFightListRequest : ServiceRequest
    {
        public string origin = "IST";
        public string destination = "AYT";
        public string date = "20160808";
        public int adult = 1;
        public int child = 0;
        public int inf = 0;
        public int ogr = 0;
        public int tsk = 0;
        public int yp = 0;
        public int sc = 0;
        public FlightDirection direction = FlightDirection.ONEWAY;
        public FlightTripType tripType = FlightTripType.DEP;
    }
}