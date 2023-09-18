using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCWebApp.Models
{
    [Table("Bank", Schema = "dbo")]
    public class Bank
    {
        public Bank() { }
        [Key]
        [Column("BankID", TypeName = "int")]
        public int BankId { get; set; }
        [Column("BankName", TypeName = "varchar(50")]
        public string BankName{ get; set; }
        [Column("BankAlias", TypeName = "varchar(10)")]
        public string BankAlias { get; set; }
        [Column("BankCode", TypeName = "int")]
        public int BankCode { get; set; }

    }
}
