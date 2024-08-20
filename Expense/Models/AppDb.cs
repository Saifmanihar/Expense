using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Expense.Models
{
    public class AppDb : IdentityDbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }




    }
}
