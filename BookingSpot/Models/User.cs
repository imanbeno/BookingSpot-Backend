using System;
using BCrypt.Net;// Zorg ervoor dat u BCrypt.Net-Next toevoegt via NuGet

namespace BookingSpot.Models
{
    public class User
    {
        public int id { get; private set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string AccountName { get; set; }
        private string Password { get; set; }

        // Constructor om een nieuwe User te initialiseren
        public User(string name, string firstName, string accountName)
        {
            Name = name;
            FirstName = firstName;
            AccountName = accountName;
        }

        // Wachtwoord veilig opslaan
        public void SetPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }


        // Wachtwoord verifiëren
        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }

    public class LoginRequest
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
    }
}
