using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Project2021.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discraption { get; set; }
        public string URL { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
