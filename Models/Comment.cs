using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Project2021.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int VideoID { get; set; }
        public Video Video { get; set; }
    }
}
