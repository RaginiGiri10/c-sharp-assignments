using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_MobileManagement_ADO
{
    class Mobile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufacturedBy { get; set; }
        public double Price { get; set; }

    }
    class MobileRepository
    {
        string connectionString = @"data source=(localdb)\MSSQLLocalDB;database=MobileDB;integrated security=SSPI";


        public List<Mobile> GetAllMobileDetails()
        {
            List<Mobile> mobileList = new List<Mobile>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_viewAllMobilesAvailableInStore";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Mobile mobile = new Mobile();
                        mobile.Id = Convert.ToInt32(reader["Id"]);
                        mobile.Name = Convert.ToString(reader["Name"]);
                        mobile.Description = Convert.ToString(reader["Description"]);
                        mobile.ManufacturedBy = Convert.ToString(reader["ManufacturedBy"]);
                        mobile.Price = Convert.ToInt32(reader["Price"]);
                        mobileList.Add(mobile);

                    }


                }


            }

            return mobileList;
        }
        public void AddMobile(Mobile mobile)
        {
            if (!CheckMobileWithNameExists(mobile.Name)) {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "sp_AddMobile";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;

                        connection.Open();
                        SqlParameter paramName = new SqlParameter { ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = mobile.Name };
                        SqlParameter paramDescription = new SqlParameter { ParameterName = "@description", SqlDbType = SqlDbType.VarChar, Value = mobile.Description };
                        SqlParameter paramManufacturedBy = new SqlParameter { ParameterName = "@manufacturedBy", SqlDbType = SqlDbType.VarChar, Value = mobile.ManufacturedBy };
                        SqlParameter paramPrice = new SqlParameter { ParameterName = "@price", SqlDbType = SqlDbType.Int, Value = mobile.Price };
                        command.Parameters.Add(paramName);
                        command.Parameters.Add(paramDescription);
                        command.Parameters.Add(paramManufacturedBy);
                        command.Parameters.Add(paramPrice);

                        command.ExecuteNonQuery();
                        Console.WriteLine("Mobile record added successfully!!!");

                    }
                }
            }
            else
            {
                Console.WriteLine($"Mobile with name {mobile.Name} already exists!!!");
            }


        }
        public bool CheckMobileWithNameExists(string name)
        {
            int countOfExistsingMobiles = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_mobileAlreadyExists";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    
                    connection.Open();

                    SqlParameter paramName = new SqlParameter { ParameterName = "@name", SqlDbType = SqlDbType.VarChar, Value = name };
                    command.Parameters.Add(paramName);
                    countOfExistsingMobiles = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return countOfExistsingMobiles > 0;
        }


        public void SearchMobileWhosePriceLessThanMaxPrice(Mobile mobile)
        {
            List<Mobile> mobileList = new List<Mobile>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_searchMobilesWhosePriceLessThanMaxPrice";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Mobile searchMobileLessThanMaxPrice = new Mobile();
                        searchMobileLessThanMaxPrice.Id = Convert.ToInt32(reader["Id"]);
                        searchMobileLessThanMaxPrice.Name = Convert.ToString(reader["Name"]);
                        searchMobileLessThanMaxPrice.Description = Convert.ToString(reader["Description"]);
                        searchMobileLessThanMaxPrice.ManufacturedBy = Convert.ToString(reader["ManufacturedBy"]);
                        searchMobileLessThanMaxPrice.Price = Convert.ToInt32(reader["Price"]);
                        mobileList.Add(searchMobileLessThanMaxPrice);
                    }
                    foreach (var searchMobiles in mobileList)
                    {
                        Console.WriteLine($"Id -{searchMobiles.Id},Name -{searchMobiles.Name},Description -{searchMobiles.Description}, ManufacturedBy- {searchMobiles.ManufacturedBy},Price- {searchMobiles.Price}");
                    }
                }
            }
        }
        public void SearchByManufacturer(Mobile mobile)
        {
            List<Mobile> mobileList = new List<Mobile>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_searchAllMobilesByManufacturer";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    connection.Open();
                    SqlParameter paramManufacturedBy = new SqlParameter { ParameterName = "@manufacturedBy", SqlDbType = SqlDbType.VarChar, Value = mobile.ManufacturedBy };
                    command.Parameters.Add(paramManufacturedBy);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Mobile mobileManufacturedBy = new Mobile();
                        mobileManufacturedBy.Id = Convert.ToInt32(reader["Id"]);
                        mobileManufacturedBy.Name = Convert.ToString(reader["Name"]);
                        mobileManufacturedBy.Description = Convert.ToString(reader["Description"]);
                        mobileManufacturedBy.ManufacturedBy = Convert.ToString(reader["ManufacturedBy"]);
                        mobileManufacturedBy.Price = Convert.ToInt32(reader["Price"]);
                        mobileList.Add(mobileManufacturedBy);

                    }
                    foreach (var Mobile in mobileList)
                    {
                        Console.WriteLine($"Id -{Mobile.Id},Name -{Mobile.Name},Description -{Mobile.Description}, ManufacturedBy- {Mobile.ManufacturedBy},Price- {Mobile.Price}");
                    }
                }
            }
        }
        public void viewAllMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice()
        {
            List<Mobile> mobileList = new List<Mobile>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_viewAllMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Mobile mobile = new Mobile();
                        mobile.Id = Convert.ToInt32(reader["Id"]);
                        mobile.Name = Convert.ToString(reader["Name"]);
                        mobile.Description = Convert.ToString(reader["Description"]);
                        mobile.ManufacturedBy = Convert.ToString(reader["ManufacturedBy"]);
                        mobile.Price = Convert.ToInt32(reader["Price"]);
                        mobileList.Add(mobile);

                    }
                    foreach (Mobile mobiles in mobileList)
                    {
                        Console.WriteLine($"Id -{mobiles.Id},Name -{mobiles.Name},Description -{mobiles.Description}, ManufacturedBy- {mobiles.ManufacturedBy},Price- {mobiles.Price}");
                    }
                }
            }
        }
        public void DeleteMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "sp_RemoveMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    connection.Open();

                    command.ExecuteNonQuery();
                    Console.WriteLine("Mobile record deleted successfully!!!");

                }
            }
        }
    }
}


