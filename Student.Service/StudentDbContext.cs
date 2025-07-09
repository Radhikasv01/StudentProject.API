using Microsoft.EntityFrameworkCore;
using Student.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Service
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public DbSet<SportsModel> sports { get; set; }
    }
}
