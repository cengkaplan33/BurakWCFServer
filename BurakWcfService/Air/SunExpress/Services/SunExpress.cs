using BurakWcfService.Air.Models;
using BurakWcfService.Air.Services;
using BurakWcfService.SunExpressServiceReference;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BurakWcfService.Air.SunExpress.Service
{
    [XmlRoot("Security", Namespace = "http://ota.paxws.otaxmlws/")]
    [XmlTypeAttribute("Security", Namespace = "http://ota.paxws.otaxmlws/")]
    public class SunExpressSoapHeader : SoapHeader, IXmlSerializable
    {

        public readonly string strxmlns = "xmlns";
        public readonly string strwsse = "wsse";
        public readonly string strwssensHeader = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        protected string strUsernameToken = "UsernameToken";
        public readonly string strwssens = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        private const string strType = "Type";
        private const string strPasswordText = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";


        #region
        //[System.SerializableAttribute()]
        //[System.Diagnostics.DebuggerStepThroughAttribute()]
        //[System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://types.paxws.otaxmlws/")]
        //public partial class UsernameToken 
        //{

        //    private string departureDateTimeField;

        //    private LocationType originLocationField;

        //    private LocationType destinationLocationField;

        //    /// <remarks/>
        //    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        //    public string DepartureDateTime
        //    {
        //        get
        //        {
        //            return this.departureDateTimeField;
        //        }
        //        set
        //        {
        //            this.departureDateTimeField = value;
        //            this.RaisePropertyChanged("DepartureDateTime");
        //        }
        //    }

        //    /// <remarks/>
        //    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        //    public LocationType OriginLocation
        //    {
        //        get
        //        {
        //            return this.originLocationField;
        //        }
        //        set
        //        {
        //            this.originLocationField = value;
        //            this.RaisePropertyChanged("OriginLocation");
        //        }
        //    }

        //    /// <remarks/>
        //    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        //    public LocationType DestinationLocation
        //    {
        //        get
        //        {
        //            return this.destinationLocationField;
        //        }
        //        set
        //        {
        //            this.destinationLocationField = value;
        //            this.RaisePropertyChanged("DestinationLocation");
        //        }
        //    }

        //    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        //    protected void RaisePropertyChanged(string propertyName)
        //    {
        //        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        //        if ((propertyChanged != null))
        //        {
        //            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        //        }
        //    }
        //}


        #endregion


        [XmlAttributeAttribute("Username", Namespace = "http://ota.paxws.otaxmlws/")]
        public string Username = "NUANSXML";

        [XmlAttributeAttribute("Password", Namespace = "http://ota.paxws.otaxmlws/")]
        public string Password = "AVWJ1E";

        [XmlAttributeAttribute("Content-Type")]
        private string ContentType = "application/soap+xml";

        [XmlAttributeAttribute("charset")]
        private string charset = "utf-8";

        public SunExpressSoapHeader()
        {
            Username = "NUANSXML";
            Password = "AVWJ1E";
        }

        public SunExpressSoapHeader(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {

        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {

            writer.WriteAttributeString(strxmlns, strwsse, null, strwssens);
            //writer.WriteAttributeString(strxmlns, strwssens);

            // <wsse:UsernameToken>
            writer.WriteStartElement(strwsse, strUsernameToken, strwssens);

            // <wsse:Username></wsse:Username>
            writer.WriteStartElement(strwsse, "Username", strwssens);
            writer.WriteString(this.Username);
            writer.WriteEndElement();

            // <wsse:Password Type="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"></wsse:Password>
            writer.WriteStartElement(strwsse, "Password", strwssens);
            //writer.WriteAttributeString(strType, strPasswordText);
            writer.WriteString(this.Password);
            writer.WriteEndElement();


            //writer.WriteStartElement(strwsse, "Content-Type");
            //writer.WriteString("application/soap+xml");
            //writer.WriteEndElement();

            //writer.WriteStartElement(strwsse, "charset");
            //writer.WriteString("utf-8");
            //writer.WriteEndElement();

            writer.WriteEndElement();

            //writer.WriteAttributeString("soap:Username", Username);
            //writer.WriteAttributeString("soap:Password", Password);
            //writer.WriteRaw("some encrypted data");
        }
    }


    /// <summary>
    /// This is a sample implementation of the SQL 2005 Security SOAP Header in the SOAP 1.1 format.
    /// This class inherites from SoapHeader as all SOAP Header classes need to do.  
    /// This class also implements the IXmlSerializable so the client can control the XML serialization format.
    /// This class is meant to be used as a SOAP header only.
    /// </summary>
    [XmlRoot("Header", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    public class Security : System.Web.Services.Protocols.SoapHeader, System.Xml.Serialization.IXmlSerializable
    {

        // private member variables to hold the user input values.
        private string WssePassword;
        private string WsseUsername;

        // the set of string const that is required for serialization.
        private const string strxmlns = "xmlns";
        private const string strsqlns = "http://schemas.microsoft.com/sqlserver/2004/SOAP";
        private const string strwssens = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        private const string strsql = "sql";
        private const string strwsse = "wsse";
        private const string strUsernameToken = "UsernameToken";
        private const string strUsername = "Username";
        private const string strPassword = "Password";
        private const string strType = "Type";
        private const string strPasswordText = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";

        public Security()
        {
            // setting default values
            this.WssePassword = null;
            this.WsseUsername = null;
        }

        // IXmlSerializable methods
        public XmlSchema GetSchema()
        {
            // Visual Studio .NET 2003 requires an ID value for the XmlSchema
            // This is the minimum implementation required for this method.
            // Note: this method is not really used anywhere.
            XmlSchema _xmlSchema = new XmlSchema();
            _xmlSchema.Id = "Sql 2005";
            return _xmlSchema;
        }

        public void ReadXml(XmlReader reader)
        {
            // not implemented
        }

        public void WriteXml(XmlWriter writer)
        {
            // The SOAP header serialization context to passed to this method after the class name element
            // node has been opened (ie. WriteStartElement("Security"))

            // Writing additional attributes to the "Security" element
            // xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"
            // xmlns="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"
            writer.WriteAttributeString(strxmlns, strwsse, null, strwssens);
            writer.WriteAttributeString(strxmlns, strwssens);

            // check for SOAP header specific attributes
            if (this.MustUnderstand)
            {
                writer.WriteAttributeString("mustUnderstand", "http://schemas.xmlsoap.org/soap/envelope/", this.EncodedMustUnderstand);
            }
            if ((null != this.Actor) && ("" != this.Actor))
            {
                writer.WriteAttributeString("actor", "http://schemas.xmlsoap.org/soap/envelope/", this.Actor);
            }

            // <wsse:UsernameToken>
            writer.WriteStartElement(strwsse, strUsernameToken, strwssens);

            // <wsse:Username></wsse:Username>
            writer.WriteStartElement(strwsse, strUsername, strwssens);
            if (null == this.WsseUsername)
                writer.WriteAttributeString("xsi", "nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
            else
                writer.WriteString(this.WsseUsername);
            writer.WriteEndElement();

            // <wsse:Password Type="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"></wsse:Password>
            writer.WriteStartElement(strwsse, strPassword, strwssens);
            writer.WriteAttributeString(strType, strPasswordText);
            if (null == this.WssePassword)
                writer.WriteAttributeString("xsi", "nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
            else
                writer.WriteString(this.WssePassword);
            writer.WriteEndElement();

            //</wsse:UsernameToken>
            writer.WriteEndElement();
        }

        // Property accessors
        public string Password
        {
            get
            {
                return this.WssePassword;
            }
            set
            {
                this.WssePassword = value;
            }
        }



        public string Username
        {
            get
            {
                return this.WsseUsername;
            }
            set
            {
                this.WsseUsername = value;
            }
        }
    }


    public class SunExpress : IAirService
    {
        //public SunExpressSoapHeader header;
        public SunExpressSoapHeader header;

        private string username = "NUANSXML";
        private string password = "AVWJ1E";
        


        public SunExpress(string Username, string Password)
        {
            Username = "NUANSXML";
            Password = "AVWJ1E";

            username = Username;
            password = Password;

            //header = new SunExpressSoapHeader(username,password);
            header = new SunExpressSoapHeader();
            header.Username = "NUANSXML";
            header.Password = "AVWJ1E";
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

        [SoapHeader("header", Direction = SoapHeaderDirection.InOut)]
        public AvailabilityFightListResponse AvailabilityFightList(AvailabilityFightListRequest request)
        {
            List<AvailabilityFight> flights = new List<AvailabilityFight>();

            AvailabilityFightListResponse response = new AvailabilityFightListResponse();


            //try
            //{

            //    var basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            //    basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            //    basicHttpBinding.SendTimeout = new System.TimeSpan(0, 5, 0);

            //    SunExpressCraneOTAServiceExtendedServiceReference.CraneOTAServiceExtendedPortTypeClient client = new SunExpressCraneOTAServiceExtendedServiceReference.CraneOTAServiceExtendedPortTypeClient(basicHttpBinding, new EndpointAddress("https://ota.sunexpress.com/axis2/services/CraneOTAServiceExtended?wsdl"));

            //    client.ClientCredentials.UserName.UserName = "NUANSXML";
            //    client.ClientCredentials.UserName.Password = "AVWJ1E";

            //    if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            //    {
            //        var res = client.Ping(new SunExpressCraneOTAServiceExtendedServiceReference.OTA_PingRQType() { SequenceNmbr = 1, TimeStamp = "1", EchoData = "this is a ping." });
            //    }
            //    else
            //    {
            //        client = new SunExpressCraneOTAServiceExtendedServiceReference.CraneOTAServiceExtendedPortTypeClient(basicHttpBinding, new EndpointAddress("https://ota.sunexpress.com/axis2/services/CraneOTAServiceExtended?wsdl"));
            //        client.ClientCredentials.UserName.UserName = "NUANSXML";
            //        client.ClientCredentials.UserName.Password = "AVWJ1E";

            //        var res = client.Ping(new SunExpressCraneOTAServiceExtendedServiceReference.OTA_PingRQType() { SequenceNmbr = 1, TimeStamp = "1", EchoData = "this is a ping." });

            //    }
            //}catch  ()
            //{
            //}

            try
            {
                //SunExpressXMLServiceReference.CraneOTAService cc = new SunExpressXMLServiceReference.CraneOTAService();

                //var res = cc.Ping(new SunExpressXMLServiceReference.OTA_PingRQType() {  });
                //cc.Availability(new SunExpressXMLServiceReference.OTA_AirAvailRQType()
                //    { 
                //        PrimaryLangID= "TR",
                //        POS= new SunExpressXMLServiceReference.POSType(),


                //        DirectFlightsOnly = true,
                //        OriginDestinationInformation = new SunExpressXMLServiceReference.OriginDestinationInformationType()
                //        {
                //            DepartureDateTime = "20160808",
                //            DestinationLocation = new SunExpressXMLServiceReference.LocationType() { LocationCode = "AYT" },
                //            OriginLocation = new SunExpressXMLServiceReference.LocationType() { LocationCode = "IST" }
                //        }
                //    });
                //header = new SunExpressSoapHeader(username, password);
                header = new SunExpressSoapHeader();
                header.Username = "NUANSXML";
                header.Password = "AVWJ1E";

                try
                {


                    //SunExpressServiceReference.CraneOTAServicePortTypeClient xc = new SunExpressServiceReference.CraneOTAServicePortTypeClient("CraneOTAServiceSOAP12port_http2");

                    //var basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
                    //basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

                    //xc.ClientCredentials.UserName.UserName = "NUANSXML";
                    //xc.ClientCredentials.UserName.Password = "AVWJ1E";


                    //xc.Ping(new SunExpressServiceReference.OTA_PingRQType() { SequenceNmbr = 1, TimeStamp = "1", EchoData = "this is a ping." });

                }
                catch (System.Exception)
                {

                }

                //SunExpressXMLServiceReference.CraneOTAService cc = new SunExpressXMLServiceReference.CraneOTAService();
                //var resp = cc.Ping(new SunExpressXMLServiceReference.OTA_PingRQType() { SequenceNmbr = 1, TimeStamp = "1", EchoData = "this is a ping." });
                var basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
                basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                basicHttpBinding.SendTimeout = new System.TimeSpan(0, 5, 0);

                //https://ota.sunexpress.com/axis2/services/CraneOTAServiceExtended?wsdl
                using (SunExpressServiceReference.CraneOTAServicePortTypeClient client = new SunExpressServiceReference.CraneOTAServicePortTypeClient(basicHttpBinding, new EndpointAddress("https://ota.sunexpress.com:80/axis2/services/CraneOTAService?wsdl")))
                {

                    client.ClientCredentials.UserName.UserName = "NUANSXML";
                    client.ClientCredentials.UserName.Password = "AVWJ1E";

                    ////header = new SunExpressSoapHeader(username, password);
                    //using (new OperationContextScope(client.InnerChannel))
                    //{
                    //    //// Add a HTTP Header to an outgoing request
                    //    //HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    //    //requestMessage.Headers["MyHttpHeader"] = header.ToString();
                    //    //OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                    //    var res = client.Ping(new SunExpressServiceReference.OTA_PingRQType() { });
                    //}


                    ////header = new SunExpressSoapHeader(username, password);
                    //using (new OperationContextScope(client.InnerChannel))
                    //{
                    //    //// Add a HTTP Header to an outgoing request
                    //    //HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    //    //requestMessage.Headers["MyHttpHeader"] = header.ToString();
                    //    //OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                    //    var res = client.Ping(new SunExpressServiceReference.OTA_PingRQType() { SequenceNmbr = 1, TimeStamp = "1", EchoData = "this is a ping." });
                    //}



                    using (new OperationContextScope(client.InnerChannel))
                    {


                        //// Add a HTTP Header to an outgoing request
                        HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                        requestMessage.Headers["Header"] = "Content-Type: text/xml; charset=utf-8"; // "Content-Type: application/soap+xml; charset = utf-8";

                        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                        MessageHeader aMessageHeader = MessageHeader.CreateHeader("wsse:Security", "", header);
                        OperationContext.Current.OutgoingMessageHeaders.Add(aMessageHeader);





                        var res = client.Ping(new SunExpressServiceReference.OTA_PingRQType() { SequenceNmbr = 1, TimeStamp = "1", EchoData = "this is a ping." });

                        //var res = client.Ping(new SunExpressServiceReference.OTA_PingRQType() { SequenceNmbr = 1, TimeStamp = "1", EchoData = "this is a ping." });
                    }

                    client.Close();
                }

                //using (SunExpressServiceReference.CraneOTAServicePortTypeClient client = new SunExpressServiceReference.CraneOTAServicePortTypeClient("CraneOTAServiceSOAP11port_http2"))
                //{

                //    header = new SunExpressSoapHeader(username, password);

                //    var res = client.Availability(new SunExpressServiceReference.OTA_AirAvailRQType()
                //    {
                //        DirectFlightsOnly = true,
                //        OriginDestinationInformation = new SunExpressServiceReference.OriginDestinationInformationType()
                //        {
                //            DepartureDateTime = "20160808",
                //            DestinationLocation = new LocationType() { LocationCode = "AYT" },
                //            OriginLocation = new LocationType() { LocationCode = "ESB" }
                //        }
                //    });
                //    //SunExpressServiceReference.AvailabilityData availabilityResponse = client.availabilityV3(request.username, request.password, request.lang, request.direction.ToString(), request.origin, request.destination, request.date, request.adult, request.child, request.inf, request.ogr, request.tsk, request.yp, request.sc, request.tripType.ToString());

                //    //if (availabilityResponse != null && availabilityResponse.flightData != null)
                //    //{

                //    //    if (availabilityResponse.flightData.Length > 1)
                //    //    {
                //    //        foreach (var flight in availabilityResponse.flightData)
                //    //        {
                //    //            flights.Add(new AvailabilityFight() { Message = flight.message, Voyagecode = flight.voyagecode });
                //    //        }
                //    //    }
                //    //    else
                //    //    {
                //    //        ///log yazıp geçeceğiz...
                //    //    }
                //    //    response.Entities = flights;
                //    //    response.TotalCount = flights.Count;
                //    //}

                //    client.Close();
                //}
            }
            catch (System.Exception)
            {

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