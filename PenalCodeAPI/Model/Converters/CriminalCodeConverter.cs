using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Converters
{
    public class CriminalCodeConverter
    {
        public CriminalCode CriminalCodeDTOToCriminalCode(CriminalCodeDTO criminalCodeDTO)
        {
            return new CriminalCode
            {
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

        public CriminalCode GetCriminalCodeDTOToCriminalCode(GetCriminalCodeDTO GetcriminalCodeDTO)
        {
            return new CriminalCode
            {
                Id = GetcriminalCodeDTO.Id,
                Name = GetcriminalCodeDTO.Name,
                Description = GetcriminalCodeDTO.Description,
                Penalty = GetcriminalCodeDTO.Penalty,
                PrisonTime = GetcriminalCodeDTO.PrisonTime,
                StatusId = GetcriminalCodeDTO.StatusId,
                CreateDate = GetcriminalCodeDTO.CreateDate,
                UpdateDate = GetcriminalCodeDTO.UpdateDate,
                CreateUserId = GetcriminalCodeDTO.CreateUserId,
                UpdateUserId = GetcriminalCodeDTO.UpdateUserId,
            };
        }

        public CriminalCode EditCriminalCodeDTOToCriminalCode(EditCriminalCodeDTO EditcriminalCodeDTO)
        {
            return new CriminalCode
            {
                Id = EditcriminalCodeDTO.Id,
                Name = EditcriminalCodeDTO.Name,
                Description = EditcriminalCodeDTO.Description,
                Penalty = EditcriminalCodeDTO.Penalty,
                PrisonTime = EditcriminalCodeDTO.PrisonTime,
                StatusId = EditcriminalCodeDTO.StatusId
            };
        }

        public CriminalCodeDTO CriminalCodeToCriminalCodeDTO(CriminalCode criminalCode)
        {
            return new CriminalCodeDTO
            {
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

        public GetCriminalCodeDTO CriminalCodeToGetCriminalCodeDTO(CriminalCode criminalCode)
        {
            return new GetCriminalCodeDTO
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
