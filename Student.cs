using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Student
    {
       /* public Student()
        {
            this.Courses = new HashSet<Course>();
        }*/
        
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public float cgpa { get; set; }


        public virtual Address StudentAddress { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
       // public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<StuCorse> StuCourse { get; set; }

    }
}
