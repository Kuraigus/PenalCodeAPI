using PenalCodeAPI.Interfaces;

namespace PenalCodeAPI.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenericRepository _genericRepository;

        public UserService(IUserRepository userRepository, IGenericRepository genericRepository)
        {
            _userRepository = userRepository;
            _genericRepository = genericRepository;
        }

        public string login(User user)
        {
            var dbUser = _userRepository.FindUserByUserName(user.UserName);

            if (dbUser == null)
            {
                return "Usuario nao encontrado!";
            }

            if (dbUser.Password != user.Password)
            {
                return "Senha errada!";
            }

            var token = TokenService.generateToken(dbUser);
            return token;
        }

        public User GetUser(int id)
        {
            var reponse = _userRepository.GetUser(id);

            if (reponse == null)
                return null;

            return reponse;
        }

        public string CreateUser(User user)
        {
            var response = _userRepository.CreateUser(user);

            return response;
        }

        public string UpdateUser(User request)
        {
            var dbUser = _userRepository.GetUser(request.Id);
            if (dbUser == null)
                return null;

            dbUser.UserName = request.UserName;
            dbUser.Password = request.Password;
            dbUser.Role = request.Role;

            _genericRepository.SaveChanges();

            return "Sucesso em atualizar user!";
        }

        public string DeleteUser(User user)
        {
            var dbUser = _userRepository.GetUser(user.Id);
            if (dbUser == null)
                return null;

            var response = _userRepository.DeleteUser(dbUser);

            return response;
        }

    }
}
