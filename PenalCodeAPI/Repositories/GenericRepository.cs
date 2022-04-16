using PenalCodeAPI.Interfaces;

namespace PenalCodeAPI.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public string SaveChanges()
        {
            _context.SaveChanges();

            return "Atualizacao feita com sucesso!";
        }
    }
}
