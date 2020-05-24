using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFLibrary
{
    public partial class Transaction
    {
        private DataContext _db;
        public Transaction(DataContext db)
        {
            _db = db;
        }

        public List<T> GetAll<T>() where T : class
        {
            var transactions = _db.Transactions.ToList();
            List<T> result = new List<T>();
            foreach (Transaction transaction in transactions)
            {
                result.Add(transaction as T);
            }
            return result;
        }

        public List<Transaction> getAllTransactionsById(int Id)
        {
            List<Transaction> transactions = _db.Transactions.ToList();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.userID != Id)
                {
                    transactions.Remove(transaction);
                }
            }
            return transactions;
        }
        public List<Transaction> getAllTransactionsBySubmittedId(int Id)
        {
            var transactions = _db.Transactions.ToList();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.SubmittedUserID != Id)
                {
                    transactions.Remove(transaction);
                }
            }
            return transactions;
        }
        public void Add<T>(T thing) where T : class
        {
            Transaction transaction = thing as Transaction;
            transaction.Date = DateTime.Now;
            _db.Transactions.Add(transaction);
            _db.SaveChanges();
        }
        public void AddMultiple(List<Transaction> thing)
        {
            foreach(Transaction transaction in thing)
            {
                transaction.Date = DateTime.Now;
            }
            _db.Transactions.AddRange(thing);
            _db.SaveChanges();
        }
    }
}
