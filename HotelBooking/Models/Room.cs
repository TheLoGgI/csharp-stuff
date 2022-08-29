namespace HotelBooking.Models;

public class Room
{
    public int nr { get; set; }
    public int floor { get; set; }
    public bool isDouble { get; set; }
    public int hasRoomFor { get; set; }
    public float price { get; set; }
    public bool isBooked { get; set; }
}

