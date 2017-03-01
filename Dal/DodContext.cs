using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WipDod.Models;

namespace WipDod.Dal
{
    public class DodContext: DbContext
    {
        public DodContext() : base("DodContext")
        {
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}