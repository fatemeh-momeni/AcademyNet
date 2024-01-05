using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business_Entity;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccessLayer
{
    //یوزری که می سازد دارای فرست نیم و لست نیم می باشد
    public class DB : IdentityDbContext<UserApp>//DbContext
    {
        public DB() : base() { }
        public DB(DbContextOptions<DB> options) : base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.useSqlite("Data Source=blogging.db");
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-K2MKENH3;Initial Catalog=AcademyNet;Integrated Security=true ; User ID=sa; Password=123;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Human> Human { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<CourseDetailFile> CoursesDetailFile { get; set; }
    }
}
