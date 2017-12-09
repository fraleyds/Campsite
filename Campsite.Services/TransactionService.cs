using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Models.Transaction;

namespace Campsite.Services
{
    public class TransactionService : ITransactionService
    {
        public bool CreateTransaction(TransactionCreate model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public TransactionDetail GetTransactionById(int transactionId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
