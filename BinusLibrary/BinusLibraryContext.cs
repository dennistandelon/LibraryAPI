using Microsoft.EntityFrameworkCore;
using BinusLibrary.Model.BinusLibrary;

namespace BinusLibrary
{
    public class BinusLibraryContext : DbContext
    {
        public DbSet<MsBook> MsBook { get; set; }
        public DbSet<MsStudent> MsStudent { get; set; }
        public DbSet<TrBook> TrBook { get; set; }
        public BinusLibraryContext(DbContextOptions<BinusLibraryContext> options) :base(options){ }

    }
}
