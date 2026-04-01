
namespace PersonalFinancialTracker;

public class Program
{
    public static void Main(String[] args)
    {
        FinanceManager myFinance = new FinanceManager();

        myFinance.WelcomeNote();

        bool isActiveMenu = true;

        while (isActiveMenu)


        {
            DisplayMenu();

            if (!int.TryParse(Console.ReadLine(), out int input))
            {

                Console.WriteLine("Input must be an Integer");
                continue;
            }

            switch (input)
            {
                case 1:
                    //Add Transaction
                    AddNewtransaction(myFinance);
                    break;

                    case 2:
                    // Display transaction
                    myFinance.DisplayFinaces();
                    break;
                case 6:
                    isActiveMenu = false;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid selection, please try again.");
                    break;
            }


        }
    }


    static void DisplayMenu()
    {
        Console.WriteLine("1.  Add New Transaction");
        Console.WriteLine("2.  View All Transaction");
        Console.WriteLine("3.  Display Income");
        Console.WriteLine("4.  Display Expenses");
        Console.WriteLine("5.  Display Summary");
        Console.WriteLine("6. Exit");
        Console.Write("\nEnter choice: ");
    }

    static void AddNewtransaction(FinanceManager f)
    {
        Console.WriteLine($"\n----Add new transaction----");

        Console.Write("Enter Description: ");
        string desc = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(desc))
        {
            Console.WriteLine("Description cannot be empty!");
            return;
        }

        Console.Write("Enter amount: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine($"\n Invalid amount.");
            return;
        }

        Console.Write("Enter Category: ");

        string? input = Console.ReadLine();
        string category;

        if (string.IsNullOrWhiteSpace(input))
        {
            category = "General";
        }
        else
        {
            category = input;
        }

        Console.WriteLine("Select Transaction Type:");
        Console.WriteLine("1. Income");
        Console.WriteLine("2. Expense");
        string? selection = Console.ReadLine();

        bool tType = false; // Default to Expense

        if (selection == "1")
        {
            tType = true;
        }
        else if (selection == "2")
        {
            tType = false;
        }
        else
        {
            Console.WriteLine("Invalid Transaction type");
        }


        Transaction t = new Transaction(desc, amount, category, tType);

        f.AddTransaction(t);

    }


}