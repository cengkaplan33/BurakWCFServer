using BurakWcfService.Air.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Air.Services
{
    //tsk, genç, 65 yaş üstü vs için ayar yapılabilir ama her firma bu desteği sağlamadığı için (sadece atlas global) diğer firmalara kendi içinde  TSK, genç var ise adult a ekler :) 
    public class AvailabilityFightListRequest : ServiceRequest
    {
        public string origin = "IST";
        public string destination = "AYT";
        public DateTime departureDate = new DateTime(2016, 08, 08);

        //pasenger bilgisini kolay olsun diye PTCs olarak ekledim.
        public Dictionary<string, int> passengers = new Dictionary<string, int>();

        public int PTCsAdult = 1;
        public int PTCsChildren=1;
        public int PTCsInfant=1;
        public int PTCsYoung=0;
        public int PTCsSenior=1;
        public int PTCsStudent=0;
        public int PTCsMilitary=0;


        public FlightDirection direction = FlightDirection.ONEWAY;
        public FlightTripType tripType = FlightTripType.DEP;
        public bool directFlightsOnly = true;
    }
}