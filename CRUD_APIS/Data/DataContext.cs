using Microsoft.EntityFrameworkCore;

namespace CRUD_APIS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) { }
        public DataContext() { }
        public DbSet<Employee> Employees => Set<Employee>();
       
    }
}
