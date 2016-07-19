using BurakWcfService.Air.Models;
using BurakWcfService.Air.Services;
using BurakWcfService.PegasusCraneOTAService;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Linq;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using Trevoo.Accounts.Providers.Model;
//using Trevoo.Air.Pgs.PGSWS;
//using Trevoo.Definitions;
//using Trevoo.Entities.Air;
//using Trevoo.Entities.Common;
//using Trevoo.Threading;

//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using Trevoo.Accounts.Providers.Model;
//using Trevoo.Air.Pgs.PGSWS;
//using Trevoo.Definitions;
//using Trevoo.Entities.Air;
//using Trevoo.Entities.Common;
//using Trevoo.Threading;

namespace BurakWcfService.Air.Pegasus.Service
{
    public class AvailabilityHelper
    {
        //public ProviderModel ProviderModel
        //{
        //    get;
        //    set;
        //}

        //public AvailabilityHelper(ProviderModel providerModel)
        //{
        //    this.ProviderModel = providerModel;
        //}

        public PassengerTypeQuantityType[] GetPassengerQuantities(AvailabilityFightListRequest request)
        {
            List<PassengerTypeQuantityType> passengers = new List<PassengerTypeQuantityType>();

            //pegasus ta adult child ve Infant var , military senior young falan hepsi Adult'a eklenmeli

            if (request.PTCsAdult > 0 || request.PTCsYoung > 0 || request.PTCsStudent > 0 || request.PTCsSenior > 0 || request.PTCsMilitary > 0)
            {
                passengers.Add(new PassengerTypeQuantityType
                {
                    Code = PassengerType.Adult.Code,
                    Quantity = request.PTCsAdult + request.PTCsYoung + request.PTCsStudent + request.PTCsSenior + request.PTCsMilitary,
                    QuantitySpecified = true
                });
            }

            if (request.PTCsChildren > 0)
            {
                passengers.Add(new PassengerTypeQuantityType
                {
                    Code = PassengerType.Child.Code,
                    Quantity = request.PTCsChildren,
                    QuantitySpecified = true
                });
            }

            if (request.PTCsInfant > 0)
            {
                passengers.Add(new PassengerTypeQuantityType
                {
                    Code = PassengerType.Infant.Code,
                    Quantity = request.PTCsInfant,
                    QuantitySpecified = true
                });
            }

            return passengers.ToArray();
        }

        public List<OTA_AirAvailAndFaresRQType> CreateAvailabilityRequests(AvailabilityFightListRequest request)
        {
            //airport listesi elimizde olsaydı metadata gibi linq ile sorgu atabilirdik. veya db den soracağız. hava alanı listesini istek oluştururken static bir şekildede oluşturabiliriz.
            //query.IntendedSegments.First<AirQuery_Segment>().Destination;
            //buarada biz metadatadan arama yaparken sadece Airport Code üzerinden sorgu atıp diğer bilgileri oradan bulacağız ben şimdilik elle salladım. 

            Airport departure = new Airport(request.origin, request.origin, "TR");
            Airport arrival = new Airport(request.destination, request.destination, "TR");

            string[] origins = new string[]
			{
				departure.Code
			};

            //IsCity deki amaç istanbuldan ankaraya uçacak ve istanbulda 2 ankarada 3 hava alanı var. kullanıcı ayrım yapmadan sorgulama yapmak istiyor. yani SAW (sabiha) veya burada amaç
            if (departure.IsCity && Common.CityAirports.ContainsKey(departure.Code))
            {
                origins = Common.CityAirports[departure.Code];
            }
            string[] destinations = new string[]
			{
				arrival.Code
			};
            if (arrival.IsCity && Common.CityAirports.ContainsKey(arrival.Code))
            {
                destinations = Common.CityAirports[arrival.Code];
            }

            return new List<OTA_AirAvailAndFaresRQType>
			{
				new OTA_AirAvailAndFaresRQType
				{
					SequenceNmbr = 1,
					SequenceNmbrSpecified = true,
					PrimaryLangID = "1",
					DirectFlightsOnly = request.directFlightsOnly,
					DirectFlightsOnlySpecified = true,

					POS = Common.GetPOSType(),
					TravelerInfoSummary = new TravelerInfoSummaryType
					{
						AirTravelerAvail = new AirTravelerAvailType
						{
							PassengerTypeQuantity = this.GetPassengerQuantities(request),
							temp = "temp"
						}
					},

					OriginDestinationInformation = new OriginDestinationInformationType
					{
						OriginLocation = new LocationType
						{
							LocationCode = origins.First<string>()
						},
						DestinationLocation = new LocationType
						{
							LocationCode = destinations.First<string>()
						},
						DepartureDateTime =  request.date.ToString("yyyy-MM-dd")
					}
				}
			};
        }

