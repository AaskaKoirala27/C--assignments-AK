using System;
using System.IO;

class Banking
{
    static string filePath = "users.txt";

    public static void RunBanking(ConsoleColor sectionColor)
    {
        Console.ForegroundColor = sectionColor;

        int mainChoice;
        do
        {
            Console.WriteLine("\n------- Simple Bank System --------");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out mainChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = sectionColor;
                continue;
            }

            switch (mainChoice)
            {
                case 1: CreateAccount(); break;
                case 2: LoginAndBankMenu(); break;
                case 3: Console.WriteLine("Exiting Banking..."); break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option!");
                    Console.ForegroundColor = sectionColor;
                    break;
            }

        } while (mainChoice != 3);

        Console.ResetColor(); // reset after leaving module
    }

    static void CreateAccount()
    {
        Console.Write("Create username: ");
        string username = Console.ReadLine() ?? "";

        if (UserExists(username))
        {
            Console.WriteLine("Username exists.");
            return;
        }

        Console.Write("Create password: ");
        string password = Console.ReadLine() ?? "";

        File.AppendAllText(filePath, username + "," + password + Environment.NewLine);
        Console.WriteLine("Account created successfully.");
    }

    static void LoginAndBankMenu()
    {
        if (!File.Exists(filePath)) { Console.WriteLine("Create an account first."); return; }

        Console.Write("Username: "); string username = Console.ReadLine() ?? "";
        Console.Write("Password: "); string password = Console.ReadLine() ?? "";

        bool loggedIn = false;
        foreach (var line in File.ReadAllLines(filePath))
        {
            var data = line.Split(',');
            if (data.Length >= 2 && data[0] == username && data[1] == password)
            {
                loggedIn = true;
                break;
            }
        }

        if (!loggedIn) { Console.WriteLine("Invalid credentials."); return; }

        Console.WriteLine("Login successful.");
        double balance = 0;
        int choice;

        do
        {
            Console.WriteLine("\n--- Bank Menu ---");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Logout");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ResetColor();
                continue;
            }

            switch (choice)
            {
                case 1: balance = Deposit(balance); break;
                case 2: balance = Withdraw(balance); break;
                case 3: CheckBalance(balance); break;
                case 4: Console.WriteLine("Logged out."); break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }

        } while (choice != 4);
    }

    static bool UserExists(string username)
    {
        if (!File.Exists(filePath)) return false;
        foreach (var line in File.ReadAllLines(filePath))
        {
            var data = line.Split(',');
            if (data[0] == username) return true;
        }
        return false;
    }

    static double Deposit(double balance)
    {
        Console.Write("Enter amount to deposit: ");
        if (double.TryParse(Console.ReadLine(), out double amt) && amt > 0)
        {
            balance += amt;
            Console.WriteLine($"Deposited {amt}, New Balance: {balance}");
        }
        else Console.WriteLine("Invalid amount.");
        return balance;
    }

    static double Withdraw(double balance)
    {
        Console.Write("Enter amount to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double amt) && amt > 0)
        {
            if (amt <= balance)
            {
                balance -= amt;
                Console.WriteLine($"Withdrawn {amt}, Remaining Balance: {balance}");
            }
            else Console.WriteLine("Insufficient funds.");
        }
        else Console.WriteLine("Invalid amount.");
        return balance;
    }

    static void CheckBalance(double balance)
    {
        Console.WriteLine($"Current Balance: {balance}");
    }
}
