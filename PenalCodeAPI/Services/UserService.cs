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

            if (dbUser == null || dbUser.Password != user.Password)
            {
                throw new KeyNotFoundException("Usuario nao encontrado ou senha incorreta!");
            }

            var token = TokenService.generateToken(dbUser);
            return token;
        }

        public User GetUser(int id)
        {
            var reponse = _userRepository.GetUser(id);

            if (reponse == null)
                throw new KeyNotFoundException("Usuario nao encontrado!");

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
                throw new KeyNotFoundException("Usuario nao encontrado!");

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
                throw new KeyNotFoundException("Usuario nao encontrado!");

            var response = _userRepository.DeleteUser(dbUser);

            return response;
        }

    }
}
