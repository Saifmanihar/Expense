namespace Expense.Models
{
    public interface CategoryInterface
    {
        Category AddCategory(Category category);
        Category GetCategorybyId(int Id);
        Category DeleteCategory(int Id);
        IEnumerable<Category> GetAllCategory();
        Category UpdateCategory(Category category);

        //transaction 
        Transaction CreateTransaction(Transaction transaction);
        IEnumerable<Transaction> GetAllTranaction();
        Transaction GetTransactionbyId(int Id);

        Transaction UpdateTransaction(Transaction transaction);
        Transaction DeleteTransaction(int Id);

    }
}
