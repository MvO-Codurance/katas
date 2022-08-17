namespace Bank;

public class AccountService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IStatementPrinter _statementPrinter;

    public AccountService(
        ITransactionRepository transactionRepository,
        IStatementPrinter statementPrinter)
    {
        _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        _statementPrinter = statementPrinter ?? throw new ArgumentNullException(nameof(statementPrinter));
    }
    
    public void Deposit(int amount)
    {
        _transactionRepository.Deposit(amount);
    }
    
    public void Withdraw(int amount)
    {
        _transactionRepository.Withdraw(amount);
    }
    
    public void PrintStatement()
    {
        var transactions = _transactionRepository.GetTransactions();
        var formattedTransactions = FormatTransactions(transactions);
        
        _statementPrinter.PrintLine("Date       || Amount || Balance");
        foreach (string formattedTransaction in formattedTransactions)
        {
            _statementPrinter.PrintLine(formattedTransaction);
        }
    }

    private List<string> FormatTransactions(List<Transaction> transactions)
    {
        int balance = 0;
        var formattedTransactions = new List<string>();

        foreach (var transaction in transactions)
        {
            balance += transaction.Amount;
            formattedTransactions.Add($"{transaction.Date} || {transaction.Amount}   || {balance}");
        }

        formattedTransactions.Reverse();
        
        return formattedTransactions;
    }
}