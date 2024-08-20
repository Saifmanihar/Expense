namespace Expense.Models
{
    public interface TransactionInterface
    {
        Transaction GetAllTranaction(Transaction transaction);
        Transaction CreateTransaction(Transaction transaction);
    }
}
