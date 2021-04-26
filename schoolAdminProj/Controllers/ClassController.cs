using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using schoolData;
using schoolData.Models;

namespace schoolAdminProj.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            List<studentModel> allstudents = new List<studentModel>();
            allstudents = StudentDataAccess.SelectStudentByGrade(9);
            ViewBag.Students = allstudents;

            List<gradeModel> grades = new List<gradeModel>();
            grades = ClassDataAccess.SelectGrade(9);
            ViewBag.Grades =grades;

            return View();
        }
        public IActionResult GradeCreate(int? value)
        {
            //dropwdown list
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Select Option", Value = "null" };
            SelectListItem item2 = new SelectListItem() { Text = "Grade 9", Value = "9" };
            SelectListItem item3 = new SelectListItem() { Text = " Grade 10", Value = "10" };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            ViewBag.Options = items;

            if (value != null)
            {
                ViewBag.Value = value;

                var currentYear = DateTime.Now.Year;
                ViewBag.CurrentYear = currentYear;

                var lastYear = DateTime.Now.Year - 1;
                ViewBag.LastYear = lastYear;
                

                List<studentModel> students = new List<studentModel>();
                students = ClassDataAccess.listUngradedStudents(Convert.ToInt32(value));

                //ViewBag.Students = students;
                
                List<studentModel> allstudents = new List<studentModel>();
                //allstudents = StudentDataAccess.SelectStudentByGrade(Convert.ToInt32(value));
                foreach(var student in students)
                {
                  allstudents.AddRange(StudentDataAccess.SelectStudent(student.StudentId));
                }
                ViewBag.Students = allstudents;


                List<classModel> classes = new List<classModel>();
                classes = ClassDataAccess.SelectClass(Convert.ToInt32(value));
                ViewBag.Classes=classes;

            }
            return View();
        }
        [HttpPost]
        public IActionResult GradeCreate(gradeModel m)
        {
            ClassDataAccess.CreateNewGrade(m);
            return RedirectToAction("Index");
        }

        public IActionResult ClassCreate()
        {
            List<teacherModel> teachers = new List<teacherModel>();
            teachers = TeacherDataAccess.LoadTeachers();
            teachers.Insert(0, new teacherModel { TeacherId = 0, fname = "Select" });
            ViewBag.Teachers = teachers;

            var dictionary = new Dictionary<int, int>
            {
                {9,9 },
                {10,10 }
            };

            ViewBag.SelectList = new SelectList(dictionary, "Key", "Value");



            return View();
        }



        [HttpPost]
        public IActionResult ClassCreate(classModel m)
        {
            ClassDataAccess.CreateNew(m);
            return RedirectToAction("Index");
        }
    }
}
