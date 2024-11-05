namespace RegistrationService.Models.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public required int EventId { get; set; }
        public required int TeamId { get; set; }
        public required string Status { get; set; }
        public required string Date { get; set; }
    }
}
