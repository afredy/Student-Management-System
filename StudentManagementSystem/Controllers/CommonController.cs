using StudentManagementSystem.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class CommonController : Controller
    {
        DepartmentSetupManager _departmentSetupManager = new DepartmentSetupManager();
        SemesterSetupManager _semesterSetupManager = new SemesterSetupManager();
        DesignationManager _designationManager = new DesignationManager();
        TeacherSetupManager _teacherSetupManager = new TeacherSetupManager();
        CourseSetupManager _courseSetupManager = new CourseSetupManager();
        RoomSetupManager _roomSetupManager = new RoomSetupManager();
        DaySetupManager _daySetupManager = new DaySetupManager();
        DateTimeManager _dateTimeManager = new DateTimeManager();
        RegisterStudentManager _registerStudentManager = new RegisterStudentManager();
        GradeManager _gradeManager = new GradeManager();
        public ActionResult GetAllDepartment()
        {
            var list = _departmentSetupManager.GetDepartmentSelectList();
            return Json(list,JsonRequestBehavior.AllowGet); 
        }
        public ActionResult GetAllSemester()
        {
            var list = _semesterSetupManager.GetSemesterSelectList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllDesignation()
        {
            var list = _designationManager.GetDepartmentSelectList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllTeacher(int departmentId)
        {
            var list = _teacherSetupManager.GetTeacherSelectList(departmentId);
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllCourse(int departmentId)
        {
            var list = _courseSetupManager.GetCourseSelectList(departmentId);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllCourseMassSelection()
        {
            var list = _courseSetupManager.GetCourseSelectListMassSelection();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllRoom(int departmentId)
        {
            var list = _roomSetupManager.GetRoomSelectList(departmentId);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllDay()
        {
            var list = _daySetupManager.GetDaySelectList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetServerDate()
        {
            var date = _dateTimeManager.GetServerDate();
            return Json(date,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllRegistration()
        {
            var list = _registerStudentManager.GetStudentSelectList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllGrade()
        {
            var list = _gradeManager.GetGradeSelectList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}