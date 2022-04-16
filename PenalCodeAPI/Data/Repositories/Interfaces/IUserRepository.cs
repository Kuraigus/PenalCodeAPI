namespace PenalCodeAPI.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);
        void CreateUser(User user);
        void DeleteUser(User user);
        User FindUserByUserName(string userName);

    }
}
