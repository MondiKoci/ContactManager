using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        
        private ContactContext context { get; set; }

        //Defining injection
        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            //Give us a list of Contact records
            var contacts = context.Contacts
                .Include(c => c.Category)
                .OrderBy(c => c.FirstName)
                .ToList();
            return View(contacts);
        }
    }
}