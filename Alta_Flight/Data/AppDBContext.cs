using Alta_Flight.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Alta_Flight.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Accounts> Account { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Account_Groups> Account_Group { get; set; }
        public DbSet<Groups> Group { get; set; }
        public DbSet<UpdateVersions> UpdateVersion { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Accounts>()
                .HasOne<Roles>()          // Mỗi tài khoản có một vai trò
                .WithMany()               // Một vai trò có thể gán cho nhiều tài khoản
                .HasForeignKey(a => a.role_id)  // Thiết lập khóa ngoại role_id trong bảng Accounts
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Account_Groups>()
            //    .HasKey(ag => new { ag.accountID, ag.group_id }); // Khóa chính của bảng trung gian

            //modelBuilder.Entity<Account_Groups>()
            //    .HasOne<Groups>()
            //    .WithMany(a => a.AccountGroups)
            //    .HasForeignKey(ag => ag.group_id)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Account_Groups>()
            //    .HasOne<Accounts>()
            //    .WithMany(a => a.AccountGroups)
            //    .HasForeignKey(ag => ag.accountID)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Accounts>()
                .HasOne<Account_Groups>()
                .WithMany()
                .HasForeignKey(a => a.accountID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Groups>()
                .HasOne<Account_Groups>()
                .WithMany()
                .HasForeignKey(ag => ag.group_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Accounts>()
                .Property(a => a.group_id)
                .IsRequired(false);  // group_id không bắt buộc

            modelBuilder.Entity<Accounts>()
                .HasOne<UpdateVersions>()
                .WithMany()
                .HasForeignKey(uv => uv.accountID) // Khóa ngoại
                .OnDelete(DeleteBehavior.Cascade); // Xóa liên kết (nếu cần)
        }
    }
}
