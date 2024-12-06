using hacaton.Models;
using Microsoft.EntityFrameworkCore;

namespace hacaton.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Employees> employess { get; set; }
        public DbSet<Contracts> contracts { get; set; } 
        public DbSet<Attendance> attendances { get; set; } 
        public DbSet<Payroll> payrolls { get; set; } 
        public DbSet<VacationRequest> vacationRequests { get; set; } 
        
        
    }
}
