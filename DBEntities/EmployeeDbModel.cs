namespace DBEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeDbModel : DbContext
    {
        public EmployeeDbModel()
            : base("name=EmployeeDbModel")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeLocation> EmployeeLocations { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Experience)
                .HasPrecision(18, 1);

            modelBuilder.Entity<EmployeeLocation>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.EmployeeLocation)
                .HasForeignKey(e => e.EmpLocation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeePosition>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.EmployeePosition)
                .HasForeignKey(e => e.EmpPosition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.GenderValue)
                .IsFixedLength();
            
        }
    }
}
