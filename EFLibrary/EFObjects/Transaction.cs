using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFLibrary
{
    public partial class Transaction
    {
        public int id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int userID { get; set; }
        [Required]
        public int SubmittedUserID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Transaction(int id, decimal amount, int userID, int submittedUserID, DateTime date)
        {
            this.id = id;
            Amount = amount;
            this.userID = userID;
            SubmittedUserID = submittedUserID;
            Date = date;
        }
    }
}
