using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Converters
{
    public class UserConverter
    {
        public User UserDTOToUser(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                Role = userDTO.Role,
            };
        }

        public UserDTO UserToUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Role = user.Role,
            };
        }
    }
}
