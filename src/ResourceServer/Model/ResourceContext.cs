namespace AspNet5SQLite.Model
{
    using Microsoft.Data.Entity;

    // >dnx . ef migration add testMigration
    public class ResourceContext : DbContext
    {
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.Entity<UserEvent>().ToTable("UserEvent").HasKey(m => m.Id);
            builder.Entity<UserDocument>().ToTable("UserDocument").HasKey(m => m.Id);

            base.OnModelCreating(builder); 
        } 
    }
}