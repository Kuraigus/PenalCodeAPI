using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Converters
{
    public class StatusConverter
    {
        public Status StatusDTOToStatus(StatusDTO statusDTO)
        {
            return new Status
            {
                Id = statusDTO.Id,
                Name = statusDTO.Name
            };
        }
        public StatusDTO StatusToStatusDTO(Status status)
        {
            return new StatusDTO
            {
                Id = status.Id,
                Name = status.Name
            };
        }
    }
}
