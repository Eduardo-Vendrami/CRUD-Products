using Microsoft.EntityFrameworkCore;

namespace CRUD_Products.Models.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }    
    }
}
