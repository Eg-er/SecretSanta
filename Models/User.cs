using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSanta.Models
{
    public class User
    {
        public int Id { get; set; }
        [RegularExpression("[a-zA-Z]+",ErrorMessage = "Name should contain only letters")]
        [MinLength(2,ErrorMessage = "Name length should be at least 2")]
        public string Name { get; init; } = null!;
        [RegularExpression("[a-zA-Z]+",ErrorMessage = "Surname should contain only letters")]
        [MinLength(2,ErrorMessage = "Surname length should be at least 2")]
        public string Surname { get; init; } = null!;
        public User? Receiver { get; set; }
        public int? ReceiverId { get; set; }
    }
}