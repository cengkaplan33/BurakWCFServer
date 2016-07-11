using BurakWcfService.Air.Models;
using BurakWcfService.Air.Services;
using BurakWcfService.PegasusCraneOTAService;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BurakWcfService.Air.Pegasus.Service
{

    public class Common
    {
        public static class ConfigureBinding
        {
            public static void SetTimeOut(Binding binding, double milliseconds)
            {
                milliseconds = 20000;
                System.TimeSpan timeOut = System.TimeSpan.FromMilliseconds(milliseconds);
                binding.OpenTimeout = timeOut;
                binding.CloseTimeout = timeOut;
                binding.SendTimeout = timeOut;
                binding.ReceiveTimeout = timeOut;
            }
        }

        public static CraneOTAServiceV21PortTypeClient GetClient()
        {
            AddWseSecurityHeaderEndpointBehavior customEndpointBehavior = new AddWseSecurityHeaderEndpointBehavior("T286AC56", "C6PW2F");
            return new CraneOTAServiceV21PortTypeClient("CraneOTAServiceV21SOAP11port_http", new EndpointAddress("https://b2b.flypgs.com/axis2/services/CraneOTAServiceV21"))
            {
                Endpoint =
                {
                    Behaviors = 
					{
						customEndpointBehavior
					}
                }
            };
        }

        public static PassengerTypeQuantityType[] GetPassengerQuantities()
        {
            List<PassengerTypeQuantityType> passengers = new List<PassengerTypeQuantityType>();
            passengers.Add(new PassengerTypeQuantityType
            {
                Code = "ADT",
                Quantity = 1,
                QuantitySpecified = true
            });
            passengers.Add(new PassengerTypeQuantityType
            {
                Code = "CHL",
                Quantity = 1,
                QuantitySpecified = true
            });
            //passengers.Add(new PassengerTypeQuantityType
            //{
            //    Code = "INF",
            //    Quantity = 1,
            //    QuantitySpecified = true
            //});
            return passengers.ToArray();
        }

        public static POSType GetPOSType()
        {
            return new POSType
            {
                Source = new SourceType
                {
                    agentSine = "1",
                    isoCountry = "TR",
                    isoCurrency = "TRY",
                    RequestorID = new RequestorIDType
                    {
                        id = "1",
                        type = "1",
                        url = "http://"
                    },
                    BookingChannel = new BookingChannelType
                    {
                        Primary = 1,
                        Type = 1,
                        PrimarySpecified = true,
                        TypeSpecified = true
                    }
                }
            };
        }
    }

    public class AddWseSecurityHeaderEndpointBehavior : IEndpointBehavior
    {
        private readonly string userName;
        private readonly string password;
        public AddWseSecurityHeaderEndpointBehavior(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            AddWseSecurityHeaderMessageInspector inspector = new AddWseSecurityHeaderMessageInspector(this.userName, this.password);
            clientRuntime.MessageInspectors.Add(inspector);
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }

    internal class AddWseSecurityHeaderMessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        private readonly string userName;
        private readonly string password;
        public AddWseSecurityHeaderMessageInspector(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            CustomWseSecurityHeader securityHeader = new CustomWseSecurityHeader(this.userName, this.password);
            request.Headers.Add(securityHeader);
            return request;
        }
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }

    internal class CustomWseSecurityHeader : MessageHeader
    {
        private readonly string userName;
        private readonly string password;
        public override string Name
        {
            get
            {
                return "Security";
            }
        }
        public override string Namespace
        {
            get
            {
                return "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
            }
        }
        public override bool MustUnderstand
        {
            get
            {
                return false;
            }
        }

        public CustomWseSecurityHeader(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            writer.WriteStartElement("UsernameToken", this.Namespace);
            writer.WriteElementString("Username", this.Namespace, this.userName);
            writer.WriteElementString("Password", this.Namespace, this.password);
            writer.WriteEndElement();
        }
    }


    public class Pegasus : IAirService
    {
        private string username = "NUANSXML";
        private string password = "AVWJ1E";

        public Pegasus(string Username, string Password)
        {
            Username = "NUANSXML";
            Password = "AVWJ1E";

            username = Username;
            password = Password;

            //header = new PegasusSoapHeader(username,password);
            //header = new PegasusSoapHeader();
            //header.Username = "NUANSXML";
            //header.Password = "AVWJ1E";
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


            try
            {


                var cRequest = new List<OTA_AirAvailAndFaresRQType>
	{
		new OTA_AirAvailAndFaresRQType
		{
			SequenceNmbr = 1,
			SequenceNmbrSpecified = true,
			PrimaryLangID = "1",
			DirectFlightsOnly = true,
			DirectFlightsOnlySpecified = true,
			POS = Common.GetPOSType(),
			TravelerInfoSummary = new TravelerInfoSummaryType
			{
				AirTravelerAvail = new AirTravelerAvailType
				{
					PassengerTypeQuantity = Common.GetPassengerQuantities(),
					temp = "temp"
				}
			},
			OriginDestinationInformation = new OriginDestinationInformationType
			{
				OriginLocation = new LocationType
				{
					LocationCode = "ADA"
				},
				DestinationLocation = new LocationType
				{
					LocationCode = "SAW"
				},
				DepartureDateTime = "2016-08-10"
			}
		}
	};

                using (CraneOTAServiceV21PortTypeClient client = Common.GetClient())
                {
                    using (List<OTA_AirAvailAndFaresRQType>.Enumerator enumerator = cRequest.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            try
                            {

                                Common.ConfigureBinding.SetTimeOut(client.Endpoint.Binding, 20000);

                                var cResponse = client.AvailabilityAndFares(enumerator.Current);
                                if (cResponse.Success)
                                {
                                    var ccc = cResponse;
                                }
                                else
                                {

                                }
                            }
                            catch (System.Exception)
                            {

                            }

                            return response;
                        }
                    }
                }
            }
            catch
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