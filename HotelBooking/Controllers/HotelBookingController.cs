using System.Runtime.CompilerServices;
using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelBookingController
{
    
    private readonly CqrsDispatcher _dispatcher;

    // public void initController(Hotel hotel)
    // {
    //     _dispatcher = new CqrsDispatcher(hotel.rooms);
    // }
    
    public HotelBookingController(string name, List<Room> rooms, string city, string country, int rating)
    {
        _dispatcher = new CqrsDispatcher(rooms);
    }

    /// <summary>
    ///     Find valid hotel rooms for people
    /// </summary>
    /// <param name="adults">Number of adult people</param>
    /// <param name="children">Number of children</param>
    /// <param name="budget">Budget for rooms</param>
    public List<Room> GetValidRooms(int adults, int children, int budget = 0)
    {
        return _dispatcher.Dispatch(adults, children, budget);
    }
    
    /// <summary>
    ///     Find valid hotel rooms for people
    /// </summary>
    /// <param name="budget">Budget for room(s)</param>
    public List<Room> GetValidRooms(int budget)
    {
        return _dispatcher.Dispatch(budget);
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