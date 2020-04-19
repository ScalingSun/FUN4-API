using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ITransaction
    {
         int id { get; }
         decimal Amount { get; }
         int userID { get; }
         int SubmittedUserID { get; }
    }
}
