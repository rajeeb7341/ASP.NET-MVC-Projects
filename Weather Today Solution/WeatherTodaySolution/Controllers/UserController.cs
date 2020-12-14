using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherTodayDAL;

namespace WeatherTodayApp.Controllers
{
    public class UserController : Controller
    {
        private WeatherTodayRepo repo;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(Models.UserDetail ud)
        {
            repo = new WeatherTodayRepo();
            UserDetail entityUser = new UserDetail();
            entityUser.User_ID = ud.User_ID;
            entityUser.User_First_Name = ud.User_First_Name;
            entityUser.User_Last_Name = ud.User_Last_Name;
            entityUser.User_Emaild = ud.User_Emaild;
            entityUser.User_Password = ud.User_Password;
       
            
            bool status = repo.AddUser(entityUser);
            if (status)
            {
                return RedirectToAction("LoginUser", "User");
            }
            else
            {
                ViewBag.Msg = "Something went wrong.";
            }
            return View(ud);
        }

        [HttpGet]
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(string uEmail, string uPass)
        {
            repo = new WeatherTodayRepo();
            string email = repo.ValidateUser(uEmail, uPass);
            if ((uEmail!=null) && (email==uEmail))
            {
                Session["EmailID"] = uEmail;
                return RedirectToAction("ViewAllCityWeatherList", "Weather");
            }
            else
            {
                ViewBag.Msg = "Invalid credentials. Please enter correct email and password.";
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult UpdateProfile()
        {

            
            Models.UserDetail modelUser = new Models.UserDetail();
            repo = new WeatherTodayRepo();
            UserDetail entityUser = repo.GetUserByEmail(Session["EmailID"].ToString());
          
            modelUser.User_ID = entityUser.User_ID;
            modelUser.User_First_Name = entityUser.User_First_Name;
            modelUser.User_Last_Name = entityUser.User_Last_Name;
            modelUser.User_Emaild = entityUser.User_Emaild;
            modelUser.User_Password = entityUser.User_Password;
            return View(modelUser); 
        }
        [HttpPost]
        public ActionResult UpdateProfile(Models.UserDetail Ud)
        {
            UserDetail entityUser = new UserDetail();
            entityUser.User_ID = Ud.User_ID;
            entityUser.User_First_Name = Ud.User_First_Name;
            entityUser.User_Last_Name = Ud.User_Last_Name;
            entityUser.User_Emaild = Ud.User_Emaild;
            entityUser.User_Password = Ud.User_Password;
            repo = new WeatherTodayRepo();
            bool status = repo.UpdateUserDetails(entityUser);
            if (status)
            {
                
                ViewBag.Msg = " Your details are updated successfully";
            }
            else
            {
                ViewBag.Msg = "Something went wrong";
            }

            return View();

        }
    }
}