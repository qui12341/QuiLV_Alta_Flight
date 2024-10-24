using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;

namespace Alta_Flight.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Accounts> Account { get; set; }
        public DbSet<Groups> Group { get; set; }
        public DbSet<Account_Groups> Account_Group { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<UpdateVersions> UpdateVersion { get; set; }
        public DbSet<Configurations> Configuration { get; set; }
        public DbSet<Document_Lists> Document_List { get; set; }
        public DbSet<Flight_document_lists> flight_Document_List { get; set; }
        public DbSet<Flights> Flight { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship
            modelBuilder.Entity<Account_Groups>()
                .HasOne<Accounts>() // Liên kết với bảng Accounts qua accountID
                .WithMany()
                .HasForeignKey(ag => ag.accountID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account_Groups>()
                .HasOne<Groups>() // Liên kết với bảng Groups qua group_id
                .WithMany()
                .HasForeignKey(ag => ag.group_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Accounts>()
                .HasOne<Roles>()
                .WithMany()
                .HasForeignKey(a => a.role_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Groups>()
                .HasMany<Permission>()
                .WithOne()
                .HasForeignKey(p => p.group_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Accounts>()
                .Property(a => a.group_id)
                .IsRequired(false);

            modelBuilder.Entity<Accounts>()
                .HasMany<UpdateVersions>()
                .WithOne()
                .HasForeignKey(uv => uv.accountID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Configurations>()
                .HasOne<Permission>()
                .WithMany()
                .HasForeignKey(c => c.Permission_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Document_Lists>()
                .HasOne<Configurations>()
                .WithMany()
                .HasForeignKey(dl => dl.configuration_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Document_Lists>()
                .HasOne<Accounts>()
                .WithMany()
                .HasForeignKey(dl => dl.accountID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Document_Lists>()
                .HasOne<UpdateVersions>()
                .WithMany()
                .HasForeignKey(dl => dl.Update_Version_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Document_Lists>()
                .HasOne<Permission>()
                .WithMany()
                .HasForeignKey(dl => dl.Permission_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight_document_lists>()
                .HasOne<Document_Lists>() 
                .WithMany()
                .HasForeignKey(fdl => fdl.document_list_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight_document_lists>()
                .HasOne<Flights>()
                .WithMany()
                .HasForeignKey(fdl => fdl.flight_ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flights>()
                .Property(a => a.document_list_id)
                .IsRequired(false);

            modelBuilder.Entity<Groups>()
                .Property(gr => gr.accountID)
                .IsRequired(false);

        }
    }
}
