using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using Microsoft.EntityFrameworkCore;

public class TransactionsController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }


    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }


    private MyContext db;
    public TransactionsController(MyContext context)
    {
        db = context;
    }


    [HttpGet("/accounts/")]
    public IActionResult Account()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Homepage", "Users");
        }
        decimal Balance = db.Transactions.Sum(i => i.Amount);
        HttpContext.Session.SetInt32("UserBalance", (int)Balance);

        List<Transaction> AllTransactions = db.Transactions.Include( i => i.Customer).ToList();
        return View("Account", AllTransactions);
    }


    [HttpPost("/transaction")]
    public IActionResult Transaction(Transaction NewTransaction)
    {
        decimal Balance = db.Transactions.Sum(i => i.Amount);
        if (Balance + NewTransaction.Amount < 0)
        {
            ModelState.AddModelError("Amount", "Not enough funds");
            return RedirectToAction("Account");
        }

        NewTransaction.UserId = (int)uid;
        db.Transactions.Add(NewTransaction);
        db.SaveChanges();
        return RedirectToAction("Account");
    }

}