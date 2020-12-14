using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodDeliveryApp.Models
{
    public class FoodDelivery
    {
        [Key]
        public int Delivery_Id { get; set; }

        [Required]
        [DisplayName("Pick-Up Address")]
        public string Pickup_Address { get; set; }

        [Required]
        [DisplayName("Drop Address")]
        public string Drop_Address { get; set; }

        [Required]
        [DisplayName("Customer Mobile")]
        [DataType(DataType.PhoneNumber)]
        public string Customer_Mobile { get; set; }

        [Required]
        [DisplayName("Delivery Status")]
        public string Delivery_Status { get; set; }
    }
}