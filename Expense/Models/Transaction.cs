using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Please select the value")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "nvarchar(75)")]

        public string? note { get; set; }

        public DateTime TransactionDate { get; set; }

        [NotMapped]
        public string? TitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Title+" "+ Category.Icon;
            }
        }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "-" : "+") + Amount.ToString("C0");
            }
        }
    }
}
