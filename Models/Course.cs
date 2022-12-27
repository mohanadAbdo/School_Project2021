using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Project2021.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discraption { get; set; }
        public string Image { get; set; }
       // public List<Student> Students { get; set; }
        public List<Video> Videos { get; set; }

    }
}
