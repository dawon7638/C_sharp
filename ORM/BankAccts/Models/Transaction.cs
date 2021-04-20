using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccts.Models
{
    public class Transaction
    {
        [Key]
        /////////////TRANSACTION ID\\\\\\\\\\\\\\\
        public int TransactionId { get; set; }
        //////////////////////////////////

        /////////////TRANSACTION AMOUNT\\\\\\\\\\\\\\\
        [DisplayFormat(DataFormatString = "{C}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Deposit/Withdraw:")]
        public decimal Amount { get; set; }
        //////////////////////////////////

        //////////CREATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        //////////UPDATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

         //////RELATIONSHIP(navigation) PROPERTY AND *FOREIGN KEY FOR USER MODEL||||||
        // 1 USER: many TRANSACTIONS.
        [Display(Name = "User")]
        public int UId { get; set; }//Foreign Key
        public User AccountHolder { get; set; }//Navigation Property
        //////////////////////////////////
    }
}