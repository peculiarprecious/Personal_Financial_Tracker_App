

using System.Net.Security;

namespace PersonalFinancialTracker;
    public class Transaction
{
    private static int _idCounter = 1;
    public int Id {get; set;}
    public  string Description {get; set;}
    private decimal _amount ;
    public string Category {get; set;} = "General";
    public bool IsIncome {get; set;} // True = Money In; False = Money out
    public DateTime Date {get; set;} = DateTime.Now;



public decimal Amount
    {
        get => _amount;

        set
        {
            if (value > 0)
            {
                _amount = value;
            }
            else
            {
                Console.WriteLine("Amount cannot be zero and negative");
            }
        }
    }

public Transaction(string desc, decimal amount, string category, bool isIncome)
    {
        this.Id = _idCounter++;
        this.Description = desc;
        this.Amount = amount;
        this.Category = category;
        this.IsIncome = isIncome;

    }


}



