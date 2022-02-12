using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Todo.Entities.Concrete;

namespace Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class TodoContext : IdentityDbContext<AppUser, AppRole, int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Localhost; database=WebTodo; user=LAPTOP-9M7PDS68; integrated security=true");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AssignmentMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Urgency> Urgencys { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }


    }
}
