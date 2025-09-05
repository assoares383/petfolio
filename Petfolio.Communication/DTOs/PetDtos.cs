namespace Petfolio.Communication.DTOs
{
    public record PetDto
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string Species { get; init; }
        public required string Breed { get; init; }
        public DateTime DateOfBirth { get; init; }
        public required string OwnerName { get; init; }
        public required string OwnerEmail { get; init; }
    }

    public record CreatePetDto
    {
        public required string Name { get; init; }
        public required string Species { get; init; }
        public required string Breed { get; init; }
        public DateTime DateOfBirth { get; init; }
        public required string OwnerName { get; init; }
        public required string OwnerEmail { get; init; }
    }

    public record UpdatePetDto
    {
        public required string Name { get; init; }
        public required string Species { get; init; }
        public required string Breed { get; init; }
        public DateTime DateOfBirth { get; init; }
        public required string OwnerName { get; init; }
        public required string OwnerEmail { get; init; }
    }
}
