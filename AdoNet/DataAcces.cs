using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
namespace AdoNet
{
    class DataAcces
    {

        internal int InsertDataProd(string connectionString)
        {
            int rowsAffect = 0;
            char tocontinue= 'y';
            while(tocontinue=='y')
            { 
            Console.WriteLine("Hello, World!");
            Console.WriteLine("enter product name");
            string product_name = Console.ReadLine();
            Console.WriteLine("enter catgory");
            string cagory = Console.ReadLine();
            Console.WriteLine("enter price");
            string price = Console.ReadLine();
            Console.WriteLine("enter product description");
            string product_Description = Console.ReadLine();
            Console.WriteLine("enter product imageurl");
            string imageurl = Console.ReadLine();

            string query = "INSERT INTO Products(ProductName,CatgoryID,Price,ProductDesdription,ImageUrl)" +
                "VALUES(@product_name,@catgory,@price,@product_Description,@imageurl)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@product_name", SqlDbType.NVarChar, 50).Value = product_name;
                cmd.Parameters.Add("@catgory", SqlDbType.SmallInt).Value = cagory;
                cmd.Parameters.Add("@price", SqlDbType.SmallInt).Value = price;
                cmd.Parameters.Add("@product_Description", SqlDbType.NVarChar, 50).Value = product_Description;
                cmd.Parameters.Add("@imageurl", SqlDbType.NVarChar, 50).Value = imageurl;
                cn.Open();
                 rowsAffect = cmd.ExecuteNonQuery();
                cn.Close();
               
            }
                Console.WriteLine("Do you want to continue? (y/n)");
                tocontinue = Console.ReadLine()[0];

            }
         return rowsAffect;
        }
        internal int InsertDataCatgory(string connectionString)
        {
            int rowsAffect = 0;
            char tocontinue = 'y';
            while (tocontinue == 'y')
            {
                Console.WriteLine("Hello, World!");
                Console.WriteLine("enter CatgoryName");
                string catgory_name = Console.ReadLine();


                string query = "INSERT INTO Catgories(CatgoryName)" +
                    "VALUES(@catgory_name)";
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@catgory_name", SqlDbType.NVarChar, 50).Value = catgory_name;

                    cn.Open();
                    rowsAffect += cmd.ExecuteNonQuery();
                    cn.Close();
                   
                }
                Console.WriteLine("Do you want to continue? (y/n)");
                tocontinue =Console.ReadLine()[0];
            }
 return rowsAffect;
        }
        internal void readDataProd(string connectionString)
        {
            string query = "select * from Products";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Console.ReadLine();
            }
        }
        internal void readDataCatgory(string connectionString)
        {
            string query = "select * from Catgories";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Console.ReadLine();
            }
        }
    }
}
