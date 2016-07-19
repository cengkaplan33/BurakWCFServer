
////using System;
////using System.Collections.Generic;
////using System.Globalization;
////using System.Linq;
////using Trevoo.Accounts.Providers.Model;
////using Trevoo.Air.Pgs.PGSWS;
////using Trevoo.Definitions;
////using Trevoo.Entities.Air;
////using Trevoo.Entities.Common;
////using Trevoo.Threading;

////using NewRelic.Api.Agent;
////using System;
////using System.Collections.Generic;
////using System.Configuration;
////using System.Data.Linq;
////using System.Linq;
////using System.Reflection;
////using Trevoo.Accounting;
////using Trevoo.Air.Matrix;
////using Trevoo.Context;
////using Trevoo.Definitions;
////using Trevoo.Definitions.Values;
////using Trevoo.Entities.Air;
////using Trevoo.Entities.Common;
////using Trevoo.Entities.Recommendation;
////using Trevoo.Sale;
////using Trevoo.Utilities;

using BurakWcfService.Air.Models;

namespace BurakWcfService.Air.FlightHelper
{
    public class FlightHelpers
    {
        //        public static string GetCountryCode(string phoneNumber)
        //        {
        //            return phoneNumber.Split(new char[]
        //            {
        //                '-'
        //            }).First<string>().Replace("+", "00");
        //        }
        //        public static string GetPhoneNumber(string phoneNumber)
        //        {
        //            return phoneNumber.Split(new char[]
        //            {
        //                '-'
        //            }).Last<string>();
        //        }
        //        public static string GetRawFlightNumber(string flightNumber)
        //        {
        //            int length = flightNumber.Length;
        //            return flightNumber.Substring(2, length - 2);
        //        }
        //        public static int[] GetPassengerCounts(AirQuery query)
        //        {
        //            AirQuery_PaxItem adultCount = query.Paxes.FirstOrDefault((AirQuery_PaxItem p) => p.PaxType == "ADT");
        //            AirQuery_PaxItem childCount = query.Paxes.FirstOrDefault((AirQuery_PaxItem p) => p.PaxType == "CHD");
        //            AirQuery_PaxItem infantCount = query.Paxes.FirstOrDefault((AirQuery_PaxItem p) => p.PaxType == "INF");
        //            AirQuery_PaxItem studentCount = query.Paxes.FirstOrDefault((AirQuery_PaxItem p) => p.PaxType == "STD");
        //            AirQuery_PaxItem seniorCount = query.Paxes.FirstOrDefault((AirQuery_PaxItem p) => p.PaxType == "SRC");
        //            AirQuery_PaxItem militaryCount = query.Paxes.FirstOrDefault((AirQuery_PaxItem p) => p.PaxType == "MIL");
        //            int adt = (adultCount != null) ? adultCount.Count : 0;
        //            int chd = (childCount != null) ? childCount.Count : 0;
        //            int inf = (infantCount != null) ? infantCount.Count : 0;
        //            int std = (studentCount != null) ? studentCount.Count : 0;
        //            int src = (seniorCount != null) ? seniorCount.Count : 0;
        //            int mil = (militaryCount != null) ? militaryCount.Count : 0;
        //            adt += std + src + mil;
        //            return new int[]
        //            {
        //                adt,
        //                chd,
        //                inf
        //            };
        //        }
        //        public static int GetNonInfantPassengerCounts(AirQuery query)
        //        {
        //            return (
        //                from x in query.Paxes
        //                where x.PaxType != "INF"
        //                select x).Sum((AirQuery_PaxItem y) => y.Count);
        //        }
        //        public static bool IsFlightInTurkey(AirQuery query)
        //        {
        //            bool isDomestic = false;
        //            AirQuery_Segment route = query.IntendedSegments[0];
        //            if (route.Origin.CountryCode == "TR" && route.Destination.CountryCode == "TR")
        //            {
        //                isDomestic = true;
        //            }
        //            return isDomestic;
        //        }

        public static bool IsFlightInTurkeyOrECN(Airport Origin, Airport Destination )
        {
            bool isDomestic = false;
            if ((Origin.CountryCode == "TR" || Origin.Code == "ECN") && (Destination.CountryCode == "TR" || Destination.Code == "ECN"))
            {
                isDomestic = true;
            }

            return isDomestic;
        }

