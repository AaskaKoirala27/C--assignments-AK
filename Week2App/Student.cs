using System;
using System.Collections.Generic;
using System.IO;

class Student
{
    public string Name { get; set; } = string.Empty;
    public List<double> Grades { get; set; } = new List<double>();
    static List<Student> students = new List<Student>();
    static string filePath = "students.txt";

    public Student() { }
    public Student(string name) { Name = name; }

    public double CalculateAverage()
    {
        if (Grades.Count == 0) return 0.0;
        double sum = 0;
        foreach (var g in Grades) sum += g;
        return sum / Grades.Count;
    }

    public static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(name))
        {
            students.Add(new Student(name));
            Console.WriteLine($"Student '{name}' added successfully.");
        }
        else Console.WriteLine("Invalid name.");
    }

    public static void ViewAllStudents()
    {
        if (students.Count == 0) { Console.WriteLine("No students."); return; }
        Console.WriteLine("\nList of Students:");
        int index = 1;
        foreach (var s in students) Console.WriteLine($"{index++}. {s.Name} (Grades: {string.Join(", ", s.Grades)})");
    }

    public static void AddGradeToStudent()
    {
        if (students.Count == 0) { Console.WriteLine("No students."); return; }
        ViewAllStudents();
        Console.Write("Enter student number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= students.Count)
        {
            double grade = GetValidGrade("Enter grade (0-100): ");
            students[index - 1].Grades.Add(grade);
            Console.WriteLine($"Grade {grade} added to {students[index - 1].Name}.");
        }
        else Console.WriteLine("Invalid student number.");
    }

    public static void CalculateAverageForStudent()
    {
        if (students.Count == 0) { Console.WriteLine("No students."); return; }
        ViewAllStudents();
        Console.Write("Enter student number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= students.Count)
        {
            double avg = students[index - 1].CalculateAverage();
            Console.WriteLine($"Average for {students[index - 1].Name}: {avg:F2}");
        }
        else Console.WriteLine("Invalid student number.");
    }

    public static double GetValidGrade(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double grade) && grade >= 0 && grade <= 100)
                return grade;
            Console.WriteLine("Invalid grade. 0-100 only.");
        }
    }

    public static void LoadStudentsFromFile()
    {
        if (!File.Exists(filePath)) return;
        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 1)
            {
                Student s = new Student(parts[0].Trim());
                if (parts.Length > 1)
                {
                    foreach (var g in parts[1].Split(',')) if (double.TryParse(g.Trim(), out double grade)) s.Grades.Add(grade);
                }
                students.Add(s);
            }
        }
    }

    public static void SaveStudentsToFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var s in students)
            {
                writer.WriteLine($"{s.Name} | {string.Join(",", s.Grades)}");
            }
        }
    }
}
