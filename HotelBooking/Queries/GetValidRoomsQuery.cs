using HotelBooking.Models;
using HotelBooking.Repositories;

namespace HotelBooking.Queries;

public class GetValidRoomsQuery
{
    public int? Adults { get; }
    public int? Children { get; }
    public int? Budget { get; }
    
    public GetValidRoomsQuery(int? adults, int? children, int? budget)
    {
        Adults = adults;
        Children = children;
        Budget = budget;

        if (!(adults != null && children != null) || (budget != null))
            throw new ArgumentException(
                "Must either provide both adults, children and optionally budget, or only budget");
    }
}


public class GetValidRoomsQueryHandler
{
    private readonly IHotelRepository _hotelRepository;

    public GetValidRoomsQueryHandler(List<Room> rooms)
    {
        _hotelRepository = new HotelRepository(rooms);
    }
    
    public List<Room> Handle(GetValidRoomsQuery query)
    {
        
        if (query.Adults.HasValue && query.Adults != null && query.Children != null)
        {
            // Argument type 'System.Nullable<int>' is not assignable to parameter type 'int'
            return _hotelRepository.GetValidRooms(query.Adults, query.Children, query.Budget);
        }
        else
        {
            // Argument type 'System.Nullable<int>' is not assignable to parameter type 'int'
            return _hotelRepository.GetValidRooms(query.Budget);
        }
    }
}

// public class GetValidRoomsQueryHandler
// {
//     private readonly IHotelRepository _hotelRepository;
//
//     public GetValidRoomsQueryHandler(List<Room> rooms)
//     {
//         _hotelRepository = new HotelRepository(rooms);
//     }
//     
//     public List<Room> Handle(int? adults, int? children, int? budget)
//     {
//
//         return _hotelRepository.GetValidRooms(adults, children, budget);
//     }
//
// }