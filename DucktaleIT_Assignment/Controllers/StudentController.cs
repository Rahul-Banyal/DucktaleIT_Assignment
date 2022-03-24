using DucktaleIT_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DucktaleIT_Assignment.Controllers
{
    public class StudentController : Controller
    {
        private StudentDBEntities1 _context = new StudentDBEntities1();
        // GET: Student
        public ActionResult Index(string searchString)
        {
            List<Student> studentList = new List<Student>();
            studentList = _context.Student.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.SearchString = searchString;
                searchString = searchString.ToLower();
                studentList = studentList.Where(s => s.FirstName.ToLower().Contains(searchString) || s.LastName.ToLower().Contains(searchString) || s.ClassName.ToLower().Contains(searchString)).ToList();
            }

            return View(studentList);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                _context.Student.Add(student);
                _context.SaveChanges();
                ViewBag.Message = "Data Insert Successfully";
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }
    }
}
