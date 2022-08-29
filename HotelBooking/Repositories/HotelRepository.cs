using HotelBooking.Models;

namespace HotelBooking.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly List<Room> _collection;
    
    public HotelRepository(List<Room> collection)
    {
        _collection = collection;
    }
    
    public List<Room> GetValidRooms(int budget)
    {

        var validRooms = _collection.Where(room =>
        {
            if (room.isBooked) return false;
            return budget <= room.price;
        }).ToList();
        
        Console.WriteLine(validRooms);

        return validRooms;
    }

    
    public List<Room> GetValidRooms(int adults, int children, int budget = 0)
    {
        int peopleInTotal = adults + children;

        var validRooms = _collection.Where(room =>
        {
            if (room.isBooked) return false;
            return peopleInTotal <= room.hasRoomFor;

        }).ToList();
        
        Console.WriteLine(validRooms);

        return validRooms;
    }
    

    public Room BookRoom(int roomNr, int floor)
    {
        throw new NotImplementedException();
    }

    public List<Room> AvailableRooms()
    {
        throw new NotImplementedException();
    }
}