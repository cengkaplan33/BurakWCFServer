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



    public sealed class PassengerType
    {
        public readonly String Name;
        public readonly String Code;
        public readonly int Value;

        //ADT - Adult
        //INF - Infant without a Seat
        //Military - Asker
        //Student
        public static readonly PassengerType Adult = new PassengerType(1, "Adult", "ADL");
        public static readonly PassengerType Child = new PassengerType(2, "Child", "CHL");
        public static readonly PassengerType Infant = new PassengerType(3, "Infant", "INF");
        public static readonly PassengerType Young = new PassengerType(4, "Young", "YNG");
        public static readonly PassengerType Senior = new PassengerType(5, "Senior", "SRC");
        public static readonly PassengerType Student = new PassengerType(10, "Student", "STU");
        public static readonly PassengerType Military = new PassengerType(20, "Military", "MIL");

        private PassengerType(int value, String name, string code)
        {
            this.Name = name;
            this.Value = value;
            this.Code = code;
        }

        //public override String ToString()
        //{
        //    return name;
        //}
    }

    public sealed class FlightChargeType
    {
        private readonly String name;
        private readonly String code;
        private readonly int value;

        public static readonly FlightChargeType Tax = new FlightChargeType(1, "Tax", "Tax");
        public static readonly FlightChargeType Service = new FlightChargeType(2, "Service", "Service");

        private FlightChargeType(int value, String name, string code)
        {
            this.name = name;
            this.value = value;
            this.code = code;
        }
    }
}