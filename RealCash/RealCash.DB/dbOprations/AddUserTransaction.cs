using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealCash.Models;
using RealCash.RealCash.DB;

namespace RealCash.RealCash.DB.dbOprations
{
    public class AddUserTransaction
    {
        private readonly RealCashEntities _DBContext;

        public AddUserTransaction()
        {
            _DBContext = new RealCashEntities();
        }

        public void AddTransaction(int userId, decimal amount, string type)
        {
            var user = _DBContext.UserData.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                var transaction = new Transactions
                {
                    UserId = userId,
                    UserName = user.Name,   // Save username
                    Amount = amount,
                    Type = type,
                    Date = DateTime.Now
                };

                _DBContext.Transactions.Add(transaction);
                _DBContext.SaveChanges();
            }
        }

        public List<TransactionModel> GetAllTransactions()
        {
            var data = (from t in _DBContext.Transactions
                        join u in _DBContext.UserData on
                        t.TransactionId equals u.Id
                        select new TransactionModel
                        {
                            UserName = u.Name,              // Getting User's Name
                            Amount = t.Amount ?? 0,          // In case Amount is nullable
                            Type = t.Type,
                            Date = t.Date ?? DateTime.Now
                        }).ToList();

            return data;
        }
    }
}