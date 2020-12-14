using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherTodayApp.Models
{
    public class UserDetail
    {
        [Key]
        public int User_ID { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage ="Please Enter First Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter user first name only alphabets.")]
        public string User_First_Name { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage ="Please Enter Last Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter user last name only alphabets.")]
        public string User_Last_Name { get; set; }
        [DisplayName("Email ID")]
        [Required(ErrorMessage ="Please Enter Email")]
        public string  User_Emaild { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public string User_Password { get; set; }
    }
}