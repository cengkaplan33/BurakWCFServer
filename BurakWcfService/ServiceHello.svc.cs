using BurakWcfService.Air.AtlasJet.Service;
using BurakWcfService.Air.Models;
using BurakWcfService.Air.SunExpress.Service;
using BurakWcfService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BurakWcfService
{
    public class UserCredentials : System.Web.Services.Protocols.SoapHeader
    {
        public string userName;
        public string password;
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceHello" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceHello.svc or ServiceHello.svc.cs at the Solution Explorer and start debugging.
    public class ServiceHello : IServiceHello
    {
        public string HelloWorld()
        {
            string username = "DEMO1", password = "123456", lang = "TR";
            //string username = "NUANSWEB", password = "NT1234", lang = "TR";

            List<Airport> airports = new List<Airport>();
            List<Flight> flights = new List<Flight>();
            string list = "";


            #region OnurAir servis çağrısı denemesi

            //OnurAirCraneOTAService.CraneOTAServicePortTypeClient cl = new OnurAirCraneOTAService.CraneOTAServicePortTypeClient();



            //cl.Availability(new OnurAirCraneOTAService.OTA_AirAvailRQType() { DirectFlightsOnly = true });
            ////  cl.Open();
            ////var ss  = cl.ClientCredentials ; 

            #endregion

            #region Atlasjet servis çağrısı denemesi
            //AtlasJet servislerinde IP kontrolü yok.
            //AtlasjetServiceReference.AtlasjetClient client = new AtlasjetServiceReference.AtlasjetClient();

            //{

            //var airportResponse = client.airportsList(username, password, lang);

            //if (airportResponse != null)
            //{
            //    if (airportResponse.Count() > 1)
            //    {
            //        foreach (var airport in airportResponse)
            //        {
            //            airports.Add(new Airport(airport.code, airport.name));
            //            list += airport.code + " " + airport.name + " - ";
            //        }
            //    }
            //    else
            //    {
            //        ///log yazıp geçeceğiz...
            //    }
            //}
            //client.Close();

            //}
            //{
            //var airportResponse = client.toAirportsList("SAW",username, password, lang);

            //if (airportResponse != null)
            //{
            //    if (airportResponse.Count() > 1)
            //    {
            //        foreach (var airport in airportResponse)
            //        {
            //            airports.Add(new Airport(airport.code, airport.name));
            //            list += airport.code + " " + airport.name + " - ";
            //        }
            //    }
            //    else
            //    {
            //        ///log yazıp geçeceğiz...
            //    }
            //}
            //client.Close();
            //}
            //{

            //    string origin = "IST", destination = "AYT", date = "20160808";
            //    int adult = 1, child = 0, inf = 0, ogr = 0, tsk = 0, yp = 0, sc = 0;
            //    FlightDirection direction = FlightDirection .ONEWAY;

            //    AtlasjetServiceReference.AvailabilityData availabilityResponse = client.availability(username, password, lang, direction.ToString(), origin, destination, date, adult, child, inf, ogr, tsk, yp, sc);

            //    if (availabilityResponse != null && availabilityResponse.flightData != null)
            //    {

            //        if (availabilityResponse.flightData.Count() > 1)
            //        {
            //            foreach (var flight in availabilityResponse.flightData)
            //            {
            //                flights.Add(new Flight() { Message = flight.message, Voyagecode = flight.voyagecode });
            //                list += flight.message + " " + flight.voyagecode + " - ";
            //            }
            //        }
            //        else
            //        {
            //            ///log yazıp geçeceğiz...
            //        }

            //        return "Hello World - " + list;
            //    }
            //    client.Close();

            //}

            #region direk olarak çağrım
            //{

            //string origin = "IST", destination = "AYT", date = "20160808";
            //int adult = 1, child = 0, inf = 0, ogr = 0, tsk = 0, yp = 0, sc = 0;
            //FlightDirection direction = FlightDirection.ONEWAY;
            //FlightTripType tripType = FlightTripType.DEP;

            //AtlasjetServiceReference.AvailabilityData availabilityResponse = client.availabilityV3(username, password, lang, direction.ToString(), origin, destination, date, adult, child, inf, ogr, tsk, yp, sc, tripType.ToString());

            //if (availabilityResponse != null && availabilityResponse.flightData != null)
            //{

            //    if (availabilityResponse.flightData.Count() > 1)
            //    {
            //        foreach (var flight in availabilityResponse.flightData)
            //        {
            //            flights.Add(new Flight() { Message = flight.message, Voyagecode = flight.voyagecode });
            //            list += flight.message + " " + flight.voyagecode + " - ";
            //        }
            //    }
            //    else
            //    {
            //        ///log yazıp geçeceğiz...
            //    }

            //    return "Hello World - " + list;
            //}
            //client.Close();

            //}
            #endregion //direk olarak çağrım

            #region layer olarak çağrım
            {

                //AtlasJet atlasjet = new AtlasJet();
                //var response = atlasjet.AvailabilityFightList(new Air.Services.AvailabilityFightListRequest() { });
                //if (response.Error == null)
                //{
                //    foreach (var flight in response.Entities)
                //    {
                //        list += flight.Message + " " + flight.Voyagecode + " - ";
                //    }
                //}
                //else
                //{
                //    ///log yazıp geçeceğiz...
                //}

                //return "Hello World - " + list;
            }
            #endregion //layer olarak çağrım


            #endregion

            #region Borajet
            //System.ServiceModel.Description.ClientCredentials cr = new System.ServiceModel.Description.ClientCredentials();
            ////cr.UserName = "Demo"

            //BoraJetServiceReference.CraneOTAServicePortTypeClient cl = new BoraJetServiceReference.CraneOTAServicePortTypeClient("CraneOTAServiceSOAP11port_http1");
            ////cl.ClientCredentials
            //var s = cl.Availability(new BoraJetServiceReference.OTA_AirAvailRQType() { DirectFlightsOnly = true });

            ////UsernameToken token = new UsernameToken("user", "pwd", PasswordOption.SendPlainText);
            ////yourProxy.RequestSoapContext.Security.Tokens.Add(token);

            #endregion Borajet



            #region SunExpress

            #region layer olarak çağrım
            {

                SunExpress atlasjet = new SunExpress("","");
                
                var response = atlasjet.AvailabilityFightList(new Air.Services.AvailabilityFightListRequest() { });
                //if (response.Error == null)
                //{
                //    foreach (var flight in response.Entities)
                //    {
                //        list += flight.Message + " " + flight.Voyagecode + " - ";
                //    }
                //}
                //else
                //{
                //    ///log yazıp geçeceğiz...
                //}

                return "Hello World - " + list;
            }
            #endregion layer olarak çağrım

            #endregion SunExpress


            return "Hello World - " + list;
        }
    }
}