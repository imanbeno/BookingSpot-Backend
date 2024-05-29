namespace BookingSpot.Models
{
    public class CampingSpot
    {
        public int id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
