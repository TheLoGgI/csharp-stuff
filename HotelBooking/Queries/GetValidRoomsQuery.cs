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
        // Console.WriteLine("Adults: " + adults + " - " + "children: " + children + " - " + "budget: " + budget);
        Adults = adults;
        Children = children;
        Budget = budget;
        
        
        if (!(adults != null && children != null))
            throw new ArgumentException(
                "Must either provide both adults, children and optionally budget, or only budget");
        
        if (adults == null && children == null && budget != null)
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
        Console.WriteLine(query);
        
        // Console.WriteLine("Adults: " + adults + " - " + "children: " + children + " - " + "budget: " + budget);
        
        if (query.Adults != null && query.Children != null)
        {
            var adults = query.Adults ?? 0;
            var children = query.Children ?? 0;
            // Argument type 'System.Nullable<int>' is not assignable to parameter type 'int'
            var validRooms = _hotelRepository.GetValidRooms(adults, children, query.Budget);
            Console.WriteLine(validRooms.Count);
            return validRooms;
        }
        else
        {
            var budget = query.Budget ?? 0;
            // Argument type 'System.Nullable<int>' is not assignable to parameter type 'int'
            return _hotelRepository.GetValidRooms(budget);
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