using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Models.Transaction;

namespace Campsite.Contracts
{
    public interface ITransactionService
    {
        bool CreateTransaction(TransactionCreate model);
        IEnumerable<TransactionListItem> GetTransactions();
        TransactionDetail GetTransactionById(int transactionId);
        bool UpdateTransaction(TransactionEdit model);
        bool DeleteTransaction(int transactionId);
    }
}
