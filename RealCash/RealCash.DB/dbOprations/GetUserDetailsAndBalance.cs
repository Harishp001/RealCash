using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Util;
using RealCash.Models;

namespace RealCash.RealCash.DB.dbOprations
{
    public class GetUserDetailsAndBalance
    {
        private readonly RealCashEntities _DBContext;

        public GetUserDetailsAndBalance()
        {
            _DBContext = new RealCashEntities();
        }

        public UserDetailsModel GetUserDetails(int userId)
        {
            var data = (from u in _DBContext.UserData
                        join b in _DBContext.UserBalance
                        on u.Id equals b.UserId
                        where u.Id == userId
                        select new UserDetailsModel
                        {
                            UserId = u.Id,
                            Name = u.Name,
                            Balance = b.Balance ?? 0
                        }).FirstOrDefault();

            return data;
        }
    }

}