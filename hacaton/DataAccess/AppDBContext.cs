using hacaton.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace hacaton.DataAccess
{
    public class AppDBContext : IdentityDbContext<Employees>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Employees> employess { get; set; }
        public DbSet<Contracts> contracts { get; set; } 
        public DbSet<Attendance> attendances { get; set; } 
        public DbSet<Payroll> payrolls { get; set; } 
        public DbSet<VacationRequest> vacationRequests { get; set; }
        public DbSet<Department> departments { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Employees və VacationRequests arasında əlaqə təyin edilir
			modelBuilder.Entity<Employees>()
				.HasMany(e => e.VacationRequests)  // Bir işçinin bir neçə məzuniyyəti ola bilər
				.WithOne(v => v.Employee)  // Hər məzuniyyət bir işçiyə aiddir
				.HasForeignKey(v => v.EmployeeId); // Məzuniyyətin əlaqəsi işçi ilə
		}

	}
}
