--creating database MobileDB
create database MobileDB
go
use MobileDB
go
--creating table Mobile
create table Mobile(
Id int not null primary key identity(3000,1),
[Name] varchar(30),
[Description] varchar(30),
ManufacturedBy varchar(30),
Price int
);
go

--Inserting records in table Mobile
insert into Mobile
values('Iphone','ios','India',50000),('Oneplus','Android','China',35000),('Vivo','Android','China',25000),('Lenovo','Android','Korea',15000)
,('Samsung','Android','India',30000)
go
--)creating stored procedure for the mobile already exists
create procedure sp_mobileAlreadyExists(
@name varchar(30))
as
begin
select COUNT(1) from Mobile
where [Name]=@name
end
go
exec sp_mobileAlreadyExists @name='Nokia'
go
--1)Creating stored procedure to view all mobiles available in the store
create proc sp_viewAllMobilesAvailableInStore
as
begin
select Id,[Name],[Description],ManufacturedBy,Price from Mobile
end
go
exec sp_viewAllMobilesAvailableInStore
go
--2)creating stored procedure to add mobiles
create proc sp_AddMobile(
@name varchar(30),
@description varchar(30),
@manufacturedBy varchar(30),
@price int)
as
begin
insert into Mobile values(@name,@description,@manufacturedBy,@price)
end
go

select * from Mobile
go
exec sp_AddMobile 'Nokia','Keypad','India',5000
go
--3)creating stored procedure to search mobile whose price is less than the maximum price
create procedure sp_searchMobilesWhosePriceLessThanMaxPrice
as
begin
select Id,[Name],[Description],ManufacturedBy,Price from Mobile
where Price<(select Max(Price) from Mobile)
end
go
exec sp_searchMobilesWhosePriceLessThanMaxPrice 
go
--4)creating stored procedure to search all mobiles by manufacturer
create procedure sp_searchAllMobilesByManufacturer(
@manufacturedBy varchar(30))
as
begin
select * from Mobile where ManufacturedBy=@manufacturedBy
end
go
exec sp_searchAllMobilesByManufacturer @manufacturedBy='India'
go
--5)creating stored procedure to view all mobiles whose price is greater than the minimum mobile price
--and less than the maximum mobile price
create procedure sp_viewAllMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice
as
begin
select Id,[Name],[Description],ManufacturedBy,Price from Mobile
where Price<(select Max(Price) from Mobile) and Price>(select Min(Price) from Mobile)
end
go
exec sp_viewAllMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice
go
--6)creating stored procedure to remove mobiles whose price is greater than minimum mobile price and
--less than maximum mobile price
create procedure sp_RemoveMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice
as
begin
delete from Mobile
where Price<(select Max(Price) from Mobile) and Price>(select Min(Price) from Mobile)
end
go
exec sp_RemoveMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice
