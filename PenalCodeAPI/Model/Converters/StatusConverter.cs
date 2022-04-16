using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Converters
{
    public class StatusConverter
    {
        public Status StatusDTOToStatus(StatusDTO statusDTO)
        {
            return new Status
            {
                Name = statusDTO.Name
            };
        }
        public StatusDTO StatusToStatusDTO(Status status)
        {
            return new StatusDTO
            {
                Name = status.Name
            };
        }
    }
}
