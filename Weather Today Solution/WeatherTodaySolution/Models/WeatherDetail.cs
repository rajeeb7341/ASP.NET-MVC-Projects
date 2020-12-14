using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherTodayApp.Models
{
    public class WeatherDetail
    {
        [DisplayName("CityID")]
        public int CityID { get; set; }
        [DisplayName("City Name")]
        [Required(ErrorMessage ="Please Enter City Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter city name only alphabets.")]
        public string  CityName { get; set; }
        [DisplayName("Country Name")]
        [Required(ErrorMessage ="Please Enter Country Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter country name only alphabets.")]
        public string CountryName { get; set; }
        [DisplayName("Temperature (Celsius)")]
        [Required(ErrorMessage="Please Enter Temperature")]
        [Range(minimum:0.0,maximum:50.00,ErrorMessage="Invalid Temperature")]
        public decimal Temperature { get; set; }
        [DisplayName("Humidity %")]
        [Required(ErrorMessage ="Please Enter Humidity")]
        [Range(minimum:40,maximum:70,ErrorMessage ="Invalid humidity")]
        public int Humidity { get; set; }
        [DisplayName("Visibility KM")]
        [Required(ErrorMessage ="Please Enter Visibility")]
        [Range(minimum:2,maximum:20,ErrorMessage ="Invalid visiblity")]
        public int Visibility { get; set; }
    }
}