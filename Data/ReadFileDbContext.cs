using Microsoft.EntityFrameworkCore;

namespace ReadExcelFile.Data;

public class ApplicationDbContext : DbContext
{
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Upload> Uploads { get; set; }

}
