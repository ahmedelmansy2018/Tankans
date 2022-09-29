using BLL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pilot_TaskFrist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Profile
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult _Profile()
        {
            return View(BLLProfile.List());
        }
        public JsonResult GetProfile(int ProfileID)
        {
            var Profile = BLLProfile.Get(ProfileID);
            return Json(
                new
                {
                    Id = Profile.Id,
                    FirstName = Profile.FirstName,
                    LastName = Profile.LastName,
                    DateBirth = Profile.DateBirth.ToString("yyyy-MM-dd"),
                    Email = Profile.Email,
                    Phone = Profile.Phone
                }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult AddProfile(Profile Profile)
        {
            if (Profile != null)
            {
                bool _Result = BLLProfile.Add(Profile);
                return Json(new { Result = _Result, Message = _Result ? "Save Successfully" : "Save Faild-Data Duplication" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Result = false, Message = "Error" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateProfile(Profile Profile)
        {
            bool _Result = BLLProfile.Edit(Profile);
            return Json(new { Result = _Result, Message = _Result ? "Update Successfully" : "Update Faild-Data Duplication" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProfile(int ProfileID)
        {
            string _Result = BLLProfile.Delete(ProfileID);
            return Json(new { Message = _Result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region task
        public ActionResult task()
        {
            return View();
        }
        public ActionResult _task()
        {
            return View(BLLTask.List());
        }
        public ActionResult _GetAllProfile()
        {
            return View(BLLProfile.List());
        }
        public JsonResult Gettask(int taskID)
        {
            var task = BLLTask.Get(taskID);
            return Json(
                new
                {
                    Id = task.Id,
                    FkprofileId = task.FkprofileId,
                    TaskName = task.TaskName,
                    StartTime = task.StartTime.ToString("hh:mm tt"),
                    TaskDescription = task.TaskDescription,
                    Status = task.Status
                }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult Addtask(task task)
        {
            if (task != null)
            {
                bool _Result = BLLTask.Add(task);
                return Json(new { Result = _Result, Message = _Result ? "Save Successfully" : "Save Faild-Data Duplication" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Result = false, Message = "Error" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Updatetask(task task)
        {
            bool _Result = BLLTask.Edit(task);
            return Json(new { Result = _Result, Message = _Result ? "Update Successfully" : "Update Faild-Data Duplication" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Deletetask(int taskID)
        {
            bool _Result = BLLTask.Delete(taskID);
            return Json(new { Result = _Result, Message = _Result ? "Delete Successfully" : "Delete Faild-" }, JsonRequestBehavior.AllowGet);
        }

        #endregion
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}