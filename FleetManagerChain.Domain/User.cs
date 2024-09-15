using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagerChain.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped] // This will not be part of the database model
        public string? ConfirmPassword { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; } = false;

        // Empty constructor
        public User()
        {
        }

        // Constructor with parameters
        public User(string confirmPassword, string password, string email, string username, string role)
        {
            ConfirmPassword = confirmPassword;
            Password = password;
            Email = email;
            Username = username;
            Role = role;
        }

        // Method to activate the user
        public void Activate()
        {
            IsActive = true;
        }

        // Override Equals method
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            User user = (User)obj;
            return Id == user.Id &&
                   Email == user.Email &&
                   Password == user.Password &&
                   Role == user.Role &&
                   IsActive == user.IsActive;
        }

        // Override GetHashCode method
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Email, Password, Role, IsActive);
        }

        // Override ToString method
        public override string ToString()
        {
            return $"User {{ Id = {Id}, Email = {Email}, Password = {Password}, Role = {Role}, IsActive = {IsActive} }}";
        }
    }
}