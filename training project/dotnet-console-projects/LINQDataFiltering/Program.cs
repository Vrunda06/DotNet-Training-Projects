using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDataFiltering
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Marks { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student{Id=1, Name=\"Alice\", Marks=85},
                new Student{Id=2, Name=\"Bob\", Marks=72},
                new Student{Id=3, Name=\"Charlie\", Marks=90},
                new Student{Id=4, Name=\"David\", Marks=60},
                new Student{Id=5, Name=\"Eva\", Marks=78}
            };

            Console.WriteLine(\"All students:\");
            foreach(var s in students) Console.WriteLine($\"{s.Id}. {s.Name} - {s.Marks}\");

            Console.WriteLine(\"\\nHigh scorers (marks >= 80):\");
            var high = students.Where(s => s.Marks >= 80).OrderByDescending(s=>s.Marks);
            foreach(var s in high) Console.WriteLine($\"{s.Name} - {s.Marks}\");

            Console.WriteLine(\"\\nSelect names and marks (anonymous type):\");
            var projection = students.Select(s => new { s.Name, s.Marks });
            foreach(var p in projection) Console.WriteLine($\"{p.Name} -> {p.Marks}\");

            Console.WriteLine(\"\\nTop 3 students by marks:\");
            var top3 = students.OrderByDescending(s => s.Marks).Take(3);
            foreach(var s in top3) Console.WriteLine($\"{s.Name} - {s.Marks}\");
        }
    }
}
