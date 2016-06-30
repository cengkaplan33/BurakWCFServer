using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Air.Models
{
    public sealed class FlightDirection
    {
        private readonly String name;
        private readonly int value;

        public static readonly FlightDirection ONEWAY = new FlightDirection(1, "ONEWAY");
        public static readonly FlightDirection ROUNDTRIP = new FlightDirection(2, "ROUNDTRIP");
        public static readonly FlightDirection OPEN = new FlightDirection(3, "OPEN");
        public static readonly FlightDirection OPENJAW = new FlightDirection(4, "OPENJAW");

        private FlightDirection(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
    }

    //enum FlightDirection
    //{
    //    //Tek Yön
    //    ONEWAY = "ONEWAY",
    //    //Gidiş – Dönüş
    //    ROUNDTRIP = "ROUNDTRIP",
    //    //Gidiş-Dönüş Açık
    //    OPEN = "OPEN",
    //    //Gidiş-Dönüş Farklı Noktadan
    //    OPENJAW = "OPENJAW "
    //}
}