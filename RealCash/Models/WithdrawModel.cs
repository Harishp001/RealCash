using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealCash.Models
{
    public class WithdrawModel
    {
        public int UserId { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }

        public List<string> SelectedAmounts { get; set; }

        public bool IsSelected2000 { get; set; }
        public bool IsSelected500 { get; set; }
        public bool IsSelected200 { get; set; }
        public bool IsSelected100 { get; set; }

        public int Quantity2000 { get; set; }
        public int Quantity500 { get; set; }
        public int Quantity200 { get; set; }
        public int Quantity100 { get; set; }
        public int TotalAmount { get; set; }
    }
}