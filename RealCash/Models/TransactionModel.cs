using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealCash.Models
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}