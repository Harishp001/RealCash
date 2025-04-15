using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealCash.Models;
using RealCash.RealCash.DB;
using RealCash.RealCash.DB.dbOprations;

namespace RealCash.Controllers
{
    public class HomeController : Controller
    {
        private readonly RealCashEntities _dbContext = new RealCashEntities();
        private readonly GetUserDetailsAndBalance _getDetails = new GetUserDetailsAndBalance();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainPage()
        {
            ViewBag.Message = TempData["SuccessMessage"];
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                using (var db = new RealCashEntities())
                {
                    var user = db.UserData.FirstOrDefault(x => x.Name == login.Name && x.Pin == login.Pin);
                    if (user != null)
                    {
                        Session["UserId"] = user.Id;
                        return RedirectToAction("MainPage", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please enter correct details.");
                        return View(login);
                    }
                }
            }
            return View(login);
        }

        public ActionResult Deposit()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            if (Session["UserId"] == null)
            {
                TempData["Message1"] = "User not logged in.";
                return RedirectToAction("Login");
            }
            else
            {
                var userData = _getDetails.GetUserDetails(userId);

                return View(userData);
            }
            
        }

        [HttpPost]
        public ActionResult Deposit(int depositAmount)
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            var balance = _dbContext.UserBalance.FirstOrDefault(x => x.UserId == userId);

            if (balance != null)
            {
                balance.Balance += depositAmount;
                _dbContext.SaveChanges();

                AddUserTransaction addTransaction = new AddUserTransaction();
                addTransaction.AddTransaction(userId, depositAmount, "Deposit");

                ViewBag.SuccessMessage = depositAmount;
                TempData["SuccessMessage"] = $"Successfully deposited ₹{depositAmount}!";
            }
            return RedirectToAction("MainPage");
        }

        public ActionResult ViewBalance()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            if(Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "User Not logged in.";
                return RedirectToAction("Login");
            }
            else
            {
                var userBalance = _getDetails.GetUserDetails(userId);
                return View(userBalance);
            }
        }

        public ActionResult Withdraw()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "User Not logged in.";
                return RedirectToAction("Login");
            }
            else
            { 
                return View();
            }
        }

        [HttpPost]
        public ActionResult Withdraw(WithdrawModel model)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var balance = _dbContext.UserBalance.FirstOrDefault(x => x.UserId == userId);
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "User Not logged in.";
                return RedirectToAction("Login");
            }
            else
            {
                int totalAmount = 0;

                if (model.IsSelected2000 && model.Quantity2000>0)
                {
                    totalAmount += 2000 * model.Quantity2000; 
                }
                if (model.IsSelected500 && model.Quantity500 > 0)
                {
                    totalAmount += 500 * model.Quantity500;
                }
                if (model.IsSelected200 && model.Quantity200 > 0)
                {
                    totalAmount += 200 * model.Quantity200;
                }
                if (model.IsSelected100 && model.Quantity100 > 0)
                {
                    totalAmount += 100 * model.Quantity100;
                }

                if (balance.Balance >= totalAmount)
                {
                    balance.Balance -= totalAmount;
                    _dbContext.SaveChanges();

                    AddUserTransaction addTransaction = new AddUserTransaction();
                    addTransaction.AddTransaction(userId, totalAmount, "Withdraw");

                    ViewBag.total = totalAmount;
                    TempData["SuccessMessage"] = $"You have successfully withdrawn ₹{totalAmount}.";
                    return RedirectToAction("MainPage");
                }
                return View("Withdraw");
            }
        }

        public ActionResult ViewTransactions()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "User Not logged in.";
                return RedirectToAction("Login");
            }
            else
            {
                var transactions = _dbContext.Transactions
                                .Where(t => t.UserId == userId)
                                .ToList();

                var transactionModels = transactions.Select(t => new TransactionModel
                {
                    TransactionId = t.TransactionId,
                    UserName = _dbContext.UserData.FirstOrDefault(u => u.Id == userId)?.Name,
                    Type = t.Type,
                    Amount = t.Amount ?? 0,
                    Date = t.Date ?? DateTime.Now
                }).ToList();

                return View(transactionModels);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear(); // Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
    }
}