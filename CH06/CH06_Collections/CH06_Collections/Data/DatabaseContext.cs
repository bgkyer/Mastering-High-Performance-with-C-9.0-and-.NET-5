namespace CH06_Collections.Data
{
	using Microsoft.EntityFrameworkCore;
	using CH06_Collections.Models;

	public class DatabaseContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
        private string _connectionString;

        public DatabaseContext(string connectionString)
		{
            _connectionString = connectionString;
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .HasMaxLength(50);
                entity.Property(e => e.Description)
                    .HasMaxLength(255);
            });
        }
    }
}
