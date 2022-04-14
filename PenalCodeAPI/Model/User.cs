using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;

    }
}
