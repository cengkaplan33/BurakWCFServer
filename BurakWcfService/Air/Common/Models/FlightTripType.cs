using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Air.Models
{

    public sealed class FlightTripType
    {
        private readonly String name;
        private readonly int value;

        public static readonly FlightTripType DEP = new FlightTripType(1, "DEP");
        public static readonly FlightTripType RET = new FlightTripType(2, "RET");

        private FlightTripType(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
    }
    ////Availability tipi (Gidiş için : “DEP”,Dönüş için “RET” kodları gönderilmelidir.)
    //enum FlightTripType
    //{
    //    //DEP  = departure
    //    DEP = "DEP",
    //    //Dönüş
    //    RET = "RET",
    //}
}