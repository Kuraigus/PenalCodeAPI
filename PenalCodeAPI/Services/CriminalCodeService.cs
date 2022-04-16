using PenalCodeAPI.DTO;
using PenalCodeAPI.Interfaces;

namespace PenalCodeAPI.Services
{
    public class CriminalCodeService
    {

        private readonly ICriminalCodeRepository _criminalCodeRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IUserRepository _userRepository;

        public CriminalCodeService(ICriminalCodeRepository criminalCodeRepository, 
            IGenericRepository genericRepository,
            IStatusRepository statusRepository, 
            IUserRepository userRepository)
        {
            _criminalCodeRepository = criminalCodeRepository;
            _genericRepository = genericRepository;
            _statusRepository = statusRepository;
            _userRepository = userRepository;
        }

        public PageableResponse<CriminalCode> GetCriminalCodes(int page, string? sort, string? filter)
        {
            var pageResults = 5f;
            var pageCount = 1.0;

            var codes = _criminalCodeRepository.GetCriminalCodes(pageResults, page, out pageCount);

            if (sort != null) 
            {
                codes = codes.OrderBy(c => 
                {
                    var property = c.GetType().GetProperty(sort);
                    if (property != null)
                        return property.GetValue(c);
                    return null;
                }).ToList();
            }

            if (filter != null)
                codes = codes.Where(c => c.Name.Contains(filter) || 
                                         c.Description.Contains(filter) ||
                                         c.UpdateUserId == Int32.Parse(filter) ||
                                         c.CreateUserId == Int32.Parse(filter) ||
                                         c.StatusId == Int32.Parse(filter) ||
                                         c.PrisonTime == Int32.Parse(filter) ||
                                         c.Penalty == Int32.Parse(filter)
                                         ).ToList();



            List<CriminalCode> criminalCode = new List<CriminalCode>();

            foreach (var code in codes)
            {
                criminalCode.Add(new CriminalCode
                {
                    Id = code.Id,
                    CreateDate = code.CreateDate,
                    CreateUserId = code.CreateUserId,
                    UpdateDate = code.UpdateDate,
                    UpdateUserId = code.UpdateUserId,
                    StatusId = code.StatusId,
                    Penalty = code.Penalty,
                    PrisonTime = code.PrisonTime,
                    Name = code.Name,
                    Description = code.Description,
                });
            }


            var response = new PageableResponse<CriminalCode>
            {
                Result = criminalCode,
                CurrentPage = page,
                Pages = (int)pageCount
            };


            return response;
        }

        public CriminalCode GetCriminalCode(int id)
        {
            var response = _criminalCodeRepository.GetCriminalCode(id);
            if (response == null)
                throw new KeyNotFoundException("Codigo penal nao encontrado!");

            return response;
        }

        public string CreateCriminalCode(CriminalCode criminalCode)
        {
            if (_userRepository.GetUser(criminalCode.CreateUserId) == null)
                throw new KeyNotFoundException("User nao encontrado");
            if (_statusRepository.GetStatus(criminalCode.StatusId) == null)
                throw new KeyNotFoundException("Status nao encontrado");
            

            return _criminalCodeRepository.CreateCriminalCode(criminalCode);
        }

        public string UpdateCriminalCode(CriminalCode request)
        {
            var dbCriminalCode = _criminalCodeRepository.GetCriminalCode(request.Id);
            if (dbCriminalCode == null)
                throw new KeyNotFoundException("Codigo penal nao encontrado!");

            dbCriminalCode.Name = request.Name;
            dbCriminalCode.Description = request.Description;
            dbCriminalCode.UpdateDate = request.UpdateDate;
            dbCriminalCode.UpdateUserId = request.UpdateUserId;
            dbCriminalCode.PrisonTime = request.PrisonTime;
            dbCriminalCode.Penalty = request.Penalty;
            dbCriminalCode.StatusId = request.StatusId;

            _genericRepository.SaveChanges();

            return "Sucesso em atualizar codigo penal!";
        }

        public string DeleteCriminalCode(int id)
        {
            var criminalCode = _criminalCodeRepository.GetCriminalCode(id);
            if (criminalCode == null)
                throw new KeyNotFoundException("Codigo penal nao encontrado!");

            return _criminalCodeRepository.DeleteCriminalCode(criminalCode);
        }

    }
}
