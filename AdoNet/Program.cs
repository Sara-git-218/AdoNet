using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Data;
internal class Program
{
    public int InsertData(string connectionString)
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

        string query = "INSERT INTO Products(ProductName,CatgoryID,Price,ProductDescription)" +
            "VALUES(@product_name,@cagory,@price,@product_Description,@imageurl)";
        using (SqlConnection cn = new SqlConnection(connectionString)) 
        using (SqlCommand cmd = new SqlCommand(query, cn))
        {
            cmd.Parameters.Add("@product_name", SqlDbType.NVarChar, 50).Value = product_name;
            cmd.Parameters.Add("@catgory", SqlDbType.SmallInt).Value = cagory;
            cmd.Parameters.Add("@price", SqlDbType.SmallInt).Value = price;
            cmd.Parameters.Add("@product_Description", SqlDbType.NVarChar, 50).Value = product_Description;

            cn.Open();
            int rowsAffect = cmd.ExecuteNonQuery();
            cn.Close();
            return rowsAffect;
        }

    }
    internal void readData(string connectionString)
    {
        string query= "select * from Products";
        using(SqlConnection connection=
            new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine(
                        "\t{1}\t{2}\t{3}\t{4}\t{5}",
                        reader[0], reader[1], reader[2], reader[3], reader[5]);
                }
                reader.Close();
            }
            catch(Exception ex)
                {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
    private static void Main(string[] args)
    {
        string connectionString=""
       
    }
}