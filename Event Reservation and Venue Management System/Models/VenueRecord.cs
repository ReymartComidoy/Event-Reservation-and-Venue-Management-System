namespace Event_Reservation_and_Venue_Management_System.Models
{
    public sealed class VenueRecord
    {
        public int Id { get; init; }
        public string VenueName { get; init; } = string.Empty;
        public string VenueType { get; init; } = string.Empty;
        public int Capacity { get; init; }
        public string Location { get; init; } = string.Empty;
        public decimal PricePerHour { get; init; }
        public string Status { get; init; } = string.Empty;
        public string? ImagePath { get; init; }
    }
}
