using Parser;
using System;

namespace ReefSurvey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CSV csv = new CSV();
            csv.ReadCSV();
        }
    }
}
