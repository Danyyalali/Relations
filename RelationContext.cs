using System;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp1
{
    class RelationContext : DbContext
    {
        public RelationContext() : base()
        {
            // Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

        }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StuCorse> SCTable {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=StudentDatabase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StuCorse>().HasKey(cs => new { cs.StudentId, cs.CourseId});
            //modelBuilder.Entity<User>().Property(user => user.Role).HasDefaultValue("Player");
        }
        /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {

             modelBuilder.Entity<Student>()
                         .HasMany<Course>(s => s.Courses)
                         .WithMany(c => c.Students)
                         .Map(cs =>
                         {
                             cs.MapLeftKey("StudentRefId");
                             cs.MapRightKey("CourseRefId");
                             cs.ToTable("StudentCourse");
                         });

         }*/
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Student & StudentAddress entity
            modelBuilder.Entity<Student>()
                        .HasOptional(s => s.Address) // Mark Address property optional in Student entity
                        .WithRequired(ad => ad.Student); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
        }*/
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Address");
            modelBuilder.Entity<Course>().ToTable("CousreStudents");

        }*/
    }

}
