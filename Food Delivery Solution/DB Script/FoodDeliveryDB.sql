create database FoodDeliveryDB

create table FoodDeliveries (Delivery_Id int identity(1,1) primary key not null, 
Pickup_Address varchar(30) not null,
Drop_Address varchar(30) not null,
Customer_Mobile varchar(10) not null,
Delivery_Status varchar(20) not null
)

select * from FoodDeliveries