        //        public static T_Booking GenerateBookingObjectFromProduct(T_Product product)
        //        {
        //            T_Booking booking = new T_Booking();
        //            booking.ProductId = product.Id;
        //            booking.ProductObject = product;
        //            booking.ShoppingFileId = product.ShoppingFileId;
        //            booking.PnrNumber = product.BookingCode;
        //            T_Booking arg_66_0 = booking;
        //            System.DateTime? dateTime = product.SellingDate;
        //            arg_66_0.BookingDateTime = (dateTime.HasValue ? new System.DateTimeOffset?(dateTime.GetValueOrDefault()) : null);
        //            booking.ProviderId = product.ProviderId;
        //            T_Booking arg_A9_0 = booking;
        //            dateTime = product.ReservationDate;
        //            arg_A9_0.ReservationDateTime = (dateTime.HasValue ? new System.DateTimeOffset?(dateTime.GetValueOrDefault()) : null);
        //            booking.Status = product.Status;
        //            booking.SupplierId = 1;
        //            booking.TripType = ((product.Flight_TripType == "OW") ? E_TripTypes.OneWay : E_TripTypes.RoundTrip);
        //            booking.BookingItems = new EntitySet<T_BookingItem>();
        //            T_ProductItem[] array = product.ProductItems.ToArray<T_ProductItem>();
        //            for (int i = 0; i < array.Length; i++)
        //            {
        //                T_ProductItem product_item = array[i];
        //                T_BookingItem booking_item = new T_BookingItem();
        //                booking_item.ProductItemId = product_item.Id;
        //                booking.BookingItems.Add(booking_item);
        //                booking_item.BookingObject = booking;
        //                booking_item.PassengerType = booking_item.PassengerObject.Type;
        //            }
        //            booking.Segments = new EntitySet<T_Segment>();
        //            foreach (T_FlightSegment seg in product._FlightSegments)
        //            {
        //                T_Segment x = new T_Segment();
        //                x.FareType = seg.FareType;
        //                x.FareBasis = seg.FareBasis;
        //                x.BookingClass = seg.BookingClass;
        //                booking.Segments.Add(x);
        //            }
        //            return booking;
        //        }
        //        public static E_PassengerTypes ConvertFromString(string paxType)
        //        {
        //            E_PassengerTypes E_PassengerType;
        //            switch (paxType)
        //            {
        //                case "ADT":
        //                    E_PassengerType = E_PassengerTypes.Adult;
        //                    return E_PassengerType;
        //                case "CHD":
        //                    E_PassengerType = E_PassengerTypes.Child;
        //                    return E_PassengerType;
        //                case "INF":
        //                    E_PassengerType = E_PassengerTypes.Infant;
        //                    return E_PassengerType;
        //                case "STD":
        //                    E_PassengerType = E_PassengerTypes.Student;
        //                    return E_PassengerType;
        //                case "SRC":
        //                    E_PassengerType = E_PassengerTypes.Senior;
        //                    return E_PassengerType;
        //                case "MIL":
        //                    E_PassengerType = E_PassengerTypes.Military;
        //                    return E_PassengerType;
        //            }
        //            E_PassengerType = E_PassengerTypes.NotDefined;
        //            return E_PassengerType;
        //        }
        //        public static bool IsReservationEnabled(FlightOption option)
        //        {
        //            bool IsReservationOK = false;
        //            if (option.BookingProviderId == 101)
        //            {
        //                if (option.Segments.First<Trevoo.Entities.Air.Segment>().DepartureDateTime > System.DateTime.Now.AddDays(3.0))
        //                {
        //                    IsReservationOK = true;
        //                }
        //            }
        //            return IsReservationOK;
        //        }
        //        public static bool IsTicketEnabled(FlightOption option)
        //        {
        //            bool isETicketOK = false;
        //            if (option.Segments.First<Trevoo.Entities.Air.Segment>().DepartureDateTime > System.DateTime.Now.AddHours(1.0))
        //            {
        //                isETicketOK = true;
        //            }
        //            return isETicketOK;
        //        }
        //        public static bool IsNewAddOnsActive()
        //        {
        //            string useNewAddOnsStr = ConfigurationManager.AppSettings["use-new-addons"];
        //            bool useNewAddOns = false;
        //            bool.TryParse(useNewAddOnsStr, out useNewAddOns);
        //            return useNewAddOns;
        //        }
        //        public static string GetEmail(T_Passenger contact)
        //        {
        //            string email = (Session.Current.BusinessId == 2234) ? contact.Email : string.Empty;
        //            string result;
        //            if (BasicValidations.IsValidEmail(email))
        //            {
        //                result = email;
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    email = Session.Current.User.UserInfo.Email;
        //                    if (BasicValidations.IsValidEmail(email))
        //                    {
        //                        result = email;
        //                        return result;
        //                    }
        //                    email = Session.Current.Business.BusinessInfo.ContactInfo.Email;
        //                    if (BasicValidations.IsValidEmail(email))
        //                    {
        //                        result = email;
        //                        return result;
        //                    }
        //                }
        //                catch
        //                {
        //                }
        //                try
        //                {
        //                    if (!Application.SystemTag.Contains("biletbank"))
        //                    {
        //                        email = "INFO@" + Application.SystemTag.ToUpper() + ".COM.TR";
        //                        if (BasicValidations.IsValidEmail(email))
        //                        {
        //                            result = email;
        //                            return result;
        //                        }
        //                    }
        //                }
        //                catch
        //                {
        //                }
        //                result = "INFO@BILETBANK.COM";
        //            }
        //            return result;
        //        }
        //        public static string CalculateDuration(Trevoo.Entities.Air.Segment seg)
        //        {
        //            string duration = "0:0";
        //            try
        //            {
        //                Airport departure = Application.GetAirportByCode(seg.OriginAirport);
        //                Airport arrival = Application.GetAirportByCode(seg.DestinationAirport);
        //                duration = (seg.ArrivalDateTime - seg.DepartureDateTime).Days * 24 + (seg.ArrivalDateTime - seg.DepartureDateTime).Hours + ":" + (seg.ArrivalDateTime - seg.DepartureDateTime).Minutes;
        //                if (departure.Country != arrival.Country)
        //                {
        //                    System.DateTime start = seg.DepartureDateTime.AddHours(-(double)departure.UTCDifference.GetValueOrDefault());
        //                    System.DateTime end = seg.ArrivalDateTime.AddHours(-(double)arrival.UTCDifference.GetValueOrDefault());
        //                    bool flag = 1 == 0;
        //                    duration = (end - start).Days * 24 + (end - start).Hours + ":" + (end - start).Minutes;
        //                }
        //            }
        //            catch (System.Exception)
        //            {
        //            }
        //            string[] fligthDuration = duration.Split(new char[]
        //            {
        //                ':'
        //            });
        //            if (fligthDuration[0].Length == 1)
        //            {
        //                fligthDuration[0] = "0" + fligthDuration[0];
        //            }
        //            if (fligthDuration[1].Length == 1)
        //            {
        //                fligthDuration[1] = "0" + fligthDuration[1];
        //            }
        //            return fligthDuration[0] + ":" + fligthDuration[1];
        //        }
        //        private static string CalculateDuration(FlightOption flightOption)
        //        {
        //            string duration = "0:0";
        //            try
        //            {
        //                Airport departure = Application.GetAirportByCode(flightOption.Segments.FirstOrDefault<Trevoo.Entities.Air.Segment>().OriginAirport);
        //                Airport arrival = Application.GetAirportByCode(flightOption.Segments.LastOrDefault<Trevoo.Entities.Air.Segment>().DestinationAirport);
        //                duration = (flightOption.Segments.Last<Trevoo.Entities.Air.Segment>().ArrivalDateTime - flightOption.Segments.First<Trevoo.Entities.Air.Segment>().DepartureDateTime).Days * 24 + (flightOption.Segments.Last<Trevoo.Entities.Air.Segment>().ArrivalDateTime - flightOption.Segments.First<Trevoo.Entities.Air.Segment>().DepartureDateTime).Hours + ":" + (flightOption.Segments.Last<Trevoo.Entities.Air.Segment>().ArrivalDateTime - flightOption.Segments.First<Trevoo.Entities.Air.Segment>().DepartureDateTime).Minutes;
        //                if (departure.Country != arrival.Country)
        //                {
        //                    System.DateTime start = flightOption.Segments.FirstOrDefault<Trevoo.Entities.Air.Segment>().DepartureDateTime.AddHours(-(double)departure.UTCDifference.GetValueOrDefault());
        //                    System.DateTime end = flightOption.Segments.LastOrDefault<Trevoo.Entities.Air.Segment>().ArrivalDateTime.AddHours(-(double)arrival.UTCDifference.GetValueOrDefault());
        //                    bool flag = 1 == 0;
        //                    duration = (end - start).Days * 24 + (end - start).Hours + ":" + (end - start).Minutes;
        //                }
        //            }
        //            catch (System.Exception)
        //            {
        //            }
        //            string[] fligthDuration = duration.Split(new char[]
        //            {
        //                ':'
        //            });
        //            if (fligthDuration[0].Length == 1)
        //            {
        //                fligthDuration[0] = "0" + fligthDuration[0];
        //            }
        //            if (fligthDuration[1].Length == 1)
        //            {
        //                fligthDuration[1] = "0" + fligthDuration[1];
        //            }
        //            return fligthDuration[0] + ":" + fligthDuration[1];
        //        }
        //        public static void SetBaggageAllowance(T_Product product)
        //        {
        //            FlightOption optionObject = product.NativeOptionObject as FlightOption;
        //            string[] passTypes = (
        //                from x in optionObject.FareInfo.PaxFares
        //                select x.PaxType).Distinct<string>().ToArray<string>();
        //            string[] array = passTypes;
        //            for (int i = 0; i < array.Length; i++)
        //            {
        //                string passType = array[i];
        //                string baggageAllowance = string.Empty;
        //                System.Collections.Generic.IEnumerable<T_ProductItem> pitems =
        //                    from x in product.ProductItems
        //                    where FlightHelpers.ConvertToString(x.PaxReferences.First<T_PaxReference>().PassengerObject.Type) == passType
        //                    select x;
        //                Baggage FBA = optionObject.FreeBaggageAllowance[0].FBA.First((PaxBaggageAllowance x) => x.PaxType == passType).PaxFBA;
        //                foreach (T_ProductItem pit in pitems)
        //                {
        //                    baggageAllowance = FBA.Allowance + FBA.Unit;
        //                    if (optionObject.FreeBaggageAllowance.Length > 1)
        //                    {
        //                        baggageAllowance += "/";
        //                        Baggage FBARet = optionObject.FreeBaggageAllowance[1].FBA.First((PaxBaggageAllowance x) => x.PaxType == passType).PaxFBA;
        //                        baggageAllowance = baggageAllowance + FBARet.Allowance + FBARet.Unit;
        //                    }
        //                    pit.Flight_Baggage = baggageAllowance;
        //                }
        //            }
        //        }
        //        public static string ConvertToString(E_PassengerTypes paxType)
        //        {
        //            string result;
        //            switch (paxType)
        //            {
        //                case E_PassengerTypes.Adult:
        //                    result = "ADT";
        //                    break;
        //                case E_PassengerTypes.Child:
        //                    result = "CHD";
        //                    break;
        //                case E_PassengerTypes.Infant:
        //                    result = "INF";
        //                    break;
        //                case E_PassengerTypes.Student:
        //                    result = "STD";
        //                    break;
        //                case E_PassengerTypes.Senior:
        //                    result = "SRC";
        //                    break;
        //                case E_PassengerTypes.Military:
        //                    result = "MIL";
        //                    break;
        //                default:
        //                    result = "ADT";
        //                    break;
        //            }
        //            return result;
        //        }
        //        private static string GetBaggageAllowancePerPassenger(string paxType, FlightOption option)
        //        {
        //            string baggageAllowance = string.Empty;
        //            if (option.FreeBaggageAllowance != null && option.FreeBaggageAllowance.Length > 0)
        //            {
        //                FreeBaggageAllowance departureFba = option.FreeBaggageAllowance[0];
        //                PaxBaggageAllowance paxFbaDept = departureFba.FBA.FirstOrDefault((PaxBaggageAllowance x) => x.PaxType == paxType);
        //                if (paxFbaDept != null)
        //                {
        //                    baggageAllowance = paxFbaDept.PaxFBA.Allowance + paxFbaDept.PaxFBA.Unit;
        //                    if (option.FreeBaggageAllowance.Length > 1)
        //                    {
        //                        baggageAllowance += "/";
        //                        FreeBaggageAllowance returnFba = option.FreeBaggageAllowance[1];
        //                        PaxBaggageAllowance paxFbaRet = returnFba.FBA.FirstOrDefault((PaxBaggageAllowance x) => x.PaxType == paxType);
        //                        if (paxFbaRet != null)
        //                        {
        //                            baggageAllowance = baggageAllowance + paxFbaRet.PaxFBA.Allowance + paxFbaRet.PaxFBA.Unit;
        //                        }
        //                    }
        //                }
        //            }
        //            return baggageAllowance;
        //        }
        //        public static T_Product BuildProduct(FlightOption flightOption)
        //        {
        //            FlightHelpers.<>c__DisplayClass2c <>c__DisplayClass2c = new FlightHelpers.<>c__DisplayClass2c();
        //            foreach (Trevoo.Entities.Air.Segment seg in flightOption.Segments)
        //            {
        //                seg.Duration = FlightHelpers.CalculateDuration(seg);
        //            }
        //            T_Product product = null;
        //            if (flightOption.ProductObject != null)
        //            {
        //                product = flightOption.ProductObject;
        //            }
        //            else
        //            {
        //                product = new T_Product();
        //            }
        //            if (product.Id == System.Guid.Empty)
        //            {
        //                product.Id = System.Guid.NewGuid();
        //            }
        //            if (string.IsNullOrWhiteSpace(product.LocalProductId))
        //            {
        //                product.LocalProductId = product.Id.ToString();
        //            }
        //            FlightHelpers.FillProductFares(product, flightOption);
        //            product.ProductType = E_ProductTypes.Flight;
        //            product.ProviderId = flightOption.BookingProviderId;
        //            product.ContractorBusiness = flightOption.BookingContractorBusiness;
        //            product.Status = E_ProductStatuses.NotLoaded;
        //            product.LastCommand = "INIT";
        //            product.LastApprovedCommand = "INIT";
        //            product.IsReservationEnabled = new bool?(FlightHelpers.IsReservationEnabled(flightOption));
        //            product.IsETicketEnabled = new bool?(FlightHelpers.IsTicketEnabled(flightOption));
        //            flightOption.Duration = FlightHelpers.CalculateDuration(flightOption);
        //            <>c__DisplayClass2c.od_origin = flightOption.Segments.First<Trevoo.Entities.Air.Segment>().OD_OriginAirport;
        //            if (flightOption.Segments.Any((Trevoo.Entities.Air.Segment x) => x.OD_DestinationAirport == <>c__DisplayClass2c.od_origin))
        //            {
        //                product.Flight_TripType = "RT";
        //            }
        //            else
        //            {
        //                product.Flight_TripType = "OW";
        //            }
        //            string origin = flightOption.Segments.First<Trevoo.Entities.Air.Segment>().OD_OriginAirport;
        //            string dest = flightOption.Segments.First<Trevoo.Entities.Air.Segment>().OD_DestinationAirport;
        //            bool is_domestic;
        //            if (flightOption.BookingProviderId == 101)
        //            {
        //                string[][] domesticAirports = ShoppingFileController.GetDomesticAirports();
        //                bool arg_231_0;
        //                if (domesticAirports.Any((string[] x) => x.Contains(origin)))
        //                {
        //                    arg_231_0 = domesticAirports.Any((string[] y) => y.Contains(dest));
        //                }
        //                else
        //                {
        //                    arg_231_0 = false;
        //                }
        //                is_domestic = arg_231_0;
        //            }
        //            else
        //            {
        //                is_domestic = (Application.IsDomestic(origin) && Application.IsDomestic(dest));
        //            }
        //            if (!flightOption.NoSeatsAvailable)
        //            {
        //                if (!Application.UseNewFaringModule)
        //                {
        //                    FlightHelpers.SetSfRefs(flightOption, product, is_domestic);
        //                    product.SfRef_IsFlex = new bool?(false);
        //                    product.SfRef_IsFix = new bool?(true);
        //                }
        //                else
        //                {
        //                    product.SfRef_IsFlex = new bool?(true);
        //                    product.SfRef_IsFix = new bool?(false);
        //                }
        //                product.SfRef_IsCommission = new bool?(false);
        //                foreach (FareQuote_PaxFareItem paxFare in flightOption.FareInfo.PaxFares)
        //                {
        //                    T_ProductItem item = new T_ProductItem();
        //                    if (paxFare.ProductItemId != System.Guid.Empty)
        //                    {
        //                        item.Id = paxFare.ProductItemId;
        //                    }
        //                    else
        //                    {
        //                        item.Id = System.Guid.NewGuid();
        //                    }
        //                    item.ShoppingFileId = product.ShoppingFileId;
        //                    paxFare.ProductItemId = item.Id;
        //                    item.LocalProductItemId = item.Id.ToString();
        //                    item.Buying_BaseFare = paxFare.Fare;
        //                    if (paxFare.DFF.HasValue)
        //                    {
        //                        item.Buying_BaseFare_AddOn = new decimal?((item.Buying_BaseFare_AddOn ?? 0m) + paxFare.DFF.Value);
        //                    }
        //                    item.Buying_Taxes = paxFare.ExtraFees;
        //                    item.Buying_ServiceFee = paxFare.ServiceFeeDetail.Amount;
        //                    item.Buying_ProviderServiceFee = paxFare.ServiceFeeDetail.ProviderAmount;
        //                    item.Flight_Baggage = FlightHelpers.GetBaggageAllowancePerPassenger(paxFare.PaxType, flightOption);
        //                    item.Buying_QC = paxFare.QC;
        //                    FlightHelpers.FillProductItemFares(item, paxFare, is_domestic);
        //                    if (product.ProviderId == 101 && flightOption.FreeVolatileData.ContainsKey("MILBILET") && (bool)flightOption.FreeVolatileData["MILBILET"])
        //                    {
        //                        item.Buying_BaseFare_AddOn = new decimal?((item.Buying_BaseFare_AddOn ?? 0m) + 10m);
        //                    }
        //                    if (paxFare.PaxType == "INF")
        //                    {
        //                        item.SfRef_IsApplicable = new bool?(false);
        //                    }
        //                    else if (paxFare.ServiceFeeDetail.Type == "Flex")
        //                    {
        //                        item.SfRef_IsApplicable = new bool?(true);
        //                    }
        //                    else if (paxFare.ServiceFeeDetail.Type == "Fix" && paxFare.ServiceFeeDetail.IncludedInFare)
        //                    {
        //                        item.SfRef_IsApplicable = new bool?(true);
        //                    }
        //                    else
        //                    {
        //                        item.SfRef_IsApplicable = new bool?(true);
        //                    }
        //                    product.ProductItems.Add(item);
        //                    product.PaxReferences.Add(new T_PaxReference
        //                    {
        //                        Id = System.Guid.NewGuid(),
        //                        ProductId = product.Id,
        //                        ProductItemId = item.Id,
        //                        ShoppingFileId = product.ShoppingFileId,
        //                        LocalPassengerSequenceNo = paxFare.PaxSequence,
        //                        LocalPassengerType = (byte)FlightHelpers.ConvertFromString(paxFare.PaxType),
        //                        LocalInterpretedPassengerType = FlightHelpers.ConvertFromString(paxFare.InterpretedPaxType)
        //                    });
        //                }
        //                if (product.ProductItems.All((T_ProductItem x) => x.Buying_VQ.HasValue))
        //                {
        //                    product.Buying_VQ = new decimal?(product.ProductItems.Sum((T_ProductItem x) => x.Buying_VQ.Value));
        //                }
        //                if (product.ProductItems.All((T_ProductItem x) => x.Buying_YR.HasValue))
        //                {
        //                    product.Buying_YR = new decimal?(product.ProductItems.Sum((T_ProductItem x) => x.Buying_YR.Value));
        //                }
        //            }
        //            string currency = flightOption.FareInfo.FaringCurrency;
        //            if (currency != "TRY")
        //            {
        //                flightOption.FareInfo.FaringCurrency = "TRY";
        //                foreach (FareQuote_PaxFareItem pax in flightOption.FareInfo.PaxFares)
        //                {
        //                    pax.Fare = CurrencyController.ConvertMoney(currency, pax.Fare, new int?(2));
        //                    pax.ExtraFees = CurrencyController.ConvertMoney(currency, pax.ExtraFees, new int?(2));
        //                    pax.VQ = CurrencyController.ConvertMoney(currency, pax.VQ, new int?(2));
        //                    pax.YR = CurrencyController.ConvertMoney(currency, pax.YR, new int?(2));
        //                    pax.TXE = CurrencyController.ConvertMoney(currency, pax.TXE, new int?(2));
        //                    if (pax.DFF.HasValue)
        //                    {
        //                        pax.DFF = new decimal?(CurrencyController.ConvertMoney(currency, pax.DFF.Value, new int?(2)));
        //                    }
        //                    pax.ServiceFeeDetail.Amount = CurrencyController.ConvertMoney(currency, pax.ServiceFeeDetail.Amount, new int?(2));
        //                    pax.ServiceFeeDetail.ProviderAmount = CurrencyController.ConvertMoney(currency, pax.ServiceFeeDetail.ProviderAmount, new int?(2));
        //                    pax.SubTotal = CurrencyController.ConvertMoney(currency, pax.SubTotal, new int?(2));
        //                    pax.EXT_IN_Taxes = CurrencyController.ConvertMoney(currency, pax.EXT_IN_Taxes, new int?(2));
        //                    pax.EXT_IN_BaseFare = CurrencyController.ConvertMoney(currency, pax.EXT_IN_BaseFare, new int?(2));
        //                    pax.EXT_IN_TXE = CurrencyController.ConvertMoney(currency, pax.EXT_IN_TXE, new int?(2));
        //                    pax.EXT_IN_VQ = CurrencyController.ConvertMoney(currency, pax.EXT_IN_VQ, new int?(2));
        //                    pax.EXT_IN_YR = CurrencyController.ConvertMoney(currency, pax.EXT_IN_YR, new int?(2));
        //                    pax.EXT_OUT_Taxes = CurrencyController.ConvertMoney(currency, pax.EXT_OUT_Taxes, new int?(2));
        //                    pax.EXT_OUT_BaseFare = CurrencyController.ConvertMoney(currency, pax.EXT_OUT_BaseFare, new int?(2));
        //                    pax.EXT_OUT_TXE = CurrencyController.ConvertMoney(currency, pax.EXT_OUT_TXE, new int?(2));
        //                    pax.EXT_OUT_VQ = CurrencyController.ConvertMoney(currency, pax.EXT_OUT_VQ, new int?(2));
        //                    pax.EXT_OUT_YR = CurrencyController.ConvertMoney(currency, pax.EXT_OUT_YR, new int?(2));
        //                }
        //                flightOption.FareInfo.FaresTotal = CurrencyController.ConvertMoney(currency, flightOption.FareInfo.FaresTotal, new int?(2));
        //                flightOption.FareInfo.ExtraFeesTotal = CurrencyController.ConvertMoney(currency, flightOption.FareInfo.ExtraFeesTotal, new int?(2));
        //                flightOption.FareInfo.ServiceFeesTotal = CurrencyController.ConvertMoney(currency, flightOption.FareInfo.ServiceFeesTotal, new int?(2));
        //                flightOption.FareInfo.GrandTotal = CurrencyController.ConvertMoney(currency, flightOption.FareInfo.GrandTotal, new int?(2));
        //            }
        //            flightOption.ProductObject = product;
        //            product.NativeOptionObject = flightOption;
        //            if (flightOption.FreeVolatileData.ContainsKey("MILBILET") && (bool)flightOption.FreeVolatileData["MILBILET"])
        //            {
        //                string freedata = string.Format("THYMIL;{0};{1}", flightOption.FreeVolatileData["MILCLASS"], flightOption.FreeVolatileData["MILAMOUNT"]);
        //                product.Ext_FreeField = freedata;
        //            }
        //            if (product.ProviderId == 101)
        //            {
        //                product.VATFlag = "DOM";
        //            }
        //            else
        //            {
        //                product.VATFlag = (FlightHelpers.IsFlightInTurkeyOrECN(flightOption.RelatedQueryObject) ? "DOM" : "INT");
        //            }
        //            return product;
        //        }
        //        private static void SetSfRefs(FlightOption flightOption, T_Product product, bool isDomestic)
        //        {
        //            FareQuote_PaxFareItem sfPax = (
        //                from x in flightOption.FareInfo.PaxFares
        //                orderby x.ServiceFeeDetail.Amount descending
        //                select x).First<FareQuote_PaxFareItem>();
        //            try
        //            {
        //                E_FlightProviders providerId = (E_FlightProviders)product.ProviderId;
        //                System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, ServiceFeeConstants.RefCondition>> providerRefs = ServiceFeeConstants.Values[providerId];
        //                foreach (System.Collections.Generic.KeyValuePair<string, ServiceFeeConstants.RefCondition> pref in providerRefs)
        //                {
        //                    ServiceFeeConstants.RefCondition refCond = pref.Value;
        //                    product.SfRef_Code = pref.Key;
        //                    if (refCond == null)
        //                    {
        //                        product.SfRef_Amount = new decimal?(sfPax.ServiceFeeDetail.Amount);
        //                    }
        //                    else if (refCond.SCValueBtw(sfPax.ServiceFeeDetail.Amount) && (!refCond.IsDomestic.HasValue || refCond.IsDomestic.Value == isDomestic))
        //                    {
        //                        product.SfRef_Amount = new decimal?(refCond.SCMin);
        //                        break;
        //                    }
        //                }
        //            }
        //            catch (System.Exception e)
        //            {
        //                NewRelic.NoticeError(e);
        //                Logger.WriteLog("Error setting ref codes: {0}", new object[]
        //                {
        //                    e.Message
        //                });
        //            }
        //            if (product.ProviderId == 101 && flightOption.FreeVolatileData.ContainsKey("MILBILET") && (bool)flightOption.FreeVolatileData["MILBILET"])
        //            {
        //                product.SfRef_Code = "THY_25";
        //                product.SfRef_Amount = new decimal?(25m);
        //            }
        //        }
        //        public static void FillProductFares(T_Product product, FlightOption flightOption)
        //        {
        //            if (flightOption.FareInfo != null)
        //            {
        //                product.Buying_Currency = flightOption.FareInfo.FaringCurrency;
        //                product.Buying_BaseFare = flightOption.FareInfo.FaresTotal;
        //                product.Buying_Taxes = flightOption.FareInfo.ExtraFeesTotal;
        //                product.Buying_ServiceFee = flightOption.FareInfo.ServiceFeesTotal;
        //                product.Buying_ProviderServiceFee = flightOption.FareInfo.PaxFares.Sum((FareQuote_PaxFareItem x) => x.ServiceFeeDetail.ProviderAmount);
        //            }
        //            else
        //            {
        //                product.Buying_Currency = "TRY";
        //                product.SfRef_Code = "NOSEAT";
        //            }
        //        }
        //        public static void FillProductItemFares(T_ProductItem item, FareQuote_PaxFareItem paxFare, bool isDomestic)
        //        {
        //            if (isDomestic)
        //            {
        //                item.Buying_VQ = paxFare.VQ;
        //                item.Buying_YR = paxFare.YR;
        //                item.Buying_TXE = paxFare.TXE;
        //            }
        //            item.Ext_OUT_Buying_BaseFare = paxFare.EXT_OUT_BaseFare;
        //            item.Ext_OUT_Buying_Taxes = paxFare.EXT_OUT_Taxes;
        //            item.Ext_OUT_Buying_VQ = paxFare.EXT_OUT_VQ;
        //            item.Ext_OUT_Buying_YR = paxFare.EXT_OUT_YR;
        //            item.Ext_OUT_Buying_TXE = paxFare.EXT_OUT_TXE;
        //            item.Ext_IN_Buying_BaseFare = paxFare.EXT_IN_BaseFare;
        //            item.Ext_IN_Buying_Taxes = paxFare.EXT_IN_Taxes;
        //            item.Ext_IN_Buying_VQ = paxFare.EXT_IN_VQ;
        //            item.Ext_IN_Buying_YR = paxFare.EXT_IN_YR;
        //            item.Ext_IN_Buying_TXE = paxFare.EXT_IN_TXE;
        //        }
        //        public static T_Product BuildMergedProduct(FlightOption flightOption, bool addOnApplied)
        //        {
        //            T_Product product = FlightHelpers.BuildProduct(flightOption);
        //            if (addOnApplied)
        //            {
        //                object engine = System.Activator.CreateInstance("Trevoo.Air.Engine", "Trevoo.Air.Engine.AirEngine").Unwrap();
        //                if (FlightHelpers.IsNewAddOnsActive())
        //                {
        //                    System.Reflection.MethodInfo method = engine.GetType().GetMethod("ApplyNewAddOnsAfterMerge", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod);
        //                    method.Invoke(null, new object[]
        //                    {
        //                        flightOption,
        //                        product
        //                    });
        //                }
        //                else
        //                {
        //                    System.Reflection.MethodInfo method = engine.GetType().GetMethod("ApplyAddOnsAfterMerge", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod);
        //                    method.Invoke(null, new object[]
        //                    {
        //                        flightOption,
        //                        product
        //                    });
        //                }
        //            }
        //            return product;
        //        }
        //        public static T_Booking BuildBookingObject(FlightOption selectedOption, T_Booking targetBookingObject)
        //        {
        //            targetBookingObject.ShoppingFileId = selectedOption.ProductObject.ShoppingFileId;
        //            targetBookingObject.ProductId = selectedOption.ProductObject.Id;
        //            targetBookingObject.Status = E_ProductStatuses.Option;
        //            targetBookingObject.ProviderId = selectedOption.BookingProviderId;
        //            targetBookingObject.T_LastSessionId = selectedOption.ProductObject.ShoppingFileObject_ForOption.T_LastSessionId;
        //            targetBookingObject.T_LastTransactionId = selectedOption.ProductObject.ShoppingFileObject_ForOption.T_LastTransactionId;
        //            targetBookingObject.TripType = selectedOption.TripType;
        //            targetBookingObject.PnrNumber = null;
        //            targetBookingObject.RelatedBookingId = null;
        //            targetBookingObject.ReservationDateTime = null;
        //            targetBookingObject.BookingDateTime = null;
        //            targetBookingObject.CancelDateTime = null;
        //            targetBookingObject.ExpirationDateTime = null;
        //            foreach (T_ProductItem item in selectedOption.ProductObject.ProductItems)
        //            {
        //                T_BookingItem newItem = new T_BookingItem();
        //                newItem.ProductId = targetBookingObject.ProductId;
        //                newItem.ProductItemId = item.Id;
        //                newItem.TicketNumber = null;
        //                newItem.PassengerType = (E_PassengerTypes)item.PaxReferences.First<T_PaxReference>().LocalPassengerType;
        //                targetBookingObject.BookingItems.Add(newItem);
        //            }
        //            foreach (Trevoo.Entities.Air.Segment seg in selectedOption.Segments)
        //            {
        //                T_Segment tseg = new T_Segment();
        //                tseg.ProductId = targetBookingObject.ProductId;
        //                tseg.OriginCode = seg.OriginAirport;
        //                tseg.DestinationCode = seg.DestinationAirport;
        //                tseg.DepartureDateTime = seg.DepartureDateTime;
        //                tseg.ArrivalDateTime = seg.ArrivalDateTime;
        //                tseg.BookingClass = seg.BookingClassCode;
        //                tseg.FlightNumber = seg.FlightNumber;
        //                tseg.MarketingAirline = seg.MarketingAirline;
        //                tseg.OperatingAirline = seg.OperatingAirline;
        //                tseg.OD_OriginCode = seg.OD_OriginAirport;
        //                tseg.OD_DestinationCode = seg.OD_DestinationAirport;
        //                tseg.FareBasis = seg.FareBasisCode;
        //                tseg.SequenceInOD = (byte)seg.Index;
        //                seg.Duration = FlightHelpers.CalculateDuration(seg);
        //                targetBookingObject.Segments.Add(tseg);
        //            }
        //            targetBookingObject.ProductObject = selectedOption.ProductObject;
        //            targetBookingObject.ProductObject.NativeBookingObject = targetBookingObject;
        //            foreach (T_Segment seg2 in targetBookingObject.Segments)
        //            {
        //                T_FlightSegment flightSegment = new T_FlightSegment();
        //                flightSegment.Id = System.Guid.NewGuid();
        //                flightSegment.Origin = seg2.OriginCode;
        //                flightSegment.Destination = seg2.DestinationCode;
        //                flightSegment.DepartureDay = seg2.DepartureDateTime.Date;
        //                flightSegment.DepartureTime = seg2.DepartureDateTime.TimeOfDay;
        //                flightSegment.ArrivalDay = seg2.ArrivalDateTime.Date;
        //                flightSegment.ArrivalTime = seg2.ArrivalDateTime.TimeOfDay;
        //                flightSegment.BookingClass = seg2.BookingClass;
        //                flightSegment.FlightNo = seg2.FlightNumber;
        //                flightSegment.OD_Origin = seg2.OD_OriginCode;
        //                flightSegment.OD_Destination = seg2.OD_DestinationCode;
        //                flightSegment.SequenceInOD = (int)seg2.SequenceInOD;
        //                flightSegment.SeatCount = targetBookingObject.BookingItems.Count;
        //                flightSegment.ProductId = targetBookingObject.ProductId;
        //                flightSegment.MarketingAirline = seg2.MarketingAirline;
        //                flightSegment.OperatingAirline = seg2.OperatingAirline;
        //                flightSegment.FareBasis = seg2.FareBasis;
        //                flightSegment.FareType = seg2.FareType;
        //                if (targetBookingObject.ProductObject.ShoppingFileObject != null)
        //                {
        //                    targetBookingObject.ProductObject.ShoppingFileObject._FlightSegments.Add(flightSegment);
        //                }
        //                else
        //                {
        //                    targetBookingObject.ProductObject.ShoppingFileObject_ForOption._FlightSegments.Add(flightSegment);
        //                }
        //            }
        //            return targetBookingObject;
        //        }
        //        public static T_Product BuildProduct(Recommendation box, int providerId)
        //        {
        //            T_Product product = null;
        //            if (box.ProductObject != null)
        //            {
        //                product = box.ProductObject;
        //            }
        //            else
        //            {
        //                product = new T_Product();
        //            }
        //            if (product.Id == System.Guid.Empty)
        //            {
        //                product.Id = System.Guid.NewGuid();
        //            }
        //            if (string.IsNullOrWhiteSpace(product.LocalProductId))
        //            {
        //                product.LocalProductId = product.Id.ToString();
        //            }
        //            product.ProductType = E_ProductTypes.Flight;
        //            product.ProviderId = providerId;
        //            product.ContractorBusiness = box.ContractorBusiness;
        //            product.Status = E_ProductStatuses.NotLoaded;
        //            FlightHelpers.FillProductFares(product, box);
        //            if (box.ReturnFlights != null && box.ReturnFlights.Count > 0)
        //            {
        //                if (box.OtherFlights != null && box.OtherFlights.Count > 0)
        //                {
        //                    product.Flight_TripType = "MP";
        //                }
        //                else
        //                {
        //                    product.Flight_TripType = "RT";
        //                }
        //            }
        //            else
        //            {
        //                product.Flight_TripType = "OW";
        //            }
        //            product.LastCommand = "INIT";
        //            product.LastApprovedCommand = "INIT";
        //            product.VATFlag = "INT";
        //            product.IsReservationEnabled = new bool?(true);
        //            product.IsETicketEnabled = new bool?(true);
        //            switch (providerId)
        //            {
        //                case 150:
        //                    product.SfRef_Code = "HITCHHIKER_INTL";
        //                    goto IL_1B9;
        //                case 151:
        //                    break;
        //                default:
        //                    if (providerId != 156)
        //                    {
        //                        if (providerId != 161)
        //                        {
        //                            product.SfRef_Code = "AMADEUS_FLEX";
        //                            goto IL_1B9;
        //                        }
        //                        product.SfRef_Code = "AER_INTL";
        //                        goto IL_1B9;
        //                    }
        //                    break;
        //            }
        //            product.SfRef_Code = "AMADEUS_FLEX";
        //        IL_1B9:
        //            product.SfRef_IsFlex = new bool?(true);
        //            product.SfRef_IsFix = new bool?(false);
        //            product.SfRef_IsCommission = new bool?(false);
        //            product.SfRef_Amount = null;
        //            int paxSeq = 1;
        //            foreach (PaxInformation paxFare in box.FareInfo.Paxes)
        //            {
        //                paxFare.ProductItemIds = new System.Collections.Generic.List<System.Guid>();
        //                for (int i = 0; i < paxFare.PaxCount; i++)
        //                {
        //                    T_ProductItem item = new T_ProductItem();
        //                    item.Id = System.Guid.NewGuid();
        //                    item.ShoppingFileId = product.ShoppingFileId;
        //                    paxFare.ProductItemIds.Add(item.Id);
        //                    item.LocalProductItemId = item.Id.ToString();
        //                    FlightHelpers.FillProductItemFares(item, paxFare, box.FareInfo.Currency);
        //                    product.ProductItems.Add(item);
        //                    product.PaxReferences.Add(new T_PaxReference
        //                    {
        //                        Id = System.Guid.NewGuid(),
        //                        ShoppingFileId = product.ShoppingFileId,
        //                        ProductId = product.Id,
        //                        ProductItemId = item.Id,
        //                        LocalPassengerSequenceNo = (byte)paxSeq++,
        //                        LocalPassengerType = (byte)FlightHelpers.ConvertFromString(paxFare.PaxType),
        //                        LocalInterpretedPassengerType = FlightHelpers.ConvertFromString(paxFare.PaxType)
        //                    });
        //                }
        //            }
        //            foreach (Flight dept in box.DepartureFlights)
        //            {
        //                FlightHelpers.FillBaggageInfo(dept, product);
        //            }
        //            if (box.ReturnFlights != null && box.ReturnFlights.Count > 0)
        //            {
        //                foreach (Flight ret in box.DepartureFlights)
        //                {
        //                    FlightHelpers.FillBaggageInfo(ret, product);
        //                }
        //            }
        //            if (box.OtherFlights != null && box.OtherFlights.Count > 0)
        //            {
        //                foreach (Flight kit in box.OtherFlights)
        //                {
        //                    FlightHelpers.FillBaggageInfo(kit, product);
        //                }
        //            }
        //            foreach (Flight dept in box.DepartureFlights)
        //            {
        //                dept.FlightId = System.Guid.NewGuid();
        //            }
        //            if (box.ReturnFlights != null && box.ReturnFlights.Count > 0)
        //            {
        //                foreach (Flight ret in box.ReturnFlights)
        //                {
        //                    ret.FlightId = System.Guid.NewGuid();
        //                }
        //            }
        //            if (box.OtherFlights != null && box.OtherFlights.Count > 0)
        //            {
        //                foreach (Flight other in box.OtherFlights)
        //                {
        //                    other.FlightId = System.Guid.NewGuid();
        //                }
        //            }
        //            string currency = box.FareInfo.Currency;
        //            if (currency != "TRY")
        //            {
        //                box.FareInfo.Currency = "TRY";
        //                foreach (PaxInformation pax in box.FareInfo.Paxes)
        //                {
        //                    pax.PaxFare = CurrencyController.ConvertMoney(currency, pax.PaxFare, new int?(2));
        //                    pax.PaxTax = CurrencyController.ConvertMoney(currency, pax.PaxTax, new int?(2));
        //                    pax.PaxSubTotal = CurrencyController.ConvertMoney(currency, pax.PaxSubTotal, new int?(2));
        //                }
        //                box.FareInfo.TotalFare = CurrencyController.ConvertMoney(currency, box.FareInfo.TotalFare, new int?(2));
        //                box.FareInfo.TotalTax = CurrencyController.ConvertMoney(currency, box.FareInfo.TotalTax, new int?(2));
        //                box.FareInfo.GrandTotal = CurrencyController.ConvertMoney(currency, box.FareInfo.GrandTotal, new int?(2));
        //            }
        //            box.ProductObject = product;
        //            product.NativeOptionObject = box;
        //            return product;
        //        }
        //        public static void FillProductFares(T_Product product, Recommendation box)
        //        {
        //            box.FareInfo.ProductId = product.Id;
        //            product.Buying_Currency = box.FareInfo.Currency;
        //            product.Buying_BaseFare = box.FareInfo.TotalFare;
        //            product.Buying_ServiceFee = 0m;
        //            product.Buying_Taxes = box.FareInfo.TotalTax;
        //        }
        //        public static void FillProductItemFares(T_ProductItem productItem, PaxInformation paxFare, string currency)
        //        {
        //            productItem.Buying_BaseFare = paxFare.PaxFare;
        //            productItem.Buying_Taxes = paxFare.PaxTax;
        //            productItem.Buying_ServiceFee = 0m;
        //            productItem.Buying_Currency = currency;
        //        }
        //        public static T_Booking BuildBookingRecommendationObject(int providerId, Recommendation box, System.Collections.Generic.Dictionary<string, object> boxFlights, T_Booking targetBookingObject)
        //        {
        //            targetBookingObject.ShoppingFileId = box.ProductObject.ShoppingFileId;
        //            targetBookingObject.ProductId = box.ProductObject.Id;
        //            targetBookingObject.Status = E_ProductStatuses.Option;
        //            targetBookingObject.ProviderId = providerId;
        //            targetBookingObject.T_LastSessionId = box.ProductObject.ShoppingFileObject_ForOption.T_LastSessionId;
        //            targetBookingObject.T_LastTransactionId = box.ProductObject.ShoppingFileObject_ForOption.T_LastTransactionId;
        //            if (box.ReturnFlights != null && box.ReturnFlights.Count > 0)
        //            {
        //                if (box.OtherFlights != null && box.OtherFlights.Count > 0)
        //                {
        //                    targetBookingObject.TripType = E_TripTypes.MultiCity;
        //                }
        //                else
        //                {
        //                    targetBookingObject.TripType = E_TripTypes.RoundTrip;
        //                }
        //            }
        //            else
        //            {
        //                targetBookingObject.TripType = E_TripTypes.OneWay;
        //            }
        //            targetBookingObject.PnrNumber = null;
        //            targetBookingObject.RelatedBookingId = null;
        //            targetBookingObject.ReservationDateTime = null;
        //            targetBookingObject.BookingDateTime = null;
        //            targetBookingObject.CancelDateTime = null;
        //            targetBookingObject.ExpirationDateTime = null;
        //            foreach (T_ProductItem item in box.ProductObject.ProductItems.ToList<T_ProductItem>())
        //            {
        //                T_BookingItem newItem = new T_BookingItem();
        //                newItem.ProductId = targetBookingObject.ProductId;
        //                newItem.ProductItemId = item.Id;
        //                newItem.TicketNumber = null;
        //                newItem.PassengerType = (E_PassengerTypes)item.PaxReferences.First<T_PaxReference>().LocalPassengerType;
        //                targetBookingObject.BookingItems.Add(newItem);
        //            }
        //            int deptSegmentOrder = 1;
        //            Flight Departure = box.DepartureFlights.FirstOrDefault((Flight d) => d.FlightId == (System.Guid)boxFlights["SubOption1"]);
        //            foreach (Trevoo.Entities.Recommendation.Segment segment in Departure.Segments)
        //            {
        //                T_Segment deptSegment = new T_Segment();
        //                deptSegment.ProductId = targetBookingObject.ProductId;
        //                deptSegment.OriginCode = segment.DepartureAirport;
        //                deptSegment.DestinationCode = segment.ArrivalAirport;
        //                deptSegment.DepartureDateTime = new System.DateTimeOffset(segment.DepartureDate + segment.DepartureTime);
        //                deptSegment.ArrivalDateTime = new System.DateTimeOffset(segment.ArrivalDate + segment.ArrivalTime);
        //                deptSegment.BookingClass = segment.BookingClass;
        //                deptSegment.FlightNumber = segment.MarketingAirline + segment.FlightNumber;
        //                deptSegment.MarketingAirline = segment.MarketingAirline;
        //                deptSegment.OperatingAirline = segment.OperatingAirline;
        //                deptSegment.OD_OriginCode = Departure.Segments.First<Trevoo.Entities.Recommendation.Segment>().DepartureAirport;
        //                deptSegment.OD_DestinationCode = Departure.Segments.Last<Trevoo.Entities.Recommendation.Segment>().ArrivalAirport;
        //                deptSegment.SequenceInOD = (byte)deptSegmentOrder++;
        //                deptSegment.FareBasis = segment.FareBasis;
        //                deptSegment.FareType = segment.FareType.FirstOrDefault<string>();
        //                targetBookingObject.Segments.Add(deptSegment);
        //            }
        //            if (box.ReturnFlights != null)
        //            {
        //                int retSegmentOrder = 1;
        //                Flight Return = box.ReturnFlights.FirstOrDefault((Flight d) => d.FlightId == (System.Guid)boxFlights["SubOption2"]);
        //                if (Return != null)
        //                {
        //                    foreach (Trevoo.Entities.Recommendation.Segment segment in Return.Segments)
        //                    {
        //                        T_Segment retSegment = new T_Segment();
        //                        retSegment.ProductId = targetBookingObject.ProductId;
        //                        retSegment.OriginCode = segment.DepartureAirport;
        //                        retSegment.DestinationCode = segment.ArrivalAirport;
        //                        retSegment.DepartureDateTime = new System.DateTimeOffset(segment.DepartureDate + segment.DepartureTime);
        //                        retSegment.ArrivalDateTime = new System.DateTimeOffset(segment.ArrivalDate + segment.ArrivalTime);
        //                        retSegment.BookingClass = segment.BookingClass;
        //                        retSegment.FlightNumber = segment.MarketingAirline + segment.FlightNumber;
        //                        retSegment.MarketingAirline = segment.MarketingAirline;
        //                        retSegment.OperatingAirline = segment.OperatingAirline;
        //                        retSegment.OD_OriginCode = Return.Segments.First<Trevoo.Entities.Recommendation.Segment>().DepartureAirport;
        //                        retSegment.OD_DestinationCode = Return.Segments.Last<Trevoo.Entities.Recommendation.Segment>().ArrivalAirport;
        //                        retSegment.SequenceInOD = (byte)retSegmentOrder++;
        //                        retSegment.FareBasis = segment.FareBasis;
        //                        retSegment.FareType = segment.FareType.FirstOrDefault<string>();
        //                        targetBookingObject.Segments.Add(retSegment);
        //                    }
        //                }
        //            }
        //            if (box.OtherFlights != null)
        //            {
        //                int otherSegmentOrder = 1;
        //                Flight Other = box.OtherFlights.FirstOrDefault((Flight d) => d.FlightId == (System.Guid)boxFlights["SubOption3"]);
        //                if (Other != null)
        //                {
        //                    foreach (Trevoo.Entities.Recommendation.Segment segment in Other.Segments)
        //                    {
        //                        T_Segment othSegment = new T_Segment();
        //                        othSegment.ProductId = targetBookingObject.ProductId;
        //                        othSegment.OriginCode = segment.DepartureAirport;
        //                        othSegment.DestinationCode = segment.ArrivalAirport;
        //                        othSegment.DepartureDateTime = new System.DateTimeOffset(segment.DepartureDate + segment.DepartureTime);
        //                        othSegment.ArrivalDateTime = new System.DateTimeOffset(segment.ArrivalDate + segment.ArrivalTime);
        //                        othSegment.BookingClass = segment.BookingClass;
        //                        othSegment.FlightNumber = segment.MarketingAirline + segment.FlightNumber;
        //                        othSegment.MarketingAirline = segment.MarketingAirline;
        //                        othSegment.OperatingAirline = segment.OperatingAirline;
        //                        othSegment.OD_OriginCode = Other.Segments.First<Trevoo.Entities.Recommendation.Segment>().DepartureAirport;
        //                        othSegment.OD_DestinationCode = Other.Segments.Last<Trevoo.Entities.Recommendation.Segment>().ArrivalAirport;
        //                        othSegment.SequenceInOD = (byte)otherSegmentOrder++;
        //                        othSegment.FareBasis = segment.FareBasis;
        //                        othSegment.FareType = segment.FareType.FirstOrDefault<string>();
        //                        targetBookingObject.Segments.Add(othSegment);
        //                    }
        //                }
        //            }
        //            targetBookingObject.ProductObject = box.ProductObject;
        //            targetBookingObject.ProductObject.NativeBookingObject = targetBookingObject;
        //            foreach (T_Segment seg in targetBookingObject.Segments.ToList<T_Segment>())
        //            {
        //                T_FlightSegment flightSegment = new T_FlightSegment();
        //                flightSegment.Id = System.Guid.NewGuid();
        //                flightSegment.Origin = seg.OriginCode;
        //                flightSegment.Destination = seg.DestinationCode;
        //                flightSegment.DepartureDay = seg.DepartureDateTime.Date;
        //                flightSegment.DepartureTime = seg.DepartureDateTime.TimeOfDay;
        //                flightSegment.ArrivalDay = seg.ArrivalDateTime.Date;
        //                flightSegment.ArrivalTime = seg.ArrivalDateTime.TimeOfDay;
        //                flightSegment.BookingClass = seg.BookingClass;
        //                flightSegment.FlightNo = seg.FlightNumber;
        //                flightSegment.OD_Origin = seg.OD_OriginCode;
        //                flightSegment.OD_Destination = seg.OD_DestinationCode;
        //                flightSegment.SequenceInOD = (int)seg.SequenceInOD;
        //                flightSegment.SeatCount = targetBookingObject.BookingItems.Count;
        //                flightSegment.ProductId = targetBookingObject.ProductId;
        //                flightSegment.MarketingAirline = seg.MarketingAirline;
        //                flightSegment.OperatingAirline = seg.OperatingAirline;
        //                flightSegment.FareBasis = seg.FareBasis;
        //                flightSegment.FareType = seg.FareType;
        //                if (targetBookingObject.ProductObject.ShoppingFileObject != null)
        //                {
        //                    targetBookingObject.ProductObject.ShoppingFileObject._FlightSegments.Add(flightSegment);
        //                }
        //                else
        //                {
        //                    targetBookingObject.ProductObject.ShoppingFileObject_ForOption._FlightSegments.Add(flightSegment);
        //                }
        //            }
        //            return targetBookingObject;
        //        }
        //        public static MatrixCell[,] ShowMatrixOfBoxes(Recommendation[] recommendations)
        //        {
        //            string flightType = "OW";
        //            if (recommendations.First<Recommendation>().ReturnFlights != null && recommendations.First<Recommendation>().ReturnFlights.Count > 0)
        //            {
        //                if (recommendations.First<Recommendation>().OtherFlights != null && recommendations.First<Recommendation>().OtherFlights.Count > 0)
        //                {
        //                    flightType = "MP";
        //                }
        //                else
        //                {
        //                    flightType = "RT";
        //                }
        //            }
        //            System.Collections.Generic.IEnumerable<string> AllAirlinesInRecommendations = (
        //                from rec in recommendations
        //                select rec.DepartureFlights.First<Flight>().Segments.First<Trevoo.Entities.Recommendation.Segment>().MarketingAirline).Distinct<string>();
        //            int AirlineCount = AllAirlinesInRecommendations.Count<string>();
        //            if (AirlineCount > 9)
        //            {
        //                AllAirlinesInRecommendations = AllAirlinesInRecommendations.Take(9);
        //                AirlineCount = 9;
        //            }
        //            MatrixCell[,] WholeMatrix = new MatrixCell[AirlineCount, 3];
        //            for (int i = 0; i < AirlineCount; i++)
        //            {
        //                WholeMatrix[i, 0] = new MatrixCell
        //                {
        //                    Column = AllAirlinesInRecommendations.ElementAt(i).ToString()
        //                };
        //            }
        //            System.Collections.Generic.List<Recommendation> NonStopBoxes = new System.Collections.Generic.List<Recommendation>();
        //            if (flightType == "OW")
        //            {
        //                NonStopBoxes = (
        //                    from rec in recommendations
        //                    where rec.DepartureFlights.First<Flight>().Segments.Count == 1
        //                    select rec).ToList<Recommendation>();
        //            }
        //            else if (flightType == "RT")
        //            {
        //                NonStopBoxes = (
        //                    from rec in recommendations
        //                    where rec.DepartureFlights.First<Flight>().Segments.Count == 1 && rec.ReturnFlights.First<Flight>().Segments.Count == 1
        //                    select rec).ToList<Recommendation>();
        //            }
        //            else if (flightType == "MP")
        //            {
        //                NonStopBoxes = (
        //                    from rec in recommendations
        //                    where rec.DepartureFlights.First<Flight>().Segments.Count == 1 && rec.ReturnFlights.First<Flight>().Segments.Count == 1 && rec.OtherFlights.First<Flight>().Segments.Count == 1
        //                    select rec).ToList<Recommendation>();
        //            }
        //            for (int j = 0; j < AirlineCount; j++)
        //            {
        //                string airline = WholeMatrix[j, 0].Column;
        //                if (NonStopBoxes.Count > 0)
        //                {
        //                    Recommendation relatedBox = NonStopBoxes.FirstOrDefault((Recommendation x) => x.DepartureFlights.First<Flight>().Segments.First<Trevoo.Entities.Recommendation.Segment>().MarketingAirline == airline);
        //                    MatrixCell[,] arg_2AD_0 = WholeMatrix;
        //                    int arg_2AD_1 = j;
        //                    int arg_2AD_2 = 1;
        //                    MatrixCell arg_2AD_3;
        //                    if (relatedBox == null)
        //                    {
        //                        arg_2AD_3 = new MatrixCell();
        //                    }
        //                    else
        //                    {
        //                        MatrixCell matrixCell = new MatrixCell();
        //                        matrixCell.Column = airline;
        //                        matrixCell.BoxId = relatedBox.ProductObject.Id;
        //                        matrixCell.CellPrice = relatedBox.FareInfo.Paxes.Max((PaxInformation x) => x.PaxSubTotal);
        //                        arg_2AD_3 = matrixCell;
        //                    }
        //                    arg_2AD_0[arg_2AD_1, arg_2AD_2] = arg_2AD_3;
        //                }
        //                else
        //                {
        //                    WholeMatrix[j, 1] = new MatrixCell();
        //                }
        //            }
        //            System.Collections.Generic.List<Recommendation> WithStopBoxes = new System.Collections.Generic.List<Recommendation>();
        //            if (flightType == "OW")
        //            {
        //                WithStopBoxes = (
        //                    from rec in recommendations
        //                    where rec.DepartureFlights.First<Flight>().Segments.Count > 1
        //                    select rec).ToList<Recommendation>();
        //            }
        //            else if (flightType == "RT")
        //            {
        //                WithStopBoxes = (
        //                    from rec in recommendations
        //                    where rec.DepartureFlights.First<Flight>().Segments.Count > 1 || rec.ReturnFlights.First<Flight>().Segments.Count > 1
        //                    select rec).ToList<Recommendation>();
        //            }
        //            else if (flightType == "MP")
        //            {
        //                WithStopBoxes = (
        //                    from rec in recommendations
        //                    where rec.DepartureFlights.First<Flight>().Segments.Count > 1 || rec.ReturnFlights.First<Flight>().Segments.Count > 1 || rec.OtherFlights.First<Flight>().Segments.Count > 1
        //                    select rec).ToList<Recommendation>();
        //            }
        //            for (int k = 0; k < AirlineCount; k++)
        //            {
        //                string airline = WholeMatrix[k, 0].Column;
        //                if (WithStopBoxes.Count > 0)
        //                {
        //                    Recommendation relatedBox = WithStopBoxes.FirstOrDefault((Recommendation x) => x.DepartureFlights.First<Flight>().Segments.First<Trevoo.Entities.Recommendation.Segment>().MarketingAirline == airline);
        //                    MatrixCell[,] arg_48B_0 = WholeMatrix;
        //                    int arg_48B_1 = k;
        //                    int arg_48B_2 = 2;
        //                    MatrixCell arg_48B_3;
        //                    if (relatedBox == null)
        //                    {
        //                        arg_48B_3 = new MatrixCell();
        //                    }
        //                    else
        //                    {
        //                        MatrixCell matrixCell2 = new MatrixCell();
        //                        matrixCell2.Column = airline;
        //                        matrixCell2.BoxId = relatedBox.ProductObject.Id;
        //                        matrixCell2.CellPrice = relatedBox.FareInfo.Paxes.Max((PaxInformation x) => x.PaxSubTotal);
        //                        arg_48B_3 = matrixCell2;
        //                    }
        //                    arg_48B_0[arg_48B_1, arg_48B_2] = arg_48B_3;
        //                }
        //                else
        //                {
        //                    WholeMatrix[k, 2] = new MatrixCell();
        //                }
        //            }
        //            return WholeMatrix;
        //        }
        //        public static string CalculateDuration(Trevoo.Entities.Recommendation.Segment seg)
        //        {
        //            string duration = "0:0";
        //            try
        //            {
        //                Airport departure = Application.GetAirportByCode(seg.DepartureAirport);
        //                Airport arrival = Application.GetAirportByCode(seg.ArrivalAirport);
        //                duration = (seg.ArrivalDate.Add(seg.ArrivalTime) - seg.DepartureDate.Add(seg.DepartureTime)).Days * 24 + (seg.ArrivalDate.Add(seg.ArrivalTime) - seg.DepartureDate.Add(seg.DepartureTime)).Hours + ":" + (seg.ArrivalDate.Add(seg.ArrivalTime) - seg.DepartureDate.Add(seg.DepartureTime)).Minutes;
        //                if (departure.Country != arrival.Country)
        //                {
        //                    System.DateTime start = seg.DepartureDate.Add(seg.DepartureTime).AddHours(-(double)departure.UTCDifference.GetValueOrDefault());
        //                    System.DateTime end = seg.ArrivalDate.Add(seg.ArrivalTime).AddHours(-(double)arrival.UTCDifference.GetValueOrDefault());
        //                    bool flag = 1 == 0;
        //                    duration = (end - start).Days * 24 + (end - start).Hours + ":" + (end - start).Minutes;
        //                }
        //            }
        //            catch (System.Exception)
        //            {
        //            }
        //            string[] fligthDuration = duration.Split(new char[]
        //            {
        //                ':'
        //            });
        //            if (fligthDuration[0].Length == 1)
        //            {
        //                fligthDuration[0] = "0" + fligthDuration[0];
        //            }
        //            if (fligthDuration[1].Length == 1)
        //            {
        //                fligthDuration[1] = "0" + fligthDuration[1];
        //            }
        //            return fligthDuration[0] + ":" + fligthDuration[1];
        //        }
        //        private static string GetBaggageInfoInALine(Flight fligth)
        //        {
        //            string result = string.Empty;
        //            if (fligth.FreeBaggageAllowance != null && fligth.FreeBaggageAllowance.FBA != null)
        //            {
        //                foreach (PaxBaggageAllowance itemFBA in fligth.FreeBaggageAllowance.FBA)
        //                {
        //                    result = result + itemFBA.PaxFBA.Allowance + itemFBA.PaxFBA.Unit + "/";
        //                }
        //                if (fligth.FreeBaggageAllowance.FBA.Count > 0)
        //                {
        //                    result = result.Substring(0, result.Length - 2);
        //                }
        //            }
        //            return result.Trim();
        //        }
        //        private static void FillBaggageInfo(Flight flight, T_Product product)
        //        {
        //            foreach (T_ProductItem itemProd in product.ProductItems)
        //            {
        //                itemProd.Flight_Baggage = FlightHelpers.GetBaggageInfoInALine(flight);
        //            }
        //        }
    }
}