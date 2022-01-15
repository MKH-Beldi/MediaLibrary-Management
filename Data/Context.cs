using Data.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context: DbContext
    {
        public Context() { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<MediaLibrary> MediaLibraries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source= (localDB)\MSSQLLOCALDB; initial catalog = MediaLibraryDB; Integrated security= true ; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AudioConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
