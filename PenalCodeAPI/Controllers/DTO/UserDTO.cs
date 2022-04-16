namespace PenalCodeAPI.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
    }

    public class UserRegisterDTO
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
    }

    public class UserLoginDTO
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
