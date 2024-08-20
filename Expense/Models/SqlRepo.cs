using Microsoft.EntityFrameworkCore;

namespace Expense.Models
{
    public class SqlRepo : CategoryInterface
    {
        private readonly AppDb appDb;

        public SqlRepo(AppDb appDb)
        {
            this.appDb = appDb;
        }

        public Category AddCategory(Category category)
        {
            appDb.categories.Add(category);
            appDb.SaveChanges();
            return category;
        }

        public Category DeleteCategory(int Id)
        {
          var category =  appDb.categories.Find(Id);
            if(category!= null)
            {
                appDb.categories.Remove(category);
                appDb.SaveChanges();
            }
            return category;
        }

        public Category GetCategorybyId(int Id)
        {
                return appDb.categories.Find(Id);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            var CategoryCollection = appDb.categories.ToList();
            Category Defaultcategory = new Category() { CategoryId = 0, Title = "choose your option" };
            CategoryCollection.Insert(0, Defaultcategory);
            return appDb.categories;
        }

        public Category UpdateCategory(Category category)
        {
            var categoryId = appDb.categories.Attach(category);
            categoryId.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDb.SaveChanges();
            return category;
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            appDb.Transactions.Add(transaction);
            appDb.SaveChanges();
            return transaction;
        }

        public IEnumerable<Transaction> GetAllTranaction()
        {
            var Tranlist = appDb.Transactions.Include(t => t.Category);
            return Tranlist;
        }

        public Transaction GetTransactionbyId(int Id)
        {
            var transaction = appDb.Transactions
                                    .Include(t => t.Category)
                                    .FirstOrDefault(t => t.TransactionId == Id);
            return transaction;

        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            var TransactionUpdate = appDb.Transactions.Attach(transaction);
            TransactionUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDb.SaveChanges();
            return transaction;
        }

        public Transaction DeleteTransaction(int Id)
        {
            var TransactionId = appDb.Transactions.Include(t => t.Category)
                                                    .FirstOrDefault(t => t.TransactionId == Id);
            if (TransactionId != null)
            {
                appDb.Transactions.Remove(TransactionId);
                appDb.SaveChanges();
            }
            return TransactionId;
        }



    }
}
