using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Student Management System - In-memory CRUD");
            while (true)
            {
                Console.WriteLine("\nMenu: 1-Add 2-List 3-Update 4-Delete 5-Exit");
                Console.Write("Choose option: ");
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1": Add(); break;
                    case "2": ListAll(); break;
                    case "3": Update(); break;
                    case "4": Delete(); break;
                    case "5": return;
                    default: Console.WriteLine("Unknown option"); break;
                }
            }
        }

        static void Add()
        {
            Console.Write("Name: "); var name = Console.ReadLine();
            Console.Write("Age: "); var ageStr = Console.ReadLine();
            if (int.TryParse(ageStr, out var age))
            {
                students.Add(new Student { Id = nextId++, Name = name ?? "", Age = age });
                Console.WriteLine("Student added.");
            }
            else Console.WriteLine("Invalid age.");
        }

        static void ListAll()
        {
            Console.WriteLine("\nStudents:");
            foreach (var s in students)
                Console.WriteLine($\"Id:{s.Id}  Name:{s.Name}  Age:{s.Age}\");
        }

        static void Update()
        {
            Console.Write("Enter Id to update: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var s = students.FirstOrDefault(x => x.Id == id);
                if (s == null) { Console.WriteLine("Not found"); return; }
                Console.Write($"New Name (leave empty to keep '{s.Name}'): ");
                var name = Console.ReadLine(); if (!string.IsNullOrEmpty(name)) s.Name = name;
                Console.Write($"New Age (current {s.Age}): ");
                if (int.TryParse(Console.ReadLine(), out var age)) s.Age = age;
                Console.WriteLine("Updated.");
            }
            else Console.WriteLine("Invalid id.");
        }

        static void Delete()
        {
            Console.Write("Enter Id to delete: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var s = students.FirstOrDefault(x => x.Id == id);
                if (s == null) { Console.WriteLine("Not found"); return; }
                students.Remove(s);
                Console.WriteLine("Deleted.");
            }
            else Console.WriteLine("Invalid id.");
        }
    }
}
