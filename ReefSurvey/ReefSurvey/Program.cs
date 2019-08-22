using System;
using System.Linq;
using Model;

namespace ReefSurvey
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FishDump())
            {
                //db.Blogs.Add(new Fish { Url = "http://blogs.msdn.com/adonet" });
                //var count = db.SaveChanges();
                //Console.WriteLine("{0} records saved to database", count);

                //Console.WriteLine();
                //Console.WriteLine("All blogs in database:");
                //foreach (var blog in db.Blogs)
                //{
                //    Console.WriteLine(" - {0}", blog.Url);
                //}
            }
        }
    }
}
