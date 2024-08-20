using Expense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Expense.Controllers
{
    public class DashBoard : Controller
    {
        private readonly AppDb appDb;

        public DashBoard(AppDb appDb)
        {
            this.appDb = appDb;
        }

        public async Task<IActionResult> Index()
        {
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransaction = await appDb.Transactions
                .Include(s => s.Category)
                .Where(t => t.TransactionDate >= StartDate && t.TransactionDate <= EndDate)
                .ToListAsync();

            int Income = SelectedTransaction
                .Where(i => i.Category.Type == "Income")
                .Sum(a => a.Amount);
            ViewBag.Income = Income;

            int Expense = SelectedTransaction
            .Where(i => i.Category.Type == "Expense")
            .Sum(a => a.Amount);
            ViewBag.Expense = Expense;


            int balance = Income - Expense;

            ViewBag.balance = balance;
            return View();

        }

    }
}
