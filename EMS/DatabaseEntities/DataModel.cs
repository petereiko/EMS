using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EMS.DatabaseEntities
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmployeeLevel> EmployeeLevels { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLevel>()
                .Property(e => e.LevelName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLevel>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.EmployeeLevel)
                .HasForeignKey(e => e.LevelId);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
