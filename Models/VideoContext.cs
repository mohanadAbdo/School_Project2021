using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Project2021.Models;

namespace School_Project2021.Models
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> options) : base(options)
        {


        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Student> Student { get; set; }

    }
}
