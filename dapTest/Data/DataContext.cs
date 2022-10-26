

namespace dapTest.Data
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<Gruppe11> dbGruppe { get; set; }
    }
}
