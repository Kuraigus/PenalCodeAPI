using PenalCodeAPI.Interfaces;

namespace PenalCodeAPI.Services
{
    public class StatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IGenericRepository _genericRepository;

        public StatusService(IStatusRepository statusRepository, IGenericRepository genericRepository)
        {
            _statusRepository = statusRepository;
            _genericRepository = genericRepository;
        }

        public ICollection<Status> GetAllStatus()
        {
            return _statusRepository.GetAllStatus();
        }

        public Status GetStatus(int id)
        {
            var response = _statusRepository.GetStatus(id);
            if (response == null)
                throw new KeyNotFoundException("Status nao encontrado!");

            return response;
        }

        public void CreateStatus(Status status)
        {
            _statusRepository.CreateStatus(status);
        }

        public void UpdateStatus(Status request, int id)
        {
            var dbStatus = _statusRepository.GetStatus(id);
            if (dbStatus == null)
                throw new KeyNotFoundException("Status nao encontrado!");

            dbStatus.Name = request.Name;

            _genericRepository.SaveChanges();
        }

        public void DeleteStatus(int id)
        {
            var dbStatus = _statusRepository.GetStatus(id);
            if (dbStatus == null)
                throw new KeyNotFoundException("Status nao encontrado!");

            _statusRepository.DeleteStatus(dbStatus);
        }
    }
}
