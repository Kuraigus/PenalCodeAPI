namespace PenalCodeAPI.Interfaces
{
    public interface IStatusRepository
    {
        ICollection<Status> GetAllStatus();
        Status GetStatus(int id);
        void CreateStatus(Status status);
        void DeleteStatus(Status status);
    }
}
