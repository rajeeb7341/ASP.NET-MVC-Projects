using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryDAL
{
    public class FoodDeliveryRepo
    {
        private FoodDeliveryDBContext context;

        public FoodDeliveryRepo()
        {
            context = new FoodDeliveryDBContext();
        }

        public bool AddFoodDelivery(FoodDelivery delivery)
        {
            bool status = true;
            try
            {
                context.FoodDeliveries.Add(delivery);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public List<FoodDelivery>ViewAllDeliveries()
        {
            return context.FoodDeliveries.ToList();
        }

        public FoodDelivery SearchFoodDelivery(int id)
        {
            var p = (from u in context.FoodDeliveries where u.Delivery_Id == id select u).FirstOrDefault() ;
            return p;
        }

        public bool UpdateDeliveryStatus(FoodDelivery delivery)
        {
            bool status = false;
            try
            {
                FoodDelivery updateDelivery = context.FoodDeliveries.Find(delivery.Delivery_Id);
                updateDelivery.Delivery_Id = delivery.Delivery_Id;
                updateDelivery.Pickup_Address = delivery.Pickup_Address;
                updateDelivery.Drop_Address = delivery.Drop_Address;
                updateDelivery.Customer_Mobile = delivery.Customer_Mobile;
                updateDelivery.Delivery_Status = delivery.Delivery_Status;
                context.SaveChanges();
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
