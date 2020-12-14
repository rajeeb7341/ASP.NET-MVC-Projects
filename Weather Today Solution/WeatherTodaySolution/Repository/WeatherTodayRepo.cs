using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTodayDAL
{
    public class WeatherTodayRepo
    {
        private WeatherDBEntities weatherDBEntities;

        public WeatherTodayRepo()
        {
            weatherDBEntities = new WeatherDBEntities();
        }

        public bool AddWeatherDetails(WeatherDetail weatherDetail)
        {
            bool status = false;
            try
            {
                weatherDBEntities.WeatherDetails.Add(weatherDetail);
                weatherDBEntities.SaveChanges();
                status = true;
            }
            catch(Exception)
            {
                status = false;
            }

            return status;
        }

        public List<GETWEATHERBYCITY_Result> GetWeatherByCity(string CityName)
        {
           return weatherDBEntities.GETWEATHERBYCITY(CityName).ToList<GETWEATHERBYCITY_Result>();
        }

        public WeatherDetail GetWeatherDetailsByCityID(int CityID)
        {
            WeatherDetail wd = weatherDBEntities.WeatherDetails.Find(CityID);
            return wd;
        }

        public bool UpdateWeatherDetails(WeatherDetail weatherDetail)
        {
            bool status = false;
            try
            {
                WeatherDetail updatedWeatherDetail = weatherDBEntities.WeatherDetails.Find(weatherDetail.CityID);
                updatedWeatherDetail.CityID = weatherDetail.CityID;
                updatedWeatherDetail.CityName = weatherDetail.CityName;
                updatedWeatherDetail.CountryName = weatherDetail.CountryName;
                updatedWeatherDetail.Temperature = weatherDetail.Temperature;
                updatedWeatherDetail.Humidity = weatherDetail.Humidity;
                updatedWeatherDetail.Visibility = weatherDetail.Visibility;
                weatherDBEntities.SaveChanges();
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public bool DeleteWeatherDetails(int CityID)
        {
            bool status = false;
            try
            {
                WeatherDetail entity = weatherDBEntities.WeatherDetails.Find(CityID);
                if (entity != null)
                {
                    weatherDBEntities.WeatherDetails.Remove(entity);
                    weatherDBEntities.SaveChanges();
                    status = true;
                }
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public List<GETALLCITYWEATHER_Result> ViewAllCityWeatherList()
        {
            return weatherDBEntities.GETALLCITYWEATHER().ToList<GETALLCITYWEATHER_Result>();
        }

        public string ValidateUser(string email, string Password)
        {
            var u = (from user in weatherDBEntities.UserDetails where user.User_Emaild == email && user.User_Password == Password select user.User_Emaild ).FirstOrDefault();
            return u;
        }

        public bool AddUser(UserDetail userDetail)
        {
            bool status = false;
            try
            {
                weatherDBEntities.UserDetails.Add(userDetail);
                weatherDBEntities.SaveChanges();
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public UserDetail GetUserByEmail(string EmailID)
        {
            UserDetail ud = (from details in weatherDBEntities.UserDetails where details.User_Emaild == EmailID select details).FirstOrDefault();
            return ud;
        }

        public bool UpdateUserDetails(UserDetail userDetail)
        {
            bool status = false;
            try
            {
                UserDetail updateUserDetail = weatherDBEntities.UserDetails.Find(userDetail.User_ID);
                updateUserDetail.User_ID = userDetail.User_ID;
                updateUserDetail.User_First_Name = userDetail.User_First_Name;
                updateUserDetail.User_Last_Name = userDetail.User_Last_Name;
                updateUserDetail.User_Password = userDetail.User_Password;
                weatherDBEntities.SaveChanges();
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
