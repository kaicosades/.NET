using Microsoft.EntityFrameworkCore;

namespace CountryApp_Cloud
    
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<CountryEntity> Country { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { //6543
            string connectionString = @"
            User Id=postgres.habhsfpcclwkhnjemeda;
            Password=Viva999(((l;
            Server=aws-0-us-east-1.pooler.supabase.com;
            Port=5432;
            Database=postgres;
            ";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}



