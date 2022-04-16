using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Converters
{
    public class CriminalCodeConverter
    {
        public CriminalCode CriminalCodeDTOToCriminalCode(CriminalCodeDTO criminalCodeDTO)
        {
            return new CriminalCode
            {
                Id = criminalCodeDTO.Id,
                Name = criminalCodeDTO.Name,
                Description = criminalCodeDTO.Description,
                Penalty = criminalCodeDTO.Penalty,
                PrisonTime = criminalCodeDTO.PrisonTime,
                StatusId = criminalCodeDTO.StatusId,
                CreateDate = criminalCodeDTO.CreateDate,
                UpdateDate = criminalCodeDTO.UpdateDate,
                CreateUserId = criminalCodeDTO.CreateUserId,
                UpdateUserId = criminalCodeDTO.UpdateUserId,
            };
        }

        public CriminalCodeDTO CriminalCodeToCriminalCodeDTO(CriminalCode criminalCode)
        {
            return new CriminalCodeDTO
            {
                Id = criminalCode.Id,
                Name = criminalCode.Name,
                Description = criminalCode.Description,
                Penalty = criminalCode.Penalty,
                PrisonTime = criminalCode.PrisonTime,
                StatusId = criminalCode.StatusId,
                CreateDate = criminalCode.CreateDate,
                UpdateDate = criminalCode.UpdateDate,
                CreateUserId = criminalCode.CreateUserId,
                UpdateUserId = criminalCode.UpdateUserId,
            };
        }
    }
}
