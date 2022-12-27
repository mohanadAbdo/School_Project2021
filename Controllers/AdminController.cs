using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Project2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Project2021.Controllers
{

    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        VideoContext db;

        public AdminController(VideoContext context)
        {
            HomeController.currentLayout = "_adminLayout";
            db = context;
        }
        public IActionResult Index()
        {
         
            return View();
        }
        public IActionResult ShowMessages()
        {
            var result = db.Contacts.ToList();
            return View(result);
        }
        public IActionResult Delete_Contact(int id)
        {
            ContactUs contact = db.Contacts.Find(id);
            var result = db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction(nameof(ShowMessages));
        }
    }
}
