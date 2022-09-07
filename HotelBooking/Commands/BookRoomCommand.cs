using HotelBooking;
using HotelBooking.Models;
using HotelBooking.Repositories;

namespace HotelBooking.Commands;

public class BookRoomCommand
{
    public Room Room { get; }

    public BookRoomCommand(Room room)
    {
        // Console.WriteLine("Adults: " + adults + " - " + "children: " + children + " - " + "budget: " + budget);
        Room = room;
        
        
    }
}


public class BookRoomCommandHandler
{
    private readonly IHotelRepository _hotelRepository;

    public BookRoomCommandHandler(List<Room> rooms)
    {
        _hotelRepository = new HotelRepository(rooms);
    }

    public Room Handle(BookRoomCommand query)
    {
        Console.WriteLine(query);

        return _hotelRepository.BookRoom(query.Room); 
    }
}
