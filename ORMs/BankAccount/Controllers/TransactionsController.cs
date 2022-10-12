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


    [HttpGet("/accounts/{id}")]
    public IActionResult Account(int id)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Homepage", "Users");
        }

        if (id != uid)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Homepage", "Users");
        }

        decimal Balance = db.Transactions.Where(i => i.UserId == id).Sum(i => i.Amount);
        HttpContext.Session.SetInt32("UserBalance", (int)Balance);

        List<Transaction> AllTransactions = db.Transactions.Include( i => i.Customer).Where( c => c.UserId == id).ToList();
        return View("Account", AllTransactions);
    }


    [HttpPost("/transaction")]
    public IActionResult Transaction(Transaction NewTransaction)
    {
        if (HttpContext.Session.GetInt32("UserBalance") + NewTransaction.Amount < 0)
        {
            ModelState.AddModelError("Amount", "Not enough funds");
            return Account((int)HttpContext.Session.GetInt32("UserId"));
        }

        NewTransaction.UserId = (int)uid;
        db.Transactions.Add(NewTransaction);
        db.SaveChanges();
        return Redirect($"/accounts/{NewTransaction.UserId}");
    }

}