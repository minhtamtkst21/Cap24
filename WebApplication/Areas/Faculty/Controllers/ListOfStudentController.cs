using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Areas.Faculty.Controllers
{
    public class ListOfStudentController : Controller
    {
        private Cap24 db = new Cap24();
        // GET: Faculty/ListOfStudent
        public ActionResult Index()
        {
            var listOfStudent = db.SinhViens;
            return View(listOfStudent.ToList());
        }
    }
}