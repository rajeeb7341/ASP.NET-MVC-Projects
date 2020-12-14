using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherTodayDAL;

namespace WeatherTodayApp.Controllers
{
    public class WeatherController : Controller
    {
        private WeatherTodayRepo repo;
        // GET: WeatherToday
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult CreateWeather()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateWeather(Models.WeatherDetail weatherdetails)
        {
            if (ModelState.IsValid)
            {
                repo = new WeatherTodayRepo();
                WeatherDetail entityWeather = new WeatherDetail();
                entityWeather.CityID = weatherdetails.CityID;
                entityWeather.CityName = weatherdetails.CityName;
                entityWeather.CountryName = weatherdetails.CountryName;
                entityWeather.Temperature = weatherdetails.Temperature;
                entityWeather.Humidity = weatherdetails.Humidity;
                entityWeather.Visibility = weatherdetails.Visibility;

                bool status = repo.AddWeatherDetails(entityWeather);
                if (status)
                {
                    ViewBag.Msg = "Weather details added successfully";
                }
                else
                {
                    ViewBag.Msg = "Something went wrong";
                }

            }
            return View(weatherdetails);
        }

        [HttpGet]
        public ActionResult GetWeatherByCity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetWeatherByCity(FormCollection FC)
        {
            string cityname = FC["txtCityName"];
            repo = new WeatherTodayRepo();
            List<GETWEATHERBYCITY_Result> entityWeatherList = repo.GetWeatherByCity(cityname);
            List<Models.WeatherDetail> modelWeatherList = new List<Models.WeatherDetail>();
            foreach(var dalWeather in entityWeatherList)
            {
                Models.WeatherDetail modelWeather = new Models.WeatherDetail();
                modelWeather.CityID = dalWeather.CityID;
                modelWeather.CityName = dalWeather.CityName;
                modelWeather.CountryName = dalWeather.CountryName;
                modelWeather.Temperature = dalWeather.Temperature;
                modelWeather.Humidity = dalWeather.Humidity;
                modelWeather.Visibility = dalWeather.Visibility;
                modelWeatherList.Add(modelWeather);

            }
            if(modelWeatherList!=null && modelWeatherList.Count == 0)
            {
                ViewBag.Msg = "No records found";
            }
            return View("GetWeatherByCityPost", modelWeatherList);
        }

        [HttpGet]
        public ActionResult UpdateWeather(int CityId)
        {
            repo = new WeatherTodayRepo();
            WeatherDetail entityWeather = repo.GetWeatherDetailsByCityID(CityId);
            Models.WeatherDetail modelWeather = new Models.WeatherDetail();
            modelWeather.CityID = entityWeather.CityID;
            modelWeather.CityName = entityWeather.CityName;
            modelWeather.CountryName = entityWeather.CountryName;
            modelWeather.Temperature = entityWeather.Temperature;
            modelWeather.Humidity = entityWeather.Humidity;
            modelWeather.Visibility = entityWeather.Visibility;
            return View(modelWeather);
        }
        [HttpPost]
        public ActionResult UpdateWeather(Models.WeatherDetail Wd)
        {
            if (ModelState.IsValid)
            {
                WeatherDetail entityWeather = new WeatherDetail();
                entityWeather.CityID = Wd.CityID;
                entityWeather.CityName = Wd.CityName;
                entityWeather.CountryName = Wd.CountryName;
                entityWeather.Temperature = Wd.Temperature;
                entityWeather.Humidity = Wd.Humidity;
                entityWeather.Visibility = Wd.Visibility;
                repo = new WeatherTodayRepo();
                bool status = repo.UpdateWeatherDetails(entityWeather);
                if (status)
                {
                    Session["CityId"] = null;
                    return RedirectToAction("ViewAllCityWeatherList", "Weather");
                }
                else
                {
                    ViewBag.Msg = "Something went wrong";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteWeather(int CityId)
        {
            repo = new WeatherTodayRepo();
            WeatherDetail entityWeather = repo.GetWeatherDetailsByCityID(CityId);
            Models.WeatherDetail modelWeather = new Models.WeatherDetail();
            modelWeather.CityID = entityWeather.CityID;
            modelWeather.CityName = entityWeather.CityName;
            modelWeather.CountryName = entityWeather.CountryName;
            modelWeather.Temperature = entityWeather.Temperature;
            modelWeather.Humidity = entityWeather.Humidity;
            modelWeather.Visibility = entityWeather.Visibility;
            Session["CityId"] = CityId;
            return View(modelWeather);
            
        }
        [HttpPost, ActionName("DeleteWeather")]
        public ActionResult RemoveWeather()
        {
            
            repo = new WeatherTodayRepo();
            bool status = repo.DeleteWeatherDetails(Convert.ToInt32(Session["CityId"].ToString()));
            if (status)
            {
                Session["CityId"] = null;
                return RedirectToAction("ViewAllCityWeatherList", "Weather");
            }
            else
            {
                ViewBag.Msg = "Something went wrong";
            }
            return View();
        }

        public ActionResult ViewAllCityWeatherList()
        {
            repo = new WeatherTodayRepo();
            List<GETALLCITYWEATHER_Result> gCity = repo.ViewAllCityWeatherList();
            List<Models.WeatherDetail> modelWeatherList = new List<Models.WeatherDetail>();
            foreach(var item in gCity)
            {
                Models.WeatherDetail modelWeather = new Models.WeatherDetail();
                modelWeather.CityID = item.CityID;
                modelWeather.CityName = item.CityName;
                modelWeather.CountryName = item.CountryName;
                modelWeather.Temperature = item.Temperature;
                modelWeather.Humidity = item.Humidity;
                modelWeather.Visibility = item.Visibility;
                modelWeatherList.Add(modelWeather);


            }
            return View(modelWeatherList);
        }

    }
}