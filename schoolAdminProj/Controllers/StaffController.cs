using System;
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
    public class StaffController : Controller
    {
        [Authorize]
        public IActionResult Index(int? value)
        {

            //dropwdown list
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Select Option", Value = "null" };
            SelectListItem item2 = new SelectListItem() { Text = "Teacher", Value = "1" };
            SelectListItem item3 = new SelectListItem() { Text = "Staff", Value = "2" };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            ViewBag.Options = items;

            if (value != null)
            {
                ViewBag.Value = value;
            }

            //Teacher Model
            List<teacherModel> teacher = new List<teacherModel>();
            teacher = TeacherDataAccess.LoadTeachers();
            ViewBag.Teachers = teacher;

            //Staff Model
            List<staffModel> staff = new List<staffModel>();
            staff = StaffDataAccess.LoadStaff();
            ViewBag.Staff = staff;
            return View();
        }

        //Add new teacher data to teacher table
        [Authorize]
        public IActionResult TeacherCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult TeacherCreate(teacherModel m)
        {
            TeacherDataAccess.CreateNew(m);
            return RedirectToAction("Index");
        }

        //Add new staff data to staff table
        [Authorize]
        public IActionResult StaffCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult StaffCreate(staffModel m)
        {
            StaffDataAccess.CreateNewStaff(m);
            return RedirectToAction("Index");
        }

        //Update teacher table
        [Authorize]
        public IActionResult SelectTeacher(int id)
        {
            int i = id;
            List<teacherModel> teacher = new List<teacherModel>();
            teacher = TeacherDataAccess.SelectTeacher(i);
            return View(teacher);
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdateTeacher(teacherModel m)
        {
            TeacherDataAccess.Update(m);
            return RedirectToAction("Index");
        }

        //Update staff table
        [Authorize]
        public IActionResult SelectStaff(int id)
        {
            int i = id;
            List<staffModel> staff = new List<staffModel>();
            staff = StaffDataAccess.SelectStaff(i);
            return View(staff);
        }
        [HttpPost]
        [Authorize]
        public IActionResult UpdateStaff(staffModel m)
        {
            StaffDataAccess.UpdateStaff(m);
            return RedirectToAction("Index");
        }

        //delete row from teacher table
        [Authorize]
        public ActionResult DeleteTeacher(int id)
        {
            int i = id;
            List<teacherModel> teacher = new List<teacherModel>();
            teacher = TeacherDataAccess.SelectTeacher(i);
            return View(teacher);
        }
        [Authorize]
        public ActionResult ConfirmTeacherDelete(int id)
        {
            int i = id;
            TeacherDataAccess.Delete(i);
            return RedirectToAction("Index");
        }

        //delete row from teacher table
        [Authorize]
        public ActionResult DeleteStaff(int id)
        {
            int i = id;
            List<staffModel> staff = new List<staffModel>();
            staff = StaffDataAccess.SelectStaff(i);
            return View(staff);
        }
        [Authorize]
        public ActionResult ConfirmStaffDelete(int id)
        {
            int i = id;
            StaffDataAccess.DeleteStaff(i);
            return RedirectToAction("Index");
        }
    }
}