        public OTA_AirAvailAndFaresRQType CreateAvailabilityRequestForRoundtrip(AvailabilityFightListRequest request, string origin, string destination)
        {
            return new OTA_AirAvailAndFaresRQType
            {
                SequenceNmbr = 1,
                SequenceNmbrSpecified = true,
                PrimaryLangID = "1",
                DirectFlightsOnly = request.directFlightsOnly,
                DirectFlightsOnlySpecified = true,
                POS = Common.GetPOSType(),
                TravelerInfoSummary = new TravelerInfoSummaryType
                {
                    AirTravelerAvail = new AirTravelerAvailType
                    {
                        PassengerTypeQuantity = this.GetPassengerQuantities(request),
                        temp = "temp"
                    }
                },
                OriginDestinationInformation = new OriginDestinationInformationType
                {
                    OriginLocation = new LocationType
                    {
                        LocationCode = origin
                    },
                    DestinationLocation = new LocationType
                    {
                        LocationCode = destination
                    },
                    DepartureDateTime = request.date.ToString("yyyy-MM-dd")
                },
                ReturnOriginDestinationInformation = new ReturnOriginDestinationInformation
                {
                    ReturnDateTime = request.date.ToString("yyyy-MM-dd")
                }
            };
        }
            //    var google_tag_params = {
            //    flight_originid : 'IST', 
            //    flight_destid : 'JFK', 
            //    flight_startdate : '2016-07-12', 
            //    flight_enddate : '2016-07-19', 
            //    flight_pagetype : 'availabilityInt'
            //};
        public AvailabilityFightListResponse ParseAvailabilityResults(AvailabilityFightListRequest request, OTA_AirAvailAndFaresRSType response)
        {

            //TODO : : OK::NOT:: bu iki bilgi requestin içine eklenebilir requet içinde code değilde airport eklenebilir bu sayede. bir ön mekenazima yapılıp onun istekleri yapmadan önce ilgili düzenlemeleri yapması istenebiir :)
            Airport departure = new Airport(request.origin, request.origin, "TR");
            Airport arrival = new Airport(request.destination, request.destination, "TR");

            AvailabilityFightListResponse formedResponse = new AvailabilityFightListResponse();

            if (response.Success && response.OriginDestinationOptionsExt.OriginDestinationOptionExt.Length > 0)
            {
                bool isDomestic = FlightHelper.FlightHelpers.IsFlightInTurkeyOrECN(departure, arrival);

                //string[] promoClasses = new string[0];
                if (isDomestic)
                {
                    //promoClasses = this.ProviderModel.GetDelimitedValues("DomesticPromoClasses", null, ';');
                }
                else
                {
                    //promoClasses = this.ProviderModel.GetDelimitedValues("InternationalPromoClasses", null, ';');
                }
                int nonInfants = request.adult + request.child + request.tsk + request.ogr; //FlightHelpers.GetNonInfantPassengerCounts(query);
                List<BookingClassAvailExtType> cheapestBookingClasses = new List<BookingClassAvailExtType>();
                OriginDestinationOptionExtType[] originDestinationOptionExt = response.OriginDestinationOptionsExt.OriginDestinationOptionExt;
                for (int i = 0; i < originDestinationOptionExt.Length; i++)
                {
                    OriginDestinationOptionExtType option = originDestinationOptionExt[i];
                    if (!request.directFlightsOnly || option.FlightSegmentExt.Length <= 1)
                    {
                        if (!option.FlightSegmentExt.Any((FlightSegmentExtType x) => x.BookingClassAvailExt == null))
                        {
                            FlightOption pgsOption = new FlightOption();
                            pgsOption.BookingProviderId = this.ProviderModel.ProviderNo;
                            pgsOption.BookingProviderCode = this.ProviderModel.ProviderCode;
                            pgsOption.RelatedQueryObject = query;
                            pgsOption.OptionFlag = "OW";
                            pgsOption.OriginDestinationFlag = string.Format("{0}-{1}", option.FlightSegmentExt.First<FlightSegmentExtType>().DepartureAirport.LocationCode, option.FlightSegmentExt.Last<FlightSegmentExtType>().ArrivalAirport.LocationCode);
                            pgsOption.TripType = E_TripTypes.OneWay;
                            pgsOption.FreeBaggageAllowance = new FreeBaggageAllowance[]
							{
								Common.GetBaggageAllowance(query, isDomestic)
							};
                            pgsOption.Segments = new List<Segment>();
                            pgsOption.SegmentAvailabilities = new List<SegmentAvailability>();
                            int segmentIndex = 1;
                            FlightSegmentExtType[] flightSegmentExt = option.FlightSegmentExt;
                            for (int j = 0; j < flightSegmentExt.Length; j++)
                            {
                                FlightSegmentExtType segment = flightSegmentExt[j];
                                IEnumerable<BookingClassAvailExtType> availableBookingClasses =
                                    from x in segment.BookingClassAvailExt
                                    where x.ResBookDesigQuantity >= nonInfants
                                    select x;
                                SegmentAvailability pgsSegmentAvailability = new SegmentAvailability
                                {
                                    SegmentIndex = segmentIndex,
                                    BookingClasses = new List<BookingClassAvailability>()
                                };
                                foreach (BookingClassAvailExtType bookingClass in availableBookingClasses)
                                {
                                    pgsSegmentAvailability.BookingClasses.Add(new BookingClassAvailability
                                    {
                                        Code = bookingClass.ResBookDesigCode,
                                        AvailableSeats = bookingClass.ResBookDesigQuantity,
                                        IsPromo = promoClasses.Contains(bookingClass.ResBookDesigCode)
                                    });
                                }
                                pgsOption.SegmentAvailabilities.Add(pgsSegmentAvailability);
                                Segment pgsSegment = new Segment();
                                pgsSegment.Index = segmentIndex;
                                pgsSegment.OriginAirport = segment.DepartureAirport.LocationCode;
                                pgsSegment.DestinationAirport = segment.ArrivalAirport.LocationCode;
                                pgsSegment.OD_OriginAirport = option.FlightSegmentExt.First<FlightSegmentExtType>().DepartureAirport.LocationCode;
                                pgsSegment.OD_DestinationAirport = option.FlightSegmentExt.Last<FlightSegmentExtType>().ArrivalAirport.LocationCode;
                                pgsSegment.DepartureDateTime = DateTime.Parse(segment.DepartureDateTime);
                                pgsSegment.ArrivalDateTime = DateTime.Parse(segment.ArrivalDateTime);
                                pgsSegment.FlightNumber = segment.MarkettingAirline.CompanyShortName + segment.FlightNumber;
                                pgsSegment.MarketingAirline = segment.MarkettingAirline.CompanyShortName;
                                pgsSegment.OperatingAirline = pgsSegment.MarketingAirline;
                                pgsSegment.Equipment = segment.Equipment.AirEquipType;
                                BookingClassAvailExtType cheapestBookingClass = availableBookingClasses.FirstOrDefault((BookingClassAvailExtType x) => x.ResBookDesigCode == pgsSegmentAvailability.BookingClasses.Last<BookingClassAvailability>().Code);
                                cheapestBookingClasses.Add(cheapestBookingClass);
                                pgsSegment.BookingClassCode = cheapestBookingClass.ResBookDesigCode;
                                pgsSegment.FareBasisCode = pgsSegment.BookingClassCode;
                                pgsSegment.FareReference = cheapestBookingClass.FareDisplayInfos.FareDisplayInfo.Last<FareDisplayInfoType>().FareReference;
                                pgsSegment.FareReferenceId = cheapestBookingClass.FareDisplayInfos.FareDisplayInfo.Last<FareDisplayInfoType>().FareReferenceID;
                                pgsOption.Segments.Add(pgsSegment);
                                segmentIndex++;
                            }
                            result.FlightOptions.Add(pgsOption);
                        }
                    }
                }
                foreach (FlightOption pgsoption in result.FlightOptions)
                {
                    this.GetFareTypesInParallelThread(pgsoption);
                }
                this.CalculateFares(query, result, isDomestic, cheapestBookingClasses);
            }
            else
            {
                result.FlightOptions = null;
                result.HasError = true;
            }
            return result;
        }

