namespace PenalCodeAPI.Interfaces
{
    public interface IStatusRepository
    {
        ICollection<Status> GetAllStatus();
        Status GetStatus(int id);
        string CreateStatus(Status status);
        string DeleteStatus(Status status);
    }
}
