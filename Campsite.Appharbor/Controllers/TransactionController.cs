using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Campsite.Models.Transaction;
using Campsite.Services;
using Microsoft.AspNet.Identity;

namespace Campsite.Appharbor.Controllers
{
    [Authorize]
    public class TransactionController : ApiController
    {
        // GET /api/transaction
        public IHttpActionResult GetAll()
        {
            var service = CreateTransactionService();

            var transactions = service.GetTransactions();

            return Ok(transactions);
        }

        // GET /api/inventory/5
        public IHttpActionResult Get(int id)
        {
            var service = CreateTransactionService();

            var transaction = service.GetTransactionById(id);

            return Ok(transaction);
        }

        // POST /api/inventory
        public IHttpActionResult Post(TransactionCreate transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.CreateTransaction(transaction))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(TransactionEdit transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.UpdateTransaction(transaction))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTransactionService();

            if (!service.DeleteTransaction(id))
                return InternalServerError();

            return Ok();
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var transactionService = new TransactionService(userId);
            return transactionService;
        }
    }
}
