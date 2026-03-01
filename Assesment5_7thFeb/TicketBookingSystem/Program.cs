using System;
using System.Threading.Tasks;
using TicketBookingSystem.Services;

class Program
{
    static void Main()
    {
        var bookingService = new SeatBookingService(totalSeats: 1);

        Parallel.Invoke(
            () => TryBook(bookingService, 1, "User-A"),
            () => TryBook(bookingService, 1, "User-B"),
            () => TryBook(bookingService, 1, "User-C")
        );

        Console.ReadLine();
    }

    static void TryBook(SeatBookingService service, int seatNo, string userId)
    {
        bool success = service.BookSeat(seatNo, userId);
        Console.WriteLine($"{userId} booking seat {seatNo}: {(success ? "SUCCESS" : "FAILED")}");
    }
}
