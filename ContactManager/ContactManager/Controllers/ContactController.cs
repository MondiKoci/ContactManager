using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }

        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Contact());
        }

        public IActionResult Details(int id) 
        {
            ViewBag.Action = "Contact Details";
            var contact = context.Contacts
                .Include(c => c.Category) //Filter
                .FirstOrDefault(c => c.ContactId == id); //Filter
            return View(contact);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            var contact = context.Contacts
                .Include(c => c.Category) //Filter
                .FirstOrDefault(c => c.ContactId == id); //Filter
            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts
                .Include(c => c.Category) //Filter
                .FirstOrDefault(c => c.ContactId == id); //Filter
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            string action = (contact.ContactId == 0 ? "Add" : "Edit");

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    contact.DateAdded = DateTime.Now;
                    context.Contacts.Add(contact);
                    context.SaveChanges();
                }
                else 
                {
                    context.Contacts.Update(contact);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
                return View(contact);
            }
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
