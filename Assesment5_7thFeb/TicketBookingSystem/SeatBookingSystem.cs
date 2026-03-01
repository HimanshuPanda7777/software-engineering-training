using System.Collections.Generic;
using System.Linq;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Services
{
    public class SeatBookingService
    {
        private readonly Dictionary<int, Seat> _seats;
        private readonly object _lock = new object();

        public SeatBookingService(int totalSeats)
        {
            _seats = new Dictionary<int, Seat>();

            for (int i = 1; i <= totalSeats; i++)
            {
                _seats.Add(i, new Seat(i));
            }
        }

        public bool BookSeat(int seatNo, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId cannot be empty");

            lock (_lock)
            {
                if (!_seats.ContainsKey(seatNo))
                    throw new ArgumentException("Invalid seat number");

                var seat = _seats[seatNo];

                if (seat.IsBooked)
                    return false;

                seat.Book(userId);
                return true;
            }
        }

        public Seat GetSeat(int seatNo) => _seats[seatNo];
    }
}
