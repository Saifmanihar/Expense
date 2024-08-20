using Expense.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expense.Controllers
{
    public class TransactionController : Controller
    {
        private readonly CategoryInterface categoryInterface;
        private readonly AppDb appDb;


        public TransactionController(CategoryInterface categoryInterface)
        {
            this.categoryInterface = categoryInterface;
        }

        public IActionResult Index()
        {
            PopulateCollection();

            return View();
        }
        [HttpPost]
        public IActionResult Index(Transaction transaction)
        {
            
            if (ModelState.IsValid)
            {
                categoryInterface.CreateTransaction(transaction);
            }
            return RedirectToAction("TransactionList");
        }


        [HttpGet]
        public IActionResult TransactionList()
        {
            var Transaction = categoryInterface.GetAllTranaction();
            return View(Transaction);
        }


        [HttpGet]
        public IActionResult TransActionDetails(int id)
        {
            var TransactionId = categoryInterface.GetTransactionbyId(id);
            ViewBag.categories = categoryInterface.GetAllCategory().Select(c => new { CategoryId = c.CategoryId, TitleWithIcon = c.TitleWithIcon });
            return View(TransactionId); 
        }

        [HttpPost]
        public IActionResult TransActionDetails(Transaction transaction)
        {
            var TransactionUpdate = categoryInterface.UpdateTransaction(transaction);
            return RedirectToAction("TransactionList");
        }

        [HttpPost]
        public IActionResult TransActionDelete(int Id)
        {
            Transaction TransactionUpdate = categoryInterface.DeleteTransaction(Id);
            return RedirectToAction("TransactionList");
        }

        [NonAction]
        public void PopulateCollection()
        {
           var CategoryCollection = categoryInterface.GetAllCategory();
            ViewBag.categories = CategoryCollection;
        }
    }
}
