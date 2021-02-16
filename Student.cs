using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Student
    {
        
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public float cgpa { get; set; }
        public int AdressId = Address.Id; 
}
}
