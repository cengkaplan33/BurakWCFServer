using BurakWcfService.Air.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurakWcfService.Air.Services
{
    interface IAirService
    {
        AirportListResponse AirportList(AirportListRequest request);
        FareListResponse FareList(FareListRequest request);
        AvailabilityFightListResponse AvailabilityFightList(AvailabilityFightListRequest request);
        BookingRetrieveResponse Booking(BookingRetrieveRequest request);

        #region  AtlasJet Servisleri

        //addPassenger
        //addPassengerV2
        //airportsList +
        //availability +
        //availabilityV3
        //availabilityV4
        //booking +
        //cancelPnr
        //cancelPnrPrice
        //fares
        //jetmilInfo
        //limitInfo
        //maxServiceFee
        //openJawAirportsList
        //preBooking
        //psgrForTicketNumber
        //timetable
        //toAirportsList

        #endregion
    }
}