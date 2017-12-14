using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Data;
using Campsite.Models.Transaction;

namespace Campsite.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new TransactionEntity()
                {
                    UserId = _userId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    FinalPrice = model.FinalPrice
                };
            using (var ctx = new CampsiteDbContext())
            {
                ctx.Transaction.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new CampsiteDbContext())
            {
                var query =
                    ctx
                        .Transaction
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    TransactionId = e.TransactionId,
                                    StartDate = e.StartDate,
                                    EndDate = e.EndDate,
                                    FinalPrice = e.FinalPrice
                                }
                        );
                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int transactionId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Transaction
                        .Single(e => e.TransactionId == transactionId && e.UserId == _userId);

                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
                        StartDate = entity.StartDate,
                        EndDate = entity.EndDate,
                        FinalPrice = entity.FinalPrice
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Transaction
                        .Single(e => e.TransactionId == model.TransactionId && e.UserId == _userId);

                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.FinalPrice = model.FinalPrice;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Transaction
                        .Single(e => e.TransactionId == transactionId && e.UserId == _userId);

                ctx.Transaction.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
