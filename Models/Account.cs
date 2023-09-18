using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCWebApp.Models
{
    [Table("Account", Schema = "dbo")]
    public class Account
    {
        public Account() { }
        [Key]
        [Column("AccountID", TypeName = "int")]
        public int AccountId { get; set; }
        [Column("CustomerID", TypeName = "int")]
        public int CustomerID { get; set; }
        [Column("AccountNumber", TypeName = "varchar(10)")]
        public string AccountNo { get; set; }
        [Column("CardNumber", TypeName = "varchar(20)")]
        public string CardNo { get; set; }
        [Column("BankID", TypeName = "int")]
        public int BankID { get; set; }
        [Column("CreditLimit", TypeName = "decimal(10,2)")]
        public decimal CreditLimit { get; set; }
        [Column("InterestRate", TypeName = "decimal(6,2)")]
        public decimal InterestRate { get; set; }
        [Column("Balance", TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }
        [Column("PaymentDueDate", TypeName = "date")]
        public DateTime PaymentDueDate { get; set; }

        public string CustomerName { get; set; }
        public string BankName { get; set; }



    }
}
