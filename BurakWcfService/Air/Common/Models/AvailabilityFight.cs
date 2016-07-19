using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Air.Models
{
    public class AvailabilityFight
    {
        public AvailabilityFight()
        { }


        public string Voyagecode;
        public string Message;

        ////public string Flightno;
        //public string Depcode;
        //public string Depdesc;
        //public string Deptime; //()  19:00
        //public string Arrcode;
        //public string Arrdesc;
        //public string Arrtime; //()  20:05

        //public string Completeclass;
        //public string Cabinclass;
        //public string Classdesc;
        //public Int16 Seat;
        //public Double Viewprice;
        //public string Adultprice;
        //public string Childprice;
        //public string Infprice;
        //public string Ogrprice;
        //public string Tskprice;
        //public string Ypprice;
        //public string Scprice;
        //public string Currency;
        //public string Rulelink;

        public List<FlightRoute> FlightRoutes;
    }


    public class FlightRoute
    {

        public FlightRoute()
        {
            Flights = new List<Flight>();
        }

        public bool IsDirectFlight
        {
            get
            {
                return Flights.Count == 1;
            }
        }

        public List<Flight> Flights;
        public Flight CheapestFlight;
    }
}