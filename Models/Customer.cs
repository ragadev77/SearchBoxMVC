using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCWebApp.Models
{
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        public Customer() { }
        [Key]
        [Column("CustomerID", TypeName = "int")]
        public int CustomerId { get; set; }
        [Column("CustomerName", TypeName = "varchar(50")]
        public string CustomerName{ get; set; }
        [Column("Address", TypeName = "varchar(10)")]
        public string Address { get; set; }
        [Column("PhoneNumber", TypeName = "varchar(20)")]
        public string PhoneNumber { get; set; }
        [Column("Email", TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column("CreditScore", TypeName = "int")]
        public int CreditScore { get; set; }

    }
}
