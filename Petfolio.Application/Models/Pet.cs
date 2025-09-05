namespace Petfolio.Application.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public required string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string OwnerName { get; set; }
        public required string OwnerEmail { get; set; }
    }
}
