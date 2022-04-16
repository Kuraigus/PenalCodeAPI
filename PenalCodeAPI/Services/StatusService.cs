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

        public string CreateStatus(Status status)
        {
            var response = _statusRepository.CreateStatus(status);

            return response;
        }

        public string UpdateStatus(Status request)
        {
            var dbStatus = _statusRepository.GetStatus(request.Id);
            if (dbStatus == null)
                throw new KeyNotFoundException("Status nao encontrado!");

            dbStatus.Name = request.Name;

            _genericRepository.SaveChanges();

            return "Sucesso em atualizar status!";
        }

        public string DeleteStatus(Status status)
        {
            var dbStatus = _statusRepository.GetStatus(status.Id);
            if (dbStatus == null)
                throw new KeyNotFoundException("Status nao encontrado!");

            var response = _statusRepository.DeleteStatus(status);

            return response;
        }
    }
}
