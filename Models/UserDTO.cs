namespace SecretSanta.Services
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; init; } = null!;
        public string Surname { get; init; } = null!;
        public int? ReceiverId { get; set; }
    }
}