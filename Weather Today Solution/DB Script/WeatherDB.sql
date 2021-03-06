
CREATE DATABASE [WeatherDB]
GO
USE [WeatherDB]
GO

CREATE TABLE [dbo].[UserDetails](
	[User_ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[User_First_Name] [varchar](50) NOT NULL,
	[User_Last_Name] [varchar](50) NOT NULL,
	[User_Emaild] [varchar](50) UNIQUE NOT NULL,
	[User_Password] [varchar](50) NOT NULL)
GO

CREATE TABLE [dbo].[WeatherDetails](
	[CityID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
	[Temperature] [numeric](3, 1) NOT NULL,
	[Humidity] [int] NOT NULL,
	[Visibility] [int] NOT NULL)
GO

CREATE PROCEDURE [dbo].[GETALLCITYWEATHER]
AS
BEGIN
	SELECT * FROM WeatherDetails

END
GO

CREATE PROCEDURE [dbo].[GETWEATHERBYCITY] (@CITY VARCHAR(20))
AS
BEGIN 
 SELECT * FROM WeatherDetails
 WHERE CityName=@CITY
 END
GO

