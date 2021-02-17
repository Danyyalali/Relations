using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Course
    {
       /* public Course()
        {
            this.Students = new HashSet<Student>();
        }*/
        public int Id { get; set; }
        public string Title { get; set; }
        public int creditHours { get; set; }

        //public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<StuCorse> StuCourse { get; set; }

    }
}
