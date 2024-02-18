namespace eTickets.Models
{
    public class Performer_Concert 
    {
        public int ConcertId { get; set; } 
        public Concert Concert { get; set; } 
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
    }
}
