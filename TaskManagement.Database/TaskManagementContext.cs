using Microsoft.EntityFrameworkCore;
using TaskManagement.Database.Model;

namespace TaskManagement.Database
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskManagement.Database.Model.Task> Tasks { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Task-User relationships
            modelBuilder.Entity<TaskManagement.Database.Model.Task>()
                .HasOne(t => t.CreatedBy)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskManagement.Database.Model.Task>()
                .HasOne(t => t.AssignedTo)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Note relationships
            modelBuilder.Entity<Note>()
                .HasOne(n => n.Task)
                .WithMany(t => t.Notes)
                .HasForeignKey(n => n.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.CreatedBy)
                .WithMany()
                .HasForeignKey(n => n.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Document relationships
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Task)
                .WithMany(t => t.Documents)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.UploadedBy)
                .WithMany()
                .HasForeignKey(d => d.UploadedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
