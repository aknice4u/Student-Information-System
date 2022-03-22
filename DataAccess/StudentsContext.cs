using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;

namespace DataAccess
{
   public class StudentsContext:DbContext
    {
        public StudentsContext() : base("StudentsDetailDB")
       {
       }
        public DbSet<StudentMedical> Medical { get; set; }

        public DbSet<Students> students { get; set; }
        public DbSet<Guardian> guardian { get; set; }
        public DbSet<SchoolClass> schoolClass { get; set; }
       public DbSet<AcademicTerm> academicTerm { get; set; }
       public DbSet<AcademicSession> academicSesssion { get; set; }
       public DbSet<FiscalYear> fiscalyear { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}
