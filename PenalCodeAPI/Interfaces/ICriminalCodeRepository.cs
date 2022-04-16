namespace PenalCodeAPI.Interfaces
{
    public interface ICriminalCodeRepository
    {
        ICollection<CriminalCode> GetCriminalCodes(float pageResults, int page, out double pageCount);
        CriminalCode GetCriminalCode(int id);
        string CreateCriminalCode(CriminalCode criminalCode);
        string DeleteCriminalCode(CriminalCode criminalCode);

    }
}
