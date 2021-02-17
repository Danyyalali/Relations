using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Address
    {
        public int Id { get; set; }
        public int HouseNo { get; set; }
        public string streetNO { get; set; }
        public string city { get; set; }
        public string Province { get; set; }
        public string state { get; set; }
        public int StudentId { get; set; }
        public virtual Student StudentData { get; set; }
    }

}
