using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Section
    {
        public int Id { get; set; }
        public string SecitonName { get; set; } 
        public ICollection<Student> ClassStudents { get; set; }
    }
}
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////
/// 
/// </summary>
/*public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int StudentAge { get; set; }

    public int GradeId { get; set; }
    public Grade Grade { get; set; }
}

public class Grade
{
    public int GradeId { get; set; }
    public string GradeName { get; set; }

    public ICollection<Student> Students { get; set; }
}
*/

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne<Grade>(s => s.Grade)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GradeId);
    }*/
