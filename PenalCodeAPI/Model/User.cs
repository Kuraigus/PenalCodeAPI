using Microsoft.AspNetCore.Identity;
using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = String.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


    }
}
