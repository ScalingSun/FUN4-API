using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUN4API.Model
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int UserID { get; set; }
        public int SubmittedUserID { get; set; }
        public DateTime Date {get;set;}

        public TransactionModel()
        {

        }
        public TransactionModel(int id, decimal amount, int userID, int submittedUserID,DateTime date)
        {
            this.Id = id;
            this.Amount = amount;
            this.UserID = userID;
            this.SubmittedUserID = submittedUserID;
            date = DateTime.Now;
        }
    }
}
