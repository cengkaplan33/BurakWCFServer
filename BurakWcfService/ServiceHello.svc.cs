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
            List<Airport> airports = new List<Airport>();
            string list = "";



            OnurAirCraneOTAService.CraneOTAServicePortTypeClient cl = new OnurAirCraneOTAService.CraneOTAServicePortTypeClient();
            
            

            cl.Availability(new OnurAirCraneOTAService.OTA_AirAvailRQType() { DirectFlightsOnly = true });
            //  cl.Open();
            //var ss  = cl.ClientCredentials ; 



            #region Atlasjet servis çağrısı denemesi

            ////AtlasJet servislerinde IP kontrolü yok.
            //AtlasjetServiceReference.AtlasjetClient client = new AtlasjetServiceReference.AtlasjetClient();
            ////var airportResponse = client.airportsList("NUANSWEB", "NT1234", "TR");
            //var airportResponse = client.airportsList("DEMO1", "123456", "TR");

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

            #endregion

#region Borajet
            //System.ServiceModel.Description.ClientCredentials cr = new System.ServiceModel.Description.ClientCredentials();
            //cr.UserName = "Demo"

            //BoraJetServiceReference.CraneOTAServicePortTypeClient cl = new BoraJetServiceReference.CraneOTAServicePortTypeClient("CraneOTAServiceSOAP11port_http1");
            //cl.ClientCredentials
            //var s = cl.Availability(new BoraJetServiceReference.OTA_AirAvailRQType() { DirectFlightsOnly = true });

            //UsernameToken token = new UsernameToken("user", "pwd", PasswordOption.SendPlainText);
            //yourProxy.RequestSoapContext.Security.Tokens.Add(token);

            #endregion Borajet

            return "Hello World - " + list;
        }
    }
}
