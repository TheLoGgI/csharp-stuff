using HotelBooking.Models;

namespace HotelBooking;

public interface IHotelRepository
{
    public List<Room> GetValidRooms(int adults, int children, int budget);

    public Room BookRoom(int roomNr, int floor);

    public List<Room> AvailableRooms();
    
    
}