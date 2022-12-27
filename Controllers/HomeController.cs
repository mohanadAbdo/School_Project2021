using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using School_Project2021.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace School_Project2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
         VideoContext db;

        public static string currentLayout = "_adminLayout";
        public HomeController(ILogger<HomeController> logger, VideoContext context, IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
            _logger = logger;
            db = context;
            currentLayout = "_Layout";
        }

        public IActionResult Index(string language)
        {
            Language.UpdateLanguage(language);

            var courses = db.Courses.ToList<Course>();
            return View(courses);
        }

        public IActionResult Contact(string language)
        {
            Language.UpdateLanguage(language);
            return View();
        }

        public IActionResult Contact_Post(ContactUs newMessage, string language)
        {
            Language.UpdateLanguage(language);

            db.Contacts.Add(newMessage);
            db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        public IActionResult AddComment(string text, int currentCourseId, int currentVideoId)
        {
            Comment newComment=new Comment();
            newComment.Text = text;
            newComment.Date = DateTime.Now;
            string newName = "anoin user";
            if (User.Identity.Name != null)
            {
                var newNameList = db.Student.Where(x => x.Email == User.Identity.Name).ToList();
                newName = newNameList[0].Name;
            }
            //newComment.UserName = User.Identity.Name != null ? User.Identity.Name : "anoin user";
            newComment.UserName = newName;
            newComment.VideoID = currentVideoId;
            db.Comments.Add(newComment);
            db.SaveChanges();

            return RedirectToAction(nameof(Course),new { id=currentCourseId });
        }

        public IActionResult Team(string language)
        {
            Language.UpdateLanguage(language);
            var team = db.TeamMembers.ToList();
            return View(team);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin(string language)
        {
            Language.UpdateLanguage(language);

            return View();
        }

        public IActionResult Course(int id, string language)
        {
            ViewBag.courseId = id;

            //ViewBag.courseName = db.Courses.Find(id).Name;
            //ViewBag.courseDiscraption = db.Courses.Find(id).Discraption;
            //var videos = db.Videos.Where(x => x.CourseID == id).ToList();

            return View(db);
        }




        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
