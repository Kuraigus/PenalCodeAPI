using PenalCodeAPI.DTO;
using PenalCodeAPI.Interfaces;
using PenalCodeAPI.Type;

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
                SortType sortType = SortType.none;

                var property = codes.GetType().GetProperty(sort).GetValue(codes, null);

                codes = codes.OrderBy(c => c.GetType().GetProperty(sort).GetValue(c, null)).ToList();

                //switch (sortType.FromString(sort))
                //{
                //    case SortType.Name:
                //        {
                //            codes = codes.OrderBy(c => c.Name).ToList();
                //            break;
                //        }

                //    case SortType.CreateDate:
                //        {
                //            codes = codes.OrderBy(c => c.CreateDate).ToList();
                //            break;
                //        }

                //    case SortType.UpdateDate:
                //        {
                //            codes = codes.OrderBy(c => c.UpdateDate).ToList();
                //            break;
                //        }

                //    case SortType.CreateUserId:
                //        {
                //            codes.OrderBy(c => c.CreateUserId).ToList();
                //            break;
                //        }

                //    case SortType.UpdateUserId:
                //        {
                //            codes = codes.OrderBy(c => c.UpdateUserId).ToList();
                //            break;
                //        }

                //    case SortType.StatusId:
                //        {
                //            codes = codes.OrderBy(c => c.StatusId).ToList();
                //            break;
                //        }

                //    case SortType.Penalty:
                //        {
                //            codes = codes = codes.OrderBy(c => c.Penalty).ToList();
                //            break;
                //        }

                //    case SortType.PrisonTime:
                //        {
                //            codes = codes.OrderBy(c => c.PrisonTime).ToList();
                //            break;
                //        }
                //}
            }

            if (filter != null)
            {
                codes = codes.Where(c => c.Name.Contains(filter)).ToList();
            }


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
