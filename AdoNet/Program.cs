using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace AdoNet
{
    internal class Program

    {

        private static void Main(string[] args)
        {
            string connectionString = " Data Source = SRV2\\PUPILS; Initial Catalog = 326059268_ShopApi; Integrated Security = True; Trust Server Certificate = True";

            DataAcces dataAcces = new DataAcces();
            int v = dataAcces.InsertDataProd(connectionString);
            dataAcces.readDataProd(connectionString);
            //int a = dataAcces.InsertDataCatgory(connectionString);
            //dataAcces.readDataCatgory(connectionString);
        }
    }
}