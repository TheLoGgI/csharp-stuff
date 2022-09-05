using System.Runtime.CompilerServices;
using HotelBooking.Models;
using HotelBooking.Queries;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelBookingController
{
    
    private readonly CqrsDispatcher _dispatcher;

    public HotelBookingController(string name, List<Room> rooms, string city, string country, int rating)
    {
        // var hotel = new Hotel(name,
        //     rooms,
        //     city,
        //     country,
        //     rating);
        
        _dispatcher = new CqrsDispatcher(rooms);
    }

    /// <summary>
    ///     Find valid hotel rooms for people
    /// </summary>
    /// <param name="adults">Number of adult people</param>
    /// <param name="children">Number of children</param>
    /// <param name="budget">Budget for rooms</param>
    public List<Room> GetValidRooms(int? adults, int? children, int? budget)
    {
        return _dispatcher.Dispatch(new GetValidRoomsQuery(adults, children, budget) );
    }
    
    public List<Room> GetAvailableRooms()
    {
        return _dispatcher.Dispatch(new GetAvaliableRoomsQuery());
    
    }

    /// <summary>
    ///     Find hotel rooms that match peoples expecstaions
    /// </summary>
    /// <param name="adults">Number of adult people</param>
    /// <param name="children">Number of children</param>
    /// <param name="budget">Budget for rooms</param>
    [HttpGet(Name = "GetHotelBooking")]
    public List<Room> Bookroom(int adults, int children, float budget = 0)
    {
        throw new NotImplementedException();
    }
    
    
    // public HoltalBookingController()
    // {
    //     
    // }



}