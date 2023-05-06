using Braile_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Braile_API.Data
{
    public class BraileDB : DbContext
    {
        public BraileDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<IShape> Shapes { get; set; }
    }
}
