using PenalCodeAPI.Interfaces;

namespace PenalCodeAPI.Repositories
{
    public class CriminalCodeRepository : ICriminalCodeRepository
    {
        private readonly DataContext _context;

        public CriminalCodeRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<CriminalCode> GetCriminalCodes(float pageResults, int page, out double pageCount)
        {
            pageCount = Math.Ceiling(_context.CriminalCodes.Count() / pageResults);

            return _context.CriminalCodes
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList();
        }
        public CriminalCode GetCriminalCode(int id)
        {
            return _context.CriminalCodes.Find(id);
        }
        
        public void  CreateCriminalCode(CriminalCode criminalCode)
        {
            _context.CriminalCodes.Add(criminalCode);
            _context.SaveChanges();
        }

        public void DeleteCriminalCode(CriminalCode criminalCode)
        {
            _context.CriminalCodes.Remove(criminalCode);
            _context.SaveChanges();
        }
    }
}
