using HotelBooking.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Models;

public class Hotel : HotelBookingController
{
    public string name { get;  }
    public List<Room> rooms { get;  }
    public string country { get;  }
    public string city { get;  }
    public int rating { get;  }


    public Hotel(string name, List<Room> rooms, string city, string country, int rating) : base(name, rooms, city, country, rating)
    {
        // Console.WriteLine(hotel);
        // initController(hotel);
    
    }
    
    // public Hotel() : base(hotel.name, hotel.rooms, hotel.city, hotel.country, hotel.rating)
    // {
    //     Console.WriteLine(hotel);
    //     initController(hotel);
    // }
    
}

