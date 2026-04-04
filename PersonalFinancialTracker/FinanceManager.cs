namespace PersonalFinancialTracker;
public class FinanceManager
{
    private readonly List<Transaction> _transactions =[];

    public void AddTransaction(Transaction transaction)
    {
        if (transaction == null)
        {
            Console.WriteLine("Transaction cannot be empty");
            return;
        }
        _transactions.Add(transaction);

        string status = transaction.IsIncome  ? "Income" : "Expense";

        
        Console.WriteLine($"\n Transaction in form of {status} has been added to {transaction.Category}");
    }

    public void WelcomeNote()
    {
        Console.WriteLine("Please enter your name:");
        string? input = Console.ReadLine();

        string username = !string.IsNullOrWhiteSpace(input) ?input : "Guest";
        
        string msg = $"Hello {username}! Welcome to your personal financial tracker app.";

        Console.WriteLine(msg);
    }

    public void DisplayFinaces()
    {
        if (_transactions.Count == 0)
        {
            Console.WriteLine("No record has been added yet!");
            return;
        }
// Table Headers
       
// Table Headers
Console.WriteLine($"{"S/N",-4} | {"Date & Time",-17} | {"Type",-10} | {"Description",-40} | {"Category",-15} | {"Amount (£)",12}");
Console.WriteLine(new string('-', 116));



        foreach (var t in _transactions)
        
        {
             string typeLabel = t.IsIncome  ? "Income" : "Expense";
            Console.WriteLine($"{t.Id,-4} | {t.Date,-17:dd MMM yyyy HH:mm} | {typeLabel,-10} | {t.Description,-35} | {t.Category,-15} | {t.Amount,12:C}");
        }
    }

public decimal GetCurrentBal()
    {
        decimal income;
        decimal expense;

        if (_transactions == null)
        {
            Console.WriteLine("No record yet;");
            return 0;
        }

        income = _transactions.Where(t=> t.IsIncome).Sum(t=>t.Amount);
        expense = _transactions.Where(t=> !t.IsIncome).Sum(t=>t.Amount);

        return income -expense;

    }

    public decimal GetAllIncome(){
        if (_transactions == null)
        {
            return 0;
        }
         return _transactions.Where(t => t.IsIncome).Sum(t => t.Amount);
    }
     public decimal GetAllExpense(){
        if (_transactions == null)
        {
            return 0;
        }
         return _transactions.Where(t => !t.IsIncome).Sum(t => t.Amount);
    }
     public void DisplaySummary()
    {
        Console.WriteLine($"\n--- Financial Summary ---");
        Console.WriteLine($"Total Transactions: {_transactions.Count}");
        Console.WriteLine($"Current Balance:   {GetCurrentBal(),12:C}");
        Console.WriteLine($"Total Income:   {GetAllIncome(),12:C}");
         Console.WriteLine($"Total Expense:   {GetAllExpense(),12:C}");
    }
}