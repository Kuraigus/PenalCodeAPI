namespace PenalCodeAPI.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);
        string CreateUser(User user);
        string DeleteUser(User user);
        User FindUserByUserName(string userName);

    }
}
