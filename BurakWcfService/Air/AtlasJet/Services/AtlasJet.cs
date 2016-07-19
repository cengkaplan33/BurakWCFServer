using BurakWcfService.Air.Models;
using BurakWcfService.Air.Services;
using System.Collections.Generic;

namespace BurakWcfService.Air.AtlasJet.Model
{
    public class PassengerQuantityModel
    {
        public int adult = 1;
        public int child = 0;
        public int inf = 0;
        public int ogr = 0;
        public int tsk = 0;
        public int yp = 0;
        public int sc = 0;
    }
}

namespace BurakWcfService.Air.AtlasJet.Service
{
    public class AtlasJet : IAirService
    {


        public class Common
        {
            //public static PassengerTypeQuantityType[] GetPassengerQuantities()
            //{
            //    List<PassengerTypeQuantityType> passengers = new List<PassengerTypeQuantityType>();
            //    passengers.Add(new PassengerTypeQuantityType
            //    {
            //        Code = "ADT",
            //        Quantity = 1,
            //        QuantitySpecified = true
            //    });
            //    passengers.Add(new PassengerTypeQuantityType
            //    {
            //        Code = "CHL",
            //        Quantity = 1,
            //        QuantitySpecified = true
            //    });
            //    //passengers.Add(new PassengerTypeQuantityType
            //    //{
            //    //    Code = "INF",
            //    //    Quantity = 1,
            //    //    QuantitySpecified = true
            //    //});
            //    return passengers.ToArray();
            //}

        }
        public AirportListResponse AirportList(AirportListRequest request)
        {
            AirportListResponse response = new AirportListResponse();





            return response;
        }

        public FareListResponse FareList(FareListRequest request)
        {
            FareListResponse response = new FareListResponse();





            return response;
        }

        public AvailabilityFightListResponse AvailabilityFightList(AvailabilityFightListRequest request)
        {
            //string username = "DEMO1", password = "123456", lang = "TR";
            //string username = "NUANSWEB", password = "NT1234", lang = "TR";

            List<AvailabilityFight> flights = new List<AvailabilityFight>();

            AvailabilityFightListResponse response = new AvailabilityFightListResponse();

            try
            {
                using (AtlasjetServiceReference.AtlasjetClient client = new AtlasjetServiceReference.AtlasjetClient())
                {
                    AtlasjetServiceReference.AvailabilityData availabilityResponse = client.availabilityV3(request.username, request.password, request.lang, request.direction.ToString(), request.origin, request.destination, request.departureDate.ToString("2016-08-20"), request.PTCsAdult, request.PTCsChildren, request.PTCsInfant, request.PTCsStudent, request.PTCsMilitary , request.PTCsYoung, request.PTCsSenior, request.tripType.ToString());

                    if (availabilityResponse != null && availabilityResponse.flightData != null)
                    {
                        //TODO OK::NOT:: List kaldırılabilir çünkü sadece bir bilgi ve o bilgi içinde kayıtlar var.  veya  AvailabilityFight yerine  FlightRoute eklenebilir şimdilik karışmıyorum.
                        response.Entities = new List<AvailabilityFight>() { };

                        if (availabilityResponse.flightData.Length > 1)
                        {
                            foreach (var flight in availabilityResponse.flightData)
                            {
                                flights.Add(new AvailabilityFight() { Message = flight.message, Voyagecode = flight.voyagecode });
                            }
                        }
                        else
                        {
                            ///log yazıp geçeceğiz...
                        }
                        response.Entities = flights;
                        response.TotalCount = flights.Count;
                    }

                    client.Close();
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            return response;
        }

        public BookingRetrieveResponse Booking(BookingRetrieveRequest request)
        {
            BookingRetrieveResponse response = new BookingRetrieveResponse();




            return response;
        }
    }
}
