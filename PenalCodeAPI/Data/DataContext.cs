namespace PenalCodeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CriminalCode> CriminalCodes { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }
    }
}
