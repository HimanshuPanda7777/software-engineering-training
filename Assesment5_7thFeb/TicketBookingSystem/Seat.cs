using System.Threading.Tasks.Dataflow;

namespace TicketBookingSystem.Models
{
    public class Seat
    {
        public int SeatNo { get; }
        public bool IsBooked { get; private set; }
        public string? BookedBy { get; private set; }

        public Seat(int seatNo)
        {
            SeatNo = seatNo;
            IsBooked = false;
        }

        public void Book(string userId)
        {
            IsBooked=true;
            BookedBy=userId;
        }
    }
}
