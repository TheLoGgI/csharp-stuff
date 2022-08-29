using HotelBooking.Models;
using HotelBooking.Repositories;

namespace HotelBooking;
public class CqrsDispatcher
{
    private readonly List<Room> _collection;
    public CqrsDispatcher(List<Room> rooms)
    {
        _collection = rooms;
        Console.WriteLine($"Valid rooms Total rooms: {rooms}");
        foreach (var room in rooms)
        {
        Console.WriteLine( $" #{room.nr} on floor {room.floor}, has room for {room.hasRoomFor} people. price {room.price}");
            
        }
        
    }
    
    public List<Room> Dispatch(int adults, int children, int budget = 0) /*where T : class*/
    {

        return new GetValidRoomsQueryHandler(_collection).Handle(adults, children, budget);

    }
    public List<Room> Dispatch(int budget)
    {

        return new GetValidRoomsQueryHandler(_collection).Handle(budget);

    }

}

public class GetValidRoomsQueryHandler
{
    private readonly IHotelRepository _hotelRepository;

    public GetValidRoomsQueryHandler(List<Room> rooms)
    {
        _hotelRepository = new HotelRepository(rooms);
    }
    
    public List<Room> Handle(int adults, int children, int budget = 0)
    {

        return _hotelRepository.GetValidRooms(adults, children, budget);
    }
    
    public List<Room> Handle(int budget)
    {
        return _hotelRepository.GetValidRooms(budget);
    }
}