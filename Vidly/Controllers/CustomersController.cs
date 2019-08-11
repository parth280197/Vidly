﻿using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
  public class CustomersController : Controller
  {
    // GET: Customer
    private ApplicationDbContext _context;

    public CustomersController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }
    public ViewResult Index()
    {
      var customers = _context.Customers;
      return View(customers);
    }

    public ActionResult Edit(int id)
    {
      var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
      if (customer == null)
        return HttpNotFound();
      var viewModel = new CustomerFormViewModel()
      {
        Customer = customer,
        MembershipTypes = _context.MembershipTypes.ToList(),
      };
      return View("CustomerForm", viewModel);

    }

    public ActionResult Save()
    {
      var membershiptype = _context.MembershipTypes.ToList();
      var viewModel = new CustomerFormViewModel()
      {
        MembershipTypes = membershiptype
      };
      return View("CustomerForm", viewModel);
    }
    [HttpPost]
    public ActionResult save(Customer customer)
    {
      if (!ModelState.IsValid)
      {
        var ViewModel = new CustomerFormViewModel()
        {
          Customer = customer,
          MembershipTypes = _context.MembershipTypes.ToList(),
        };
        return View("CustomerForm", ViewModel);
      }
      if (customer.Id == 0)
        _context.Customers.Add(customer);
      else
      {
        var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
        customerInDb.Name = customer.Name;
        customerInDb.Birthdate = customer.Birthdate;
        customerInDb.MembershipTypeId = customer.MembershipTypeId;
        customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
      }
      _context.SaveChanges();
      return RedirectToAction("Index", "Customers");
    }

  }
}
