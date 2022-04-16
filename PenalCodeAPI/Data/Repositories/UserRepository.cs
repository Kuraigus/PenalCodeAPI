using PenalCodeAPI.Interfaces;

namespace PenalCodeAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public User FindUserByUserName(string userName)
        {
            return _context.User.Where(u => u.UserName == userName).FirstOrDefault(); ;
        }

        public User GetUser(int id)
        {
            return _context.User.Find(id);
        }
    }
}
