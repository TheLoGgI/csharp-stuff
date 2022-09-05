using HotelBooking.Models;
using HotelBooking.Repositories;

namespace HotelBooking.Queries;

public class GetAvaliableRoomsQuery
{
    
}


public class GetAvaliableRoomsQueryHandler
{
    private readonly IHotelRepository _hotelRepository;

    public GetAvaliableRoomsQueryHandler(List<Room> rooms)
    {
        _hotelRepository = new HotelRepository(rooms);
    }
    
    public List<Room> Handle()
    {
        
        return _hotelRepository.GetAvailableRooms();

    }
}