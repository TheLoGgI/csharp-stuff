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
        var roomsWithValidBudget = _collection.Where(room =>
        {
            if (room.isBooked) return false;
            return  budget <= room.price; 

        }).ToList();        

        return roomsWithValidBudget;
    }
    
    public List<Room> GetValidRooms(int adults, int children, int? budget)
    {
        Console.WriteLine("Adults: " + adults + " - " + "children: " + children + " - " + "budget: " + budget);
            var peopleInTotal = adults + children;
        Console.WriteLine("peopleInTotal: " + peopleInTotal);
            
            var validRooms = _collection.Where(room =>
            {
                if (room.isBooked) return false;
                if (budget != null) return peopleInTotal <= room.hasRoomFor && budget <= room.price; 
                
                return peopleInTotal <= room.hasRoomFor;

            }).ToList();

            return validRooms;
       
    }

    


    public Room BookRoom(int roomNr, int floor)
    {
        throw new NotImplementedException();
    }

    public List<Room> GetAvailableRooms()
    {
        throw new NotImplementedException();
    }
}