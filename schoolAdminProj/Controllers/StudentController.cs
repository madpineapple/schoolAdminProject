﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using schoolData;
using schoolData.Models;

namespace schoolAdminProj.Controllers
{
    public class StudentController : Controller
    {
        [Authorize]
        public IActionResult Index(int? value)
        {
            //dropdown list
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Select Option", Value = "null" };
            SelectListItem item2 = new SelectListItem() { Text = " All students", Value = "1" };
            SelectListItem item3 = new SelectListItem() { Text = "Grade 9", Value = "2" };
            SelectListItem item4 = new SelectListItem() { Text = "Grade 10", Value = "3" };
            SelectListItem item5 = new SelectListItem() { Text = "Grade 11", Value = "4" };
            SelectListItem item6 = new SelectListItem() { Text = "Grade 12", Value = "5" };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);
            items.Add(item6);
            ViewBag.Options = items;

            if (value != null)
            {
                ViewBag.Value = value;
            }

            //Student Model
            List<studentModel> allStudents = new List<studentModel>();
            allStudents = StudentDataAccess.LoadStudents();
            ViewBag.Students = allStudents;
            //Select by grade
            List<studentModel> gradeNine = new List<studentModel>();
            gradeNine = StudentDataAccess.LoadStudentName(9);
            ViewBag.GradeNine = gradeNine;
            List<studentModel> gradeTen = new List<studentModel>();
            gradeTen = StudentDataAccess.LoadStudentName(10);
            ViewBag.GradeTen = gradeTen;
            List<studentModel> gradeEleven = new List<studentModel>();
            gradeEleven = StudentDataAccess.LoadStudentName(11);
            ViewBag.GradeEleven = gradeEleven;
            List<studentModel> gradeTwelve = new List<studentModel>();
            gradeTwelve = StudentDataAccess.LoadStudentName(12);
            ViewBag.GradeTwelve = gradeTwelve;

            //chart data
            List<studentModel> students = new List<studentModel>();

            // students = StudentDataAccess.LoadStudentName();
            ViewBag.StudentFname = students;
            return View();
        }
        [Authorize]
        public IActionResult StudentCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult StudentCreate(studentModel m)
        {
            StudentDataAccess.CreateNew(m);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult SelectStudent(int id)
        {
            int i = id;
            List<studentModel> student = new List<studentModel>();
            student = StudentDataAccess.SelectStudent(i);
            return View(student);
        }
        //push update
        [HttpPost]
        [Authorize]
        public IActionResult UpdateStudent(studentModel m)
        {
            StudentDataAccess.Update(m);
            return RedirectToAction("Index");
        }

        //delete students
        [Authorize]
        public ActionResult DeleteStudent(int id)
        {
            int i = id;
            List<studentModel> student = new List<studentModel>();
            student = StudentDataAccess.SelectStudent(i);
            return View(student);
        }
        [Authorize]
        public ActionResult ConfirmStudentDelete(int id)
        {
            int i = id;
            StudentDataAccess.Delete(i);
            return RedirectToAction("Index");
        }
    }
}
