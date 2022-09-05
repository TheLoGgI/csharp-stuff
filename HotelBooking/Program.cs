using HotelBooking.Models;
using HotelBooking.Repositories;

namespace HotelBooking;

public class Program
{

    
    public static List<Room> hotelRooms = new List<Room>()
    {
        new()
        {
            nr = 1,
            floor = 1,
            isDouble = false,
            hasRoomFor = 1,
            price = 499,
            isBooked = false
        },
        new()
        {
            nr = 2,
            floor = 1,
            isDouble = true,
            hasRoomFor = 3,
            price = 849,
            isBooked = false
        },
        new()
        {
            nr = 3,
            floor = 1,
            isDouble = false,
            hasRoomFor = 1,
            price = 499,
            isBooked = false
        },
        new()
        {
            nr = 4,
            floor = 1,
            isDouble = true,
            hasRoomFor = 2,
            price = 849,
            isBooked = false
        },
        new()
        {
            nr = 5,
            floor = 1,
            isDouble = true,
            hasRoomFor = 2,
            price = 849,
            isBooked = true
        },
    };

    public Program()
    {

    }
    public static void Main()
    {
        // var hotel = new Hotel()
        // {
        //     name = "London Hotel",
        //     rooms = hotelRooms,
        //     city = "London",
        //     country = "England",
        //     rating = 4,
        // };
        
        var hotel = new Hotel("London Hotel",
            hotelRooms,
            "London",
            "England",
            4);


        // var validRooms = hotel.GetValidRooms(2, 1);
        
        // Method 'GetValidRooms' has 3 parameter(s) but is invoked with 1 argument(s)
        var validRoomsWithBudet = hotel.GetValidRooms(500);
        foreach (var room in validRoomsWithBudet)
        {
            Console.WriteLine( $" #{room.nr} on floor {room.floor}, has room for {room.hasRoomFor} people. price {room.price}");
            
        }
        
        // var avaliableHotelRooms = hotel.av

        // HotelRepository repository = new HotelRepository(domainModel);
        // repository.FindValidRooms(2, 0);

        //     var LondonHotel = new Hotel()
        //         { name = "London Hotel", city = "London", country = "England", rating = 4, rooms = 
        // };

    }
}


// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
//
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
//
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();
