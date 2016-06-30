using BurakWcfService.Air.Models;
using BurakWcfService.Air.Services;
using System.Collections.Generic;

namespace BurakWcfService.Air.AtlasJet.Service
{
    public class AtlasJet : IAirService
    {
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
                    AtlasjetServiceReference.AvailabilityData availabilityResponse = client.availabilityV3(request.username, request.password, request.lang, request.direction.ToString(), request.origin, request.destination, request.date, request.adult, request.child, request.inf, request.ogr, request.tsk, request.yp, request.sc, request.tripType.ToString());

                    if (availabilityResponse != null && availabilityResponse.flightData != null)
                    {

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
