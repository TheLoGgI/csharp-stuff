using System.Runtime.CompilerServices;
using HotelBooking.Commands;
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

        if (adults == null && children == null && budget != null)
        {
            return _dispatcher.Dispatch(new GetValidRoomsQuery(null, null,budget) );
        }
        
        Console.WriteLine("Adults: " + adults + " - " + "children: " + children + " - " + "budget: " + budget);
        return _dispatcher.Dispatch(new GetValidRoomsQuery(adults, children, budget) );
    }
    
    public List<Room> GetAvailableRooms()
    {
        return _dispatcher.Dispatch(new GetAvaliableRoomsQuery());
    
    }

    /// <summary>
    ///     Book room
    /// </summary>
    /// <param name="room">Room for booking</param>
    [HttpGet(Name = "GetHotelBooking")]
    public Room Bookroom(Room room)
    {
        return _dispatcher.Dispatch(new BookRoomCommand(room));
     
    }
    
    
    // public HoltalBookingController()
    // {
    //     
    // }



}