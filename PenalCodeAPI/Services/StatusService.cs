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
            return _statusRepository.GetStatus(id);
        }

        public string CreateStatus(Status status)
        {
            var response = _statusRepository.CreateStatus(status);

            return "Sucesso em criar status!";
        }

        public string UpdateStatus(Status request)
        {
            var dbStatus = _statusRepository.GetStatus(request.Id);
            if (dbStatus == null)
                return null;

            dbStatus.Name = request.Name;

            _genericRepository.SaveChanges();

            return "Sucesso em atualizar status!";
        }

        public string DeleteStatus(Status status)
        {
            var response = _statusRepository.DeleteStatus(status);

            return "Sucesso em deletar status!";
        }
    }
}
