
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<UserUserGroup> UserUserGroups { get; set; }
        public DbSet<PolicyUserGroup> PolicyUserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<UserGroup>().HasKey(g => g.GroupId);
            modelBuilder.Entity<Policy>().HasKey(p => p.PolicyId);

            // Will deleyte all the request by this user if the user is deleted
            modelBuilder.Entity<UserRequest>()
                .HasOne(r => r.User)
                .WithMany(u => u.UserRequests)
                .HasForeignKey(r => r.RequestedBy)
                .OnDelete(DeleteBehavior.Cascade);

            //Implementing the N:N relationship between users and groups
            modelBuilder.Entity<UserUserGroup>()
                .HasKey(ug => new { ug.UserId, ug.GroupId });

            modelBuilder.Entity<UserUserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserUserGroup>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserUsers)
                .HasForeignKey(ug => ug.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            //Implementing the N:N relationship between policies and groups

            modelBuilder.Entity<PolicyUserGroup>()
                .HasKey(pg => new { pg.PolicyId, pg.GroupId });

            modelBuilder.Entity<PolicyUserGroup>()
                .HasOne(pg => pg.Policy)
                .WithMany(p => p.Groups)
                .HasForeignKey(pg => pg.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PolicyUserGroup>()
                .HasOne(pg => pg.Group)
                .WithMany(g => g.Policies)
                .HasForeignKey(pg => pg.GroupId);

            // some data seed you can comment it

            modelBuilder.Entity<User>().HasData(
        new User { UserId = "qais", Username = "Qais", IsEnabled = true, CreatedDateTime = new DateTime(2025, 7, 1) },
        new User { UserId = "ali", Username = "Ali", IsEnabled = true, CreatedDateTime = new DateTime(2025, 7, 2) },
        new User { UserId = "mehdi", Username = "Mehdi", IsEnabled = true, CreatedDateTime = new DateTime(2025, 7, 3) },
        new User { UserId = "farah", Username = "Farah", IsEnabled = false, CreatedDateTime = new DateTime(2025, 7, 4) },
        new User { UserId = "sara", Username = "Sara", IsEnabled = true, CreatedDateTime = new DateTime(2025, 7, 5) },
        new User { UserId = "ahmad", Username = "Ahmad", IsEnabled = true, CreatedDateTime = new DateTime(2025, 7, 6) },
        new User { UserId = "sulaiman", Username = "Sulaiman", IsEnabled = false, CreatedDateTime = new DateTime(2025, 7, 7) }
    );

            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup { GroupId = "admins", Description = "Administrators" },
                new UserGroup { GroupId = "reviewers", Description = "Request Reviewers" }
            );

            modelBuilder.Entity<Policy>().HasData(
                new Policy { PolicyId = "P1", PolicyName = "DefaultPolicy", IsDefault = true, PolicyType = 0, IsEnabled = true, CreatedDateTime = new DateTime(2025, 7, 1) },
                new Policy { PolicyId = "P2", PolicyName = "StrictPolicy", IsDefault = false, PolicyType = 1, IsEnabled = false, CreatedDateTime = new DateTime(2025, 7, 2) }
            );

            modelBuilder.Entity<UserUserGroup>().HasData(
                new UserUserGroup { UserId = "qais", GroupId = "admins" },
                new UserUserGroup { UserId = "ali", GroupId = "reviewers" },
                new UserUserGroup { UserId = "mehdi", GroupId = "reviewers" },
                new UserUserGroup { UserId = "farah", GroupId = "admins" },
                new UserUserGroup { UserId = "sara", GroupId = "reviewers" },
                new UserUserGroup { UserId = "ahmad", GroupId = "admins" },
                new UserUserGroup { UserId = "sulaiman", GroupId = "reviewers" }
            );

            modelBuilder.Entity<PolicyUserGroup>().HasData(
                new PolicyUserGroup { PolicyId = "P1", GroupId = "admins" },
                new PolicyUserGroup { PolicyId = "P2", GroupId = "reviewers" }
            );

            modelBuilder.Entity<UserRequest>().HasData(
                new UserRequest
                {
                    RequestId = 1,
                    RequestedBy = "qais",
                    RequestDateTime = new DateTime(2025, 7, 8, 9, 0, 0),
                    RequestCode = 100,
                    Description = "Initial system setup",
                    Status = RequestStatus.Approved,
                    CompletionDateTime = new DateTime(2025, 7, 8, 9, 5, 0)
                },
                new UserRequest
                {
                    RequestId = 2,
                    RequestedBy = "ali",
                    RequestDateTime = new DateTime(2025, 7, 8, 10, 0, 0),
                    RequestCode = 101,
                    Description = "Documentation review",
                    Status = RequestStatus.InReview,
                    CompletionDateTime = null
                },
                new UserRequest
                {
                    RequestId = 3,
                    RequestedBy = "mehdi",
                    RequestDateTime = new DateTime(2025, 7, 9, 9, 30, 0),
                    RequestCode = 102,
                    Description = "Feature design",
                    Status = RequestStatus.Draft,
                    CompletionDateTime = null
                },
                new UserRequest
                {
                    RequestId = 4,
                    RequestedBy = "farah",
                    RequestDateTime = new DateTime(2025, 7, 9, 10, 15, 0),
                    RequestCode = 103,
                    Description = "Performance audit",
                    Status = RequestStatus.Rejected,
                    CompletionDateTime = new DateTime(2025, 7, 9, 10, 45, 0)
                },
                new UserRequest
                {
                    RequestId = 5,
                    RequestedBy = "sara",
                    RequestDateTime = new DateTime(2025, 7, 10, 8, 45, 0),
                    RequestCode = 104,
                    Description = "Security scan",
                    Status = RequestStatus.Error,
                    CompletionDateTime = null
                },
                new UserRequest
                {
                    RequestId = 6,
                    RequestedBy = "ahmad",
                    RequestDateTime = new DateTime(2025, 7, 10, 11, 0, 0),
                    RequestCode = 105,
                    Description = "User training",
                    Status = RequestStatus.Approved,
                    CompletionDateTime = new DateTime(2025, 7, 10, 11, 10, 0)
                },
                new UserRequest
                {
                    RequestId = 7,
                    RequestedBy = "sulaiman",
                    RequestDateTime = new DateTime(2025, 7, 11, 9, 0, 0),
                    RequestCode = 106,
                    Description = "Final review",
                    Status = RequestStatus.InReview,
                    CompletionDateTime = null
                }
            );

        }
    }
}
