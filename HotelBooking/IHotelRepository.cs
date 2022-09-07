using HotelBooking.Models;

namespace HotelBooking;

public interface IHotelRepository
{
    public List<Room> GetValidRooms(int adults, int children, int? budget);
    public List<Room> GetValidRooms(int budget);

    public Room BookRoom(Room room);

    public List<Room> GetAvailableRooms();
    
    
}