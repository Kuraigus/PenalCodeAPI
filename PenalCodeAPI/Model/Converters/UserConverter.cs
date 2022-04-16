using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Converters
{
    public class UserConverter
    {
        public User UserDTOToUser(UserDTO userDTO)
        {
            return new User
            {
                UserName = userDTO.UserName,
                Role = userDTO.Role,
            };
        }

        public UserDTO UserToUserDTO(User user)
        {
            return new UserDTO
            {
                UserName = user.UserName,
                Role = user.Role,
            };
        }

        public User UserRegisterDTOToUser(UserRegisterDTO userRegisterDTO)
        {
            return new User
            {
                UserName = userRegisterDTO.UserName,
                Password = userRegisterDTO.Password,
                Role = userRegisterDTO.Role,
            };
        }

        public User UserLoginDTOToUser(UserLoginDTO userLoginDTO)
        {
            return new User
            {
                UserName = userLoginDTO.UserName,
                Password = userLoginDTO.Password
            };
        }
    }
}
