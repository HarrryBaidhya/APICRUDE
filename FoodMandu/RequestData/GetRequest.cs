using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using FoodMandu.Models;


namespace FoodMandu.RequestData
{
    
    public  Layout GetallLayout()
    {
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Uranus_Api"].ConnectionString);
        string connectionString = ConfigurationManager.ConnectionStrings["FoodMandu"].ToString();

        using (var connection = new SqlConnection(connectionString))
        {

            Layout receiptData = new Layout();
            var storedProcedureName = "";
            var values = new
            {
                LayoutId = "",
            };
            try
            {
                receiptData = connection.QueryFirstOrDefault<Layout>(storedProcedureName, values, commandType: CommandType.StoredProcedure);

            }
            catch (SqlException sqlEx)
            {

            }
            return receiptData;
        }
    }
}