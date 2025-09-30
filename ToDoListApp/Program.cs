using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string filepath = "tasks.txt";
    static List<string> tasks = new List<string>();

    static void Main()
    {
        LoadTasks();
        while(true)
        {
            Console.WriteLine("\n--- To-Do List ---");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": ViewTasks(); break;
                case "2": AddTask(); break;
                case "3": RemoveTask(); break;
                case "4": SaveTasks(); return;
                default: Console.WriteLine("Invalid choice. Try again.");break;
            }
        }
        static void ViewTasks()
        {
            if (tasks.Count ==0)
            {
                Console.WriteLine("No tasks avalaible.");
                return;
            }
            Console.WriteLine("\nTasks:");
            for (int i=0; i<tasks.Count;i++)
            {
                Console.WriteLine($"{i +1}. {tasks[i]}");
            }
        }
        static void AddTask()
        {
            Console.Write("Enter task: ");
            string task = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                Console.WriteLine("Task added");
            }
           
        }
        static void RemoveTask()
        {
            ViewTasks();
            Console.Write("Enter task number to remove: ");
            if(int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <=tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task removed!");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }
        static void SaveTasks()
        {
            File.WriteAllLines(filepath, tasks);
            Console.WriteLine("Tasks saved.");
        }
        static void LoadTasks()
        {
            if(File.Exists(filepath))
            {
                tasks = new List<string>(File.ReadAllLines(filepath));

            }
        }

    }
}