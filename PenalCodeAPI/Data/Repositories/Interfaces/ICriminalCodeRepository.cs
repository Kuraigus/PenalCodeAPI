using System.Security.Claims;

namespace PenalCodeAPI.Interfaces
{
    public interface ICriminalCodeRepository
    {
        ICollection<CriminalCode> GetCriminalCodes(float pageResults, int page, out double pageCount);
        CriminalCode GetCriminalCode(int id);
        void CreateCriminalCode(CriminalCode criminalCode);
        void DeleteCriminalCode(CriminalCode criminalCode);

    }
}
