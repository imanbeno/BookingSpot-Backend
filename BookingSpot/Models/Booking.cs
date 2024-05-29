namespace BookingSpot.Models
{
    public class Booking
    {
        public int id { get; private set; }
        public int UserId { get; set; }
        public int CampingSpotId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfPeople { get; set; } 
        public bool IsActive { get; set; }
    }
}
