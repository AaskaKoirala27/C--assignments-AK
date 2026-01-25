using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public enum Priority { Low, Medium, High }

class TaskItem
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    static List<TaskItem> tasks = new List<TaskItem>();
    static string filePath = "tasks.txt";

    public TaskItem() { }

    public TaskItem(string title, string description, Priority priority, DateTime dueDate)
    {
        Title = title;
        Description = description;
        Priority = priority;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public override string ToString()
    {
        // show task with colored headers
        var headerColor = ConsoleColor.Yellow;
        var defaultColor = Console.ForegroundColor;

        Console.ForegroundColor = headerColor; Console.Write("Title: "); Console.ForegroundColor = defaultColor; Console.Write($"{Title} | ");
        Console.ForegroundColor = headerColor; Console.Write("Description: "); Console.ForegroundColor = defaultColor; Console.Write($"{Description} | ");
        Console.ForegroundColor = headerColor; Console.Write("Priority: "); Console.ForegroundColor = defaultColor; Console.Write($"{Priority} | ");
        Console.ForegroundColor = headerColor; Console.Write("Due Date: "); Console.ForegroundColor = defaultColor; Console.Write($"{DueDate:yyyy-MM-dd} | ");
        Console.ForegroundColor = headerColor; Console.Write("Status: "); Console.ForegroundColor = defaultColor; Console.WriteLine(IsCompleted ? "Completed" : "Pending");

        return string.Empty; 
    }

    public static void AddTask()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Enter task description: ");
        string description = Console.ReadLine() ?? "";

        Priority priority = GetValidPriority();
        DateTime dueDate = GetValidDate("Enter due date (yyyy-MM-dd): ");

        tasks.Add(new TaskItem(title, description, priority, dueDate));
        Console.WriteLine("Task added successfully.");
    }

    public static void ViewAllTasks()
    {
        if (tasks.Count == 0) { Console.WriteLine("No tasks available."); return; }

        Console.WriteLine("\nAll Tasks:");
        int index = 1;
        foreach (var task in tasks)
        {
            Console.Write($"{index}. "); task.ToString(); index++;
        }
    }

    public static void MarkTaskCompleted()
    {
        if (tasks.Count == 0) { Console.WriteLine("No tasks available."); return; }
        ViewAllTasks();
        Console.Write("Enter the task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
            Console.WriteLine("Task marked as completed.");
        }
        else Console.WriteLine("Invalid task number.");
    }

    public static void DeleteTask()
    {
        if (tasks.Count == 0) { Console.WriteLine("No tasks available."); return; }
        ViewAllTasks();
        Console.Write("Enter the task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Task deleted.");
        }
        else Console.WriteLine("Invalid task number.");
    }

    public static void FilterTasksByPriority()
    {
        Priority priority = GetValidPriority();
        var filtered = tasks.Where(t => t.Priority == priority).ToList();
        if (filtered.Count == 0) { Console.WriteLine($"No tasks with {priority} priority."); return; }
        Console.WriteLine($"\nTasks with {priority} priority:");
        int index = 1;
        foreach (var task in filtered) { Console.Write($"{index}. "); task.ToString(); index++; }
    }

    public static void SortTasksByDueDate()
    {
        tasks = tasks.OrderBy(t => t.DueDate).ToList();
        Console.WriteLine("Tasks sorted by due date.");
        ViewAllTasks();
    }

    public static Priority GetValidPriority()
    {
        while (true)
        {
            Console.Write("Enter priority (Low, Medium, High): ");
            string input = Console.ReadLine() ?? "";
            if (Enum.TryParse(input, true, out Priority priority)) return priority;
            Console.WriteLine("Invalid priority. Use Low, Medium, High.");
        }
    }

    public static DateTime GetValidDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (DateTime.TryParse(input, out DateTime date)) return date;
            Console.WriteLine("Invalid date format. Use yyyy-MM-dd.");
        }
    }

    public static void LoadTasksFromFile()
    {
        if (!File.Exists(filePath)) return;

        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 5)
            {
                string title = parts[0].Trim();
                string description = parts[1].Trim();
                Priority priority = (Priority)Enum.Parse(typeof(Priority), parts[2].Trim());
                DateTime dueDate = DateTime.Parse(parts[3].Trim());
                bool completed = parts[4].Trim() == "Completed";

                TaskItem task = new TaskItem(title, description, priority, dueDate) { IsCompleted = completed };
                tasks.Add(task);
            }
        }
    }

    public static void SaveTasksToFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var t in tasks)
            {
                writer.WriteLine($"{t.Title} | {t.Description} | {t.Priority} | {t.DueDate:yyyy-MM-dd} | {(t.IsCompleted ? "Completed" : "Pending")}");
            }
        }
    }
}

