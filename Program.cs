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
    public class DbPosts : DbContext
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
    }
    class Program
    {
        static void Main(string[] args)
        {
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
