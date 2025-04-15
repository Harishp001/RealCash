using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealCash.Models
{
    public class UserDetailsModel
    {
        public int UserId { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }
    }
}