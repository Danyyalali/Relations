using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }
    /*public class DbPosts : DbContext
    {
        public DbPosts() : base()
        {
                   // Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

        }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=PostsDatabase;Trusted_Connection=True;");
        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            //For storing the data in the database using one to one relationship
            using (var context = new RelationContext())
            {
                string name, email;
                int SectionId;
                float cgpa;
                Console.Write("Please enter Your name\nName:::");
                name = Console.ReadLine();
                Console.Write("Please enter Your Email\nEmail:::");
                email = Console.ReadLine();
                Console.Write("Please enter Your cgpa\nCGPA:::");
                cgpa = float.Parse(Console.ReadLine());
                Console.Write("Please enter Your Section ID\nA=1--B=2--C=3--D=4--E1=5--E2=6\nSection Id:::");
                SectionId =int.Parse( Console.ReadLine());
                var std = new Student()
                {
                    name = name,
                    cgpa = cgpa,
                    email = email,
                    SectionId = SectionId
                };
                context.Students.Add(std);
                /*var sec1 = new Section()
                {
                    SecitonName = "E2"
                };
                context.Sections.Add(sec1);*/
                context.SaveChanges();

                string streetNo,city, Province, state;
                int HouseNo;
                Console.Write("Please enter Your House Number\nHouse Number:::");
                HouseNo=int.Parse( Console.ReadLine());
                Console.Write("Please enter Your Street Number\nStreet Number:::");
                streetNo = Console.ReadLine();
                Console.Write("Please enter Your city\ncity:::");
                city = Console.ReadLine();
                Console.Write("Please enter Your Province\nProvince:::");
                Province = Console.ReadLine();
                Console.Write("Please enter Your State\nState:::");
                state = Console.ReadLine();

                var add = new Address()
                {
                    HouseNo = HouseNo,
                    streetNO = streetNo,
                    city = city,
                    Province = Province,
                    state = state,
                    StudentId = std.Id
                };
                context.Adresses.Add(add);

                int AddCourse = 1;
                string CourseName;
                int credits;
                Course cours= new Course();
                StuCorse stucor;
                while (AddCourse == 1)
                {
                    Console.WriteLine("Please enter the Course Name you want to enroll in");
                    CourseName = Console.ReadLine();
                    if (CourseName.Contains("lab") || CourseName.Contains("Lab") || CourseName.Contains("LAB"))
                    {
                        credits = 1;
                    }
                    else credits = 3;


                    /*var courses = from c in context.Courses
                                  select c.Title.ToLower;*/
                    int PresentId = 0;
                    int length = context.Courses.Count();
                    int counter = 1;
                    foreach (var item in context.Courses)
                    {
                        
                        if (CourseName.ToLower() == item.Title.ToLower())
                        {
                            PresentId = item.Id;
                            break;
                        }
                        if (counter == length)
                        {
                            cours = new Course()
                            {
                                Title = CourseName.ToLower(),
                                creditHours = credits
                            };
                            context.Add(cours);
                        }
                        counter++;

                    }
                    context.SaveChanges();
                    if (PresentId == 0)
                    {
                        stucor = new StuCorse()
                        {
                            StudentId = std.Id,
                            CourseId = cours.Id
                        };
                        context.SCTable.Add(stucor);
                        context.SaveChanges();


                        
                    }
                    else
                    {
                        stucor = new StuCorse()
                        {
                            StudentId = std.Id,
                            CourseId = PresentId
                        };
                        context.SCTable.Add(stucor);
                        context.SaveChanges();

                    }

                    AddCourse = 0;


                }

                

            }



            //for printing the data from the datbabase
            List<Student> StuList = new List<Student>();
            List<Address> StuAddList = new List<Address>();

            /*using (var context = new RelationContext())
            {
                int counter = 1;
                StuList= context.Students.ToList();
                StuAddList = context.Adresses.ToList();
                foreach (var item in StuList)
                {
                    Console.WriteLine(counter+"\nPrinting the Student Details");
                    counter++;
                    Console.Write(item.cgpa + " " + item.email + " " + item.name+" ");
                    var Addresses = from add in StuAddList
                                   where add.StudentId == item.Id
                                   select add;
                    foreach (var add in Addresses)
                    {
                        Console.Write(add.HouseNo + " " + add.streetNO + " " + add.city + " " + add.Province + " " + add.state);
                       
                    }
                    Console.WriteLine();
                    Console.WriteLine();


                }

            }*/




























            /////////////////////////////////////////////////
            ///Code for simple database mani[pulation
            string title, body;
            int id;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //To add new post by getting the input from the user
            /*using(var context = new DbPosts())
            {

                Console.Write("Please enter the title and body of the post \nTitle:::");
                title=Console.ReadLine();
                Console.Write("Body:::");
                body = Console.ReadLine();
                var post = new Post()
                {
                    title =title,
                    body = body
                };
                context.Posts.Add(post);
                context.SaveChanges();
            }*/
            List<Post> list = new List<Post>();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //To get the data from the database using LINQ Queries
            /*using (var context = new DbPosts())
            {
                list = context.Posts.ToList();
                foreach (var l in list)
                    Console.WriteLine("Title: " + l.title);
            }*/


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //To get the selected data from DBPost and pritnting it
            /*using (var context = new DbPosts())
            {
                list = context.Posts.ToList();
                var TempPost = from Post in list
                               where Post.body.Contains("d")
                               select Post;
                int counter = 0;
                foreach (var post in TempPost)
                {
                    counter++;
                    Console.Write(post.title+" ");
                    Console.WriteLine(post.body);

                }
                Console.WriteLine("Total post found ::" + counter);
            }*/





            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //TO update the data in the database
            /*using (var context = new DbPosts())
            {
                var post = new Post()
                {
                    title = "Hello from the updation",
                    body = "Updated data"
                };
                

                var post1 =context.Posts.Single(p => p.id == 1);
                post1.title = post.title;
                post1.body = post.body;
                context.Update(post1);
                context.SaveChanges();
            }*/



            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///TO Update the data using the input from the user 
            /*using(var context = new DbPosts())
            {
                list = context.Posts.ToList();
                Console.Write("Please enter the title and body of the post \nTitle:::");
                title = Console.ReadLine();
                Console.Write("Body:::");
                body = Console.ReadLine();
                Console.Write("Id of the post you want to update:::");
                id = int.Parse(Console.ReadLine());
                while (id < 1 || id > list.Count)
                {
                    Console.Write("Please enter the valid ID:::");
                    id = int.Parse(Console.ReadLine());
                }
                var PostToBeUpdated = context.Posts.Single(post => post.id == id);
                PostToBeUpdated.title = title;
                PostToBeUpdated.body = body;
                context.Update(PostToBeUpdated);
                context.SaveChanges();
            }*/


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///TO Delete the post from the Database
            /*using(var context = new DbPosts())
            {
                var PostToBeDeleted = context.Posts.Single(post => post.id == 1);
                context.Remove(PostToBeDeleted);
                context.SaveChanges();
            }
*/

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///TO Delete the post from the Database by taking the id from the user
            /*using (var context = new DbPosts())
            {
                Post PostToBeDeleted;
                Console.WriteLine("Enter the Id of the post you want to delete\nID::::");
                id = int.Parse(Console.ReadLine());
                try
                {
                    PostToBeDeleted = context.Posts.Single(post => post.id == id);
                    context.Remove(PostToBeDeleted);
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("No such Id Found");
                }
                
            }*/






        }
    }
}
