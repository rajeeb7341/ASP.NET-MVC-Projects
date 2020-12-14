using FoodDeliveryDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class DeliveryController : Controller
    {
        private FoodDeliveryRepo repo;
        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ScheduleFoodDelivery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ScheduleFoodDelivery(Models.FoodDelivery delivery)
        {
            repo = new FoodDeliveryRepo();
            FoodDelivery entityDelivery = new FoodDelivery();
            entityDelivery.Delivery_Id = delivery.Delivery_Id;
            entityDelivery.Pickup_Address = delivery.Pickup_Address;
            entityDelivery.Drop_Address = delivery.Drop_Address;
            entityDelivery.Customer_Mobile = delivery.Customer_Mobile;
            entityDelivery.Delivery_Status = delivery.Delivery_Status;
            bool status = repo.AddFoodDelivery(entityDelivery);
            if (status)
            {
                ViewBag.Msg = "Food delivery scheduling success!";
            }
            else
            {
                ViewBag.Msg = "Something went wrong";
            }
            return View(delivery);

        }

        public ActionResult ViewAllDeliverables()
        {
            repo = new FoodDeliveryRepo();
            List<FoodDelivery> gFood = repo.ViewAllDeliveries();
            List<Models.FoodDelivery> modelDeliveryList = new List<Models.FoodDelivery>();
            foreach (var item in gFood)
            {
                Models.FoodDelivery modelDelivery = new Models.FoodDelivery();
                modelDelivery.Delivery_Id = item.Delivery_Id;
                modelDelivery.Pickup_Address = item.Pickup_Address;
                modelDelivery.Drop_Address = item.Drop_Address;
                modelDelivery.Customer_Mobile = item.Customer_Mobile;
                modelDelivery.Delivery_Status = item.Delivery_Status;
                modelDeliveryList.Add(modelDelivery);

            }
            return View(modelDeliveryList);
        }

        [HttpGet]
        public ActionResult UpdateDeliveryStatus(int id)
        {
            repo = new FoodDeliveryRepo();
            FoodDelivery entityDelivery = repo.SearchFoodDelivery(id);
            Models.FoodDelivery updateDelivery = new Models.FoodDelivery();
            updateDelivery.Delivery_Id = entityDelivery.Delivery_Id;
            updateDelivery.Pickup_Address = entityDelivery.Pickup_Address;
            updateDelivery.Drop_Address = entityDelivery.Drop_Address;
            updateDelivery.Customer_Mobile = entityDelivery.Customer_Mobile;
            updateDelivery.Delivery_Status = entityDelivery.Delivery_Status;

            return View(updateDelivery);

        }
        [HttpPost]
        public ActionResult UpdateDeliveryStatus(int id, Models.FoodDelivery delivery)
        {
            repo = new FoodDeliveryRepo();
            FoodDelivery updateDelivery = new FoodDelivery();
            updateDelivery.Delivery_Id = delivery.Delivery_Id;
            updateDelivery.Pickup_Address = delivery.Pickup_Address;
            updateDelivery.Drop_Address = delivery.Drop_Address;
            updateDelivery.Customer_Mobile = delivery.Customer_Mobile;
            updateDelivery.Delivery_Status = delivery.Delivery_Status;
            bool status = repo.UpdateDeliveryStatus(updateDelivery);
            if (status)
            {
                Session["Delivery_Id"] = null;
                ViewBag.Msg = "Food delivery status updated!";
            }
            else
            {
                ViewBag.Msg = "Something went wrong";
            }
            return View();
        }
    }
}
 