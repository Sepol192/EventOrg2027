using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventOrg2027.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EventOrg2027.Controllers
{
    public class CustomersController : Controller
    {
        private readonly EventOrgDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CustomersController(EventOrgDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Customers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customers/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterCustomerViewModel customerInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(customerInfo);
            }

            string username = customerInfo.Email;

            IdentityUser user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                ModelState.AddModelError("Email", "There is allready a customer with that email.");
                return View(customerInfo);
            }

            user = new IdentityUser(username);
            await _userManager.CreateAsync(user, customerInfo.Password);
            await _userManager.AddToRoleAsync(user, "Customer");

            Customer customer = new Customer
            {
                Name = customerInfo.Name,
                Email = customerInfo.Email
            };
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> EditPersonalData()
        {
            string email = User.Identity.Name;

            var customer = await _context.Customer.SingleOrDefaultAsync(c => c.Email == email);
            if (customer == null)
            {
                return NotFound();
            }

            EditLoggedInCustomerViewModel customerInfo = new EditLoggedInCustomerViewModel
            {
                Name = customer.Name,
                Email = customer.Email
            };

            return View(customerInfo);
        }

        // GET: Customers/Delete/5
        /*
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
        
    }
}
