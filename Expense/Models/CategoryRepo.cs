using System.Linq;

namespace Expense.Models
{
    public class CategoryRepo : CategoryInterface
    {
        private List<Category> _categories;
        private List<Transaction> _transaction;
        public Category AddCategory(Category category)
        {
            category.CategoryId = _categories.Max(x => x.CategoryId) + 1;
            _categories.Add(category);
            return category;
        }

        public Category DeleteCategory(int Id)
        {
            Category category = _categories.FirstOrDefault(x => x.CategoryId == Id);
            if (category != null)
            {
                _categories.Remove(category);
            }
            return category;
        }

        public Category GetCategorybyId(int Id)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == Id);
            return category;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            var CategoryCollection = _categories.ToList();
            Category Defaultcategory = new Category() { CategoryId = 0, Title = "choose your option" };
            CategoryCollection.Insert(0, Defaultcategory);
            return _categories;
        }

        public Category UpdateCategory(Category category)
        {
            Category Newcategory = _categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (Newcategory != null)
            {
                Newcategory.CategoryId = category.CategoryId;
                Newcategory.Title = category.Title;
                Newcategory.Icon = category.Icon;
                Newcategory.Type = category.Type;
            }
            return Newcategory;
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            transaction.TransactionId = _transaction.Max(x => x.TransactionId) + 1;
            _transaction.Add(transaction);
            return transaction;
        }

        public IEnumerable<Transaction> GetAllTranaction()
        {
            return _transaction;
        }

        public Transaction GetTransactionbyId(int Id)
        {
            var transaction = _transaction.FirstOrDefault(x => x.TransactionId == Id);
            return transaction;
        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            var Oldtransaction = _transaction.FirstOrDefault(x => x.TransactionId == transaction.TransactionId);
            if (Oldtransaction != null)
            {
                Oldtransaction.TransactionId = transaction.TransactionId;
                Oldtransaction.TransactionDate = transaction.TransactionDate;
                Oldtransaction.CategoryId = transaction.CategoryId;
                Oldtransaction.Amount = transaction.Amount;
                Oldtransaction.note = transaction.note;
                Oldtransaction.note = transaction.note;

            }
            return Oldtransaction;
        }

        public Transaction DeleteTransaction(int Id)
        {
            var TransactionId = _transaction.FirstOrDefault(x => x.TransactionId == Id);
            if(TransactionId != null)
            {
                _transaction.Remove(TransactionId);
            }
            return TransactionId;
        }


    }
}
