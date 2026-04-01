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
Console.WriteLine($"{"S/N",-4} | {"Date",-11} | {"Type",-10} | {"Description",-25} | {"Category",-15} | {"Amount (£)",12}");
Console.WriteLine(new string('-', 95));



        foreach (var t in _transactions)
        
        {
             string typeLabel = t.IsIncome  ? "Income" : "Expense";
            Console.WriteLine($"{t.Id,-4} | {t.Date,-11:dd MMM yyyy} | {typeLabel,-10} | {t.Description,-25} | {t.Category,-15} | {t.Amount,12:C}");
        }
    }
}