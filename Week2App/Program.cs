using System;

// Main program class that unifies Task Manager, Student Manager, and Banking System
class Program
{
    static void Main()
    {
        // Load tasks and students from file at the start
        TaskItem.LoadTasksFromFile();
        Student.LoadStudentsFromFile();

        int choice;

        do
        {
            Console.Clear();

            // ------------------ Main Menu Header ------------------
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("       Welcome to Week2App Menu        ");
            Console.WriteLine("=======================================");
            Console.ResetColor();

            // ------------------ Menu Options ------------------
            Console.WriteLine("1. Task Manager");
            Console.WriteLine("2. Student Management");
            Console.WriteLine("3. Banking System");
            Console.WriteLine("4. Exit Program");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Enter a number.");
                Console.ResetColor();
                continue;
            }

            // ------------------ Switch for menu choice ------------------
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    RunTaskManager(ConsoleColor.Magenta); // whole section magenta
                    break;

                case 2:
                    Console.Clear();
                    RunStudentManager(ConsoleColor.Yellow); // whole section yellow
                    break;

                case 3:
                    Console.Clear();
                    Banking.RunBanking(ConsoleColor.Green); // whole section green
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Exiting program... Goodbye!");
                    Console.ResetColor();

                    // Save tasks and students before exit
                    TaskItem.SaveTasksToFile();
                    Student.SaveStudentsToFile();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option! Try again.");
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();

        } while (choice != 4);
    }

    // ------------------ Task Manager Menu ------------------
    static void RunTaskManager(ConsoleColor color)
    {
        Console.ForegroundColor = color; // set section color
        int choice;
        do
        {
            Console.WriteLine("\nTask Manager Options:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Filter by Priority");
            Console.WriteLine("6. Sort by Due Date");
            Console.WriteLine("7. Back to Main Menu");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = color;
                continue;
            }

            switch (choice)
            {
                case 1: TaskItem.AddTask(); break;
                case 2: TaskItem.ViewAllTasks(); break;
                case 3: TaskItem.MarkTaskCompleted(); break;
                case 4: TaskItem.DeleteTask(); break;
                case 5: TaskItem.FilterTasksByPriority(); break;
                case 6: TaskItem.SortTasksByDueDate(); break;
                case 7: break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option!");
                    Console.ForegroundColor = color;
                    break;
            }

        } while (choice != 7);

        Console.ResetColor(); // reset when leaving module
    }

    // ------------------ Student Manager Menu ------------------
    static void RunStudentManager(ConsoleColor color)
    {
        Console.ForegroundColor = color; // set section color
        int choice;
        do
        {
            Console.WriteLine("\nStudent Management Options:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Add Grade to Student");
            Console.WriteLine("4. Calculate Average for Student");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = color;
                continue;
            }

            switch (choice)
            {
                case 1: Student.AddStudent(); break;
                case 2: Student.ViewAllStudents(); break;
                case 3: Student.AddGradeToStudent(); break;
                case 4: Student.CalculateAverageForStudent(); break;
                case 5: break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option!");
                    Console.ForegroundColor = color;
                    break;
            }

        } while (choice != 5);

        Console.ResetColor(); // reset when leaving module
    }
}
