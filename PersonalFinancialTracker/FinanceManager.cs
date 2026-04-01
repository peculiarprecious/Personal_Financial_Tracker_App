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
        string msg = "Hello! Welcome to your personal financial tracker app.";

        Console.WriteLine(msg);

        Console.WriteLine(new string('-', 120));
    }
}