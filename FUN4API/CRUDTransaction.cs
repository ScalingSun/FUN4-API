using EFLibrary;
using FUN4API.Model;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUN4API
{
    public class CRUDTransaction
    {
        Transaction transaction = null;

        public CRUDTransaction(DataContext db)
        {
            transaction = new Transaction(db);
        }

        public List<T> GetAll<T>() where T : class
        {
            return transaction.GetAll<T>();
        }
        public List<Transaction> GetByUserId(int Id)
        {
            return transaction.getAllTransactionsById(Id);
        }
        public List<Transaction> GetByUserSubmittedId(int Id)
        {
            return transaction.getAllTransactionsBySubmittedId(Id);
        }
        public void Add<T>(T obj) where T : class
        {
            TransactionModel model = obj as TransactionModel;
            Transaction thing = new Transaction(model.Id,model.Amount,model.UserID,model.SubmittedUserID,model.Date);
            transaction.Add(thing);
        }
    }
}