        private void GetFareTypesInParallelThread(FlightOption option)
        {
            Task<FareType> oServiceFeetask = Task<FareType>.New((object o) => FareHelper.GetItineraryServiceFee(option, this.ProviderModel), option);
            option.FreeVolatileData.Add("ServicesFeesTask", oServiceFeetask);
            oServiceFeetask.Start();
        }

        private void CalculateFares(AirQuery query, QueryResult result, bool isDomestic, List<BookingClassAvailExtType> cheapestBookingClasses)
        {
            int index = 0;
            List<BookingClassAvailExtType> bookingClassAvailList = new List<BookingClassAvailExtType>();
            foreach (FlightOption option in result.FlightOptions)
            {
                foreach (Segment seg in option.Segments)
                {
                    bookingClassAvailList.Add(cheapestBookingClasses[index]);
                    index++;
                }
                if (option.FreeVolatileData["ServicesFeesTask"] == null)
                {
                    break;
                }
                Task<FareType> task = option.FreeVolatileData["ServicesFeesTask"] as Task<FareType>;
                task.Wait();
                FareType itineraryServiceFee = task.Result;
                decimal providerSc = decimal.Parse(itineraryServiceFee.Amount, CultureInfo.InvariantCulture);
                providerSc /= FlightHelpers.GetNonInfantPassengerCounts(query);
                option.FareInfo = FareHelper.CalculateItineraryInfo(query, bookingClassAvailList, isDomestic, this.ProviderModel, providerSc);
                option.FreeVolatileData.Remove("ServicesFeesTask");
                bookingClassAvailList.Clear();
            }
        }
    }
}