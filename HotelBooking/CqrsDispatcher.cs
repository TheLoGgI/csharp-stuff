using HotelBooking.Models;
using HotelBooking.Queries;
using HotelBooking.Repositories;

namespace HotelBooking;

public class CqrsDispatcher
{
    private readonly List<Room> _collection;
    public CqrsDispatcher(List<Room> rooms)
    {
        _collection = rooms;
        Console.WriteLine($"Valid rooms Total rooms: {rooms.Count}");
        // foreach (var room in rooms)
        // {
        //     Console.WriteLine( $" #{room.nr} on floor {room.floor}, has room for {room.hasRoomFor} people. price {room.price}");
        //
        // }

    }

    public List<Room> Dispatch(GetValidRoomsQuery query)
    {
        Console.WriteLine("testing");
        // Console.WriteLine("Adults: " + query.adults + " - " + "children: " + query.children + " - " + "budget: " + query.budget);
        return new GetValidRoomsQueryHandler(_collection).Handle(query);
    }
    public List<Room> Dispatch(GetAvaliableRoomsQuery query)
    {
        return new GetAvaliableRoomsQueryHandler(_collection).Handle();
    }
}


// public class CqrsDispatcher
// {
//     private readonly List<Room> _collection;
//     public CqrsDispatcher(List<Room> rooms)
//     {
//         _collection = rooms;
//         Console.WriteLine($"Valid rooms Total rooms: {rooms.Count}");
//         // foreach (var room in rooms)
//         // {
//         // Console.WriteLine( $" #{room.nr} on floor {room.floor}, has room for {room.hasRoomFor} people. price {room.price}");
//         //     
//         // }
//         
//     }
//     
//     public List<Room> Dispatch(string key, object payload) /*where T : class*/
//     {
//         
//         var dispatcher = 
//
//         return new GetValidRoomsQueryHandler(_collection).Handle(payload.adults, payload.children, payload.budet);
//     
//     }
//     
//     // public List<Room> Dispatch(int? adults, int? children, int? budget ) /*where T : class*/
//     // {
//     //
//     //     return new GetValidRoomsQueryHandler(_collection).Handle(adults, children, budget);
//     //
//     // }
//
// }
//